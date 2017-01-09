using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Carteleria_Digital
{
    public partial class ListarBanner : Form
    {
        bool ordenFF = false;
        bool ordenFI = false;
        bool ordenHF = false;
        bool ordenHI = false;
        List<Banner> Banners = new List<Banner>();

        /// <summary>
        /// Muestra una lista de todos los banners cargados al sistema.
        /// </summary>
        public ListarBanner()
        {   //Inicializa los controles cargando la lista.        
            InitializeComponent();
            actualizarLista();
            Cursor.Show();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {   //Cierra la ventana al presionar la tecla Escape.
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);
            return res;
        }

        private int obtenerIDBannerSeleccionado()
        {   //Obtiene el ID de la fila seleccionada.
            DataGridViewRow row = this.dataGridView1.SelectedRows[0];
            int id = int.Parse(row.Cells["bannerID"].Value.ToString());
            return id;
        }
        private void BTNSalir(object sender, EventArgs e)
        {   //Cierra la ventana al presionar en Salir,
            this.Close();
        }

        private void btnModificarBanner_Click(object sender, EventArgs e)
        {   //Obtiene el ID de la fila seleccionada (Banner) y se lo pasa a la clase ModificarBanner para su modificacion.
            if (dataGridView1.SelectedRows.Count != 0)
            {
                int id1 = obtenerIDBannerSeleccionado();
                Banner contb = Banners.Find(f => f.bannerID == id1);
                ModificarBanner modif = new ModificarBanner(contb);
                modif.ShowDialog();
                modif.Dispose();
                actualizarLista();
            }
        }

        private void btnVerContenido_Click(object sender, EventArgs e)
        {   //Muestra el contenido el banner seleccionado.            
            if (dataGridView1.SelectedRows.Count != 0)
            {
                int id1 = obtenerIDBannerSeleccionado();
                Banner contb = Banners.Find(f => f.bannerID==id1);
                VerContenido vercont = new VerContenido(contb.unafuente);
                vercont.ShowDialog();
                vercont.Dispose();
            }
        }

        private void btnEliminarBanner_Click(object sender, EventArgs e)
        {   //Elimina el banner seleccionado.
            if (dataGridView1.SelectedRows.Count != 0)
            {
                int id1 = obtenerIDBannerSeleccionado();
                var resultado = MessageBox.Show("¿Esta seguro que desea eliminar el banner?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (resultado == DialogResult.OK)
                {
                    Controlador.eliminarBanner(id1);
                    actualizarLista();
                }
            }
        }

        private void actualizarLista()
        {   //Actualiza la lista de banners e inicializa variables.
            Banners = Controlador.obtenerTodosLosBanners();
            dataGridView1.DataSource = Banners;
            this.dataGridView1.Columns[0].Visible = false;
            this.dataGridView1.Columns[5].Visible = false;
            this.dataGridView1.Columns[1].HeaderCell.Value = "Fecha Inicial";
            this.dataGridView1.Columns[2].HeaderCell.Value = "Fecha Final";
            this.dataGridView1.Columns[3].HeaderCell.Value = "Hora Inicial";
            this.dataGridView1.Columns[3].DefaultCellStyle.Format = "HH:mm:ss";
            this.dataGridView1.Columns[4].HeaderCell.Value = "Hora Final";
            this.dataGridView1.Columns[4].DefaultCellStyle.Format = "HH:mm:ss";
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
        }

        private void ListarBanner_Load(object sender, EventArgs e)
        {   //Se realizan ajustes de visualizacion y carga de variables al iniciar la ventana.
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            string[] s = {"TODOS","Fechas","Horas","Tipo de banner"};
            this.comboBusqueda.DataSource = s;
            comboBusqueda.DropDownStyle = ComboBoxStyle.DropDownList;
            string[] r = {"RSS", "Texto Fijo"};
            this.comboTipo.DataSource = r;
            comboTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboTipo.Hide();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {  
            switch (comboBusqueda.Text)
            {   //Se ocultan/muestran controles segun el caso.
                case "TODOS": {
                        actualizarLista();
                        comboTipo.Hide();
                        fecha1.Hide();
                        fecha2.Hide();
                        lblInicio.Hide();
                        lblFin.Hide() ;                     
                        btnFiltrar.Enabled = false;
                        break; }
                case "Fechas": {
                        fecha1.Show();
                        fecha2.Show();
                        comboTipo.Hide();
                        fecha1.Format = DateTimePickerFormat.Short;
                        fecha2.Format = DateTimePickerFormat.Short;
                        lblInicio.Show();
                        lblFin.Show();                    
                        btnFiltrar.Enabled = true;
                        break;
                    }
                case "Horas":
                    {
                        comboTipo.Hide();
                        fecha1.Show();
                        fecha2.Show();
                        lblInicio.Show();
                        lblFin.Show();
                        fecha1.Format = DateTimePickerFormat.Time;
                        fecha1.ShowUpDown = true;
                        fecha1.CustomFormat = "hh:mm";
                        fecha2.Format = DateTimePickerFormat.Time;
                        fecha2.ShowUpDown = true;
                        fecha2.CustomFormat = "hh:mm";
                        btnFiltrar.Enabled = true;
                        break;
                    }
                case "Tipo de banner":
                    {
                        fecha1.Hide();
                        fecha2.Hide();
                        lblInicio.Hide();
                        lblFin.Hide();
                        comboTipo.Show();
                        fecha1.Hide();
                        fecha2.Hide();
                        btnFiltrar.Enabled = true;
                        break;
                    }
            }
            }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {    //Segun el tipo de busqueda seleccionada en el ComboBox, se realizara la operacion que corresponda.
            switch (comboBusqueda.Text)
            {              
                case "Fechas":
                    {   //Carga el datasource con los Banners cuyas fechas se encuentren en el intervalo.
                        List<Banner> bannersFecha = new List<Banner>();
                        foreach (Banner b in Banners) {
                            if (fecha1.Value <= b.fechaInicial.AddDays(1) && fecha2.Value >= b.fechaFinal)
                            { bannersFecha.Add(b); }
                        }
                        dataGridView1.DataSource = bannersFecha;
                        break;
                    }
                case "Horas":
                    {   //Carga el datasource con los Banners cuyas horas se encuentren en el intervalo.
                        List<Banner> bannersHora = new List<Banner>();
                        foreach (Banner b in Banners)
                        {
                            DateTime Hini = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, b.horaInicial.Hour, b.horaInicial.Minute, b.horaInicial.Second);
                            DateTime HFin = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, b.horaFinal.Hour, b.horaFinal.Minute, b.horaFinal.Second);

                            if (fecha1.Value <= Hini && fecha2.Value >= HFin)
                            { bannersHora.Add(b); }
                        }
                        dataGridView1.DataSource = bannersHora;
                        break;
                    }
                case "Tipo de banner":
                    {   //Carga el datasource con los Banners que correspondan a un tipo.
                        switch (comboTipo.Text)
                        {
                            case "RSS": {
                                    List<Banner> bannersRSS = new List<Banner>();
                                    foreach (Banner b in Banners)
                                    {
                                        if (b.unafuente.tipo == TipoFuente.Rss.GetHashCode())
                                        { bannersRSS.Add(b); }
                                    }
                                    dataGridView1.DataSource = bannersRSS;
                                    break;
                                }
                            case "Texto Fijo":
                                {
                                    List<Banner> bannersTFijo = new List<Banner>();
                                    foreach (Banner b in Banners)
                                    {
                                        if (b.unafuente.tipo == TipoFuente.TextoFijo.GetHashCode())
                                        { bannersTFijo.Add(b); }
                                    }
                                    dataGridView1.DataSource = bannersTFijo;
                                    break;
                                }
                        }                                       
                        break;
                    }
            }
        }

        public void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {   //Reordena las filas segun la columna que Clickee el usuario (alterna en ascendente/descendente).
            int column = e.ColumnIndex;

            switch (column)
            {
                case 1:
                    {
                        if (!ordenFI)
                        {
                            var newList = Banners.OrderBy(x => x.fechaInicial).ToList();
                            dataGridView1.DataSource = newList;
                            formatearDataSet();
                        }
                        else
                        {
                            var newList = Banners.OrderByDescending(x => x.fechaInicial).ToList();
                            dataGridView1.DataSource = newList;
                            formatearDataSet();
                        }
                        ordenFI = !ordenFI;
                        break;
                    }
                case 2:
                    {
                        if (!ordenFF)
                        {
                            var newList = Banners.OrderBy(x => x.fechaFinal).ToList();
                            dataGridView1.DataSource = newList;
                            formatearDataSet();
                        }
                        else
                        {
                            var newList = Banners.OrderByDescending(x => x.fechaFinal).ToList();
                            dataGridView1.DataSource = newList;
                            formatearDataSet();
                        }
                        ordenFF = !ordenFF;
                        break;
                    }
                case 3:
                    {
                        if (!ordenHI)
                        {
                            var newList = Banners.OrderBy(x => x.horaInicial.Hour).ToList();
                            dataGridView1.DataSource = newList;
                            formatearDataSet();
                        }
                        else
                        {
                            var newList = Banners.OrderByDescending(x => x.horaInicial.Hour).ToList();
                            dataGridView1.DataSource = newList;
                            formatearDataSet();
                        }
                        ordenHI = !ordenHI;
                        break;
                    }
                case 4:
                    {
                        if (!ordenHF)
                        {
                            var newList = Banners.OrderBy(x => x.horaFinal.Hour).ToList();
                            dataGridView1.DataSource = newList;
                            formatearDataSet();
                        }
                        else
                        {
                            var newList = Banners.OrderByDescending(x => x.horaFinal.Hour).ToList();
                            dataGridView1.DataSource = newList;
                            formatearDataSet();
                        }
                        ordenHF = !ordenHF;
                        break;
                    }
            }
        }

        private void formatearDataSet()
        {   //Se le da a la lista un formato adecuado, ocultando los campos irrelevantes para el usuario.
            this.dataGridView1.Columns[0].Visible = false;
            this.dataGridView1.Columns[5].Visible = false;
            this.dataGridView1.Columns[1].HeaderCell.Value = "Fecha Inicial";
            this.dataGridView1.Columns[2].HeaderCell.Value = "Fecha Final";
            this.dataGridView1.Columns[3].HeaderCell.Value = "Hora Inicial";
            this.dataGridView1.Columns[3].DefaultCellStyle.Format = "HH:mm:ss";
            this.dataGridView1.Columns[4].HeaderCell.Value = "Hora Final";
            this.dataGridView1.Columns[4].DefaultCellStyle.Format = "HH:mm:ss";
        }

        private void ListarBanner_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cursor.Hide();
        }
    }
}
