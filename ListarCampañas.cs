using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Carteleria_Digital
{
    public partial class ListarCampañas : Form
    {   //Inicializacion de variables globales
        bool ordenFF = false;
        bool ordenFI = false;
        bool ordenHF = false;
        bool ordenHI = false;
        List<Campaña> Campañas = new List<Campaña>();

        /// <summary>
        /// Lista todas las campañas cargadas en el sistema.
        /// </summary>
        public ListarCampañas()
        {   //Centra el foco en esta ventana y carga la lista de campañas.
            this.Focus();
            InitializeComponent();
            actualizarLista();
            Cursor.Show();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {  //Cierra la ventana al presionar la tecla Escape.
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);
            return res;
        }

        private void btnSalir(object sender, EventArgs e)
        {   //Cierrra la ventana al presionar en Salir.
            this.Close();
        }

        private void btnVerImagenes(object sender, EventArgs e)
        {   //Se obtiene el id de la fila seleccionada y se muestran las imágenes del mismo.
            if (dataGridView1.SelectedRows.Count != 0)
            {
                int id1 = obtenerIDCampañaSeleccionada();
                VerImagenes verImG = new VerImagenes(id1);
                verImG.ShowDialog();
            }
        }

        private void btnEliminarCampaña_Click(object sender, EventArgs e)
        {   //Elimina la campaña correspondiente a la fila seleccionada.
            if (dataGridView1.SelectedRows.Count != 0)
            {
                int id1 = obtenerIDCampañaSeleccionada();
                var resultado = MessageBox.Show("¿Esta seguro que desea eliminar la fuente?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (resultado == DialogResult.OK)
                {
                    Controlador.eliminarCampaña(id1);
                    actualizarLista();                 
                }               
            }
        }

        private void actualizarLista()
        {   //Carga el datasourse con las campañas.      
            Campañas = Controlador.obtenerListaCampañas();
            dataGridView1.DataSource = Campañas;
            formatearDataSet();           
        }

        private void btnModificarCampaña_Click(object sender, EventArgs e)
        {   //Modifica la campaña correspondiente al ID de la fila seleccionada.
            if (dataGridView1.SelectedRows.Count != 0)
            {
                int id1 = obtenerIDCampañaSeleccionada();
                ModificarCampaña modif = new ModificarCampaña(id1);
                modif.ShowDialog();
                modif.Dispose();                                   
                actualizarLista();
            }
        }

        private int obtenerIDCampañaSeleccionada()
        {   //Obtiene el ID de la fila seleccionada.
            DataGridViewRow row = this.dataGridView1.SelectedRows[0];
            int id = int.Parse(row.Cells["campañaID"].Value.ToString());
            return id;
        }

        private void ListarCampañas_Load(object sender, EventArgs e)
        {   //Al iniciar la ventana se realizan ajustes de visualizacion y carga de variables.
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            string[] s = { "TODOS", "Fechas", "Horas"};
            comboBusqueda.DataSource = s;
            comboBusqueda.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {   //Segun el tipo de busqueda seleccionada en el ComboBox, se realizara la operacion que corresponda.
            switch (comboBusqueda.Text)
            {
                case "Fechas":
                    {   //Carga el datasource con las campañas cuyas fechas se encuentren en el intervalo.
                        List<Campaña> campañasFecha = new List<Campaña>();
                        foreach (Campaña b in Campañas)
                        {
                            if (fecha1.Value <= b.fechaInicial.AddDays(1) && fecha2.Value >= b.fechaFinal)
                            { campañasFecha.Add(b); }
                        }

                        dataGridView1.DataSource = campañasFecha;
                        break;
                    }

                case "Horas":
                    {   //Carga el datasource con las campañas cuyas horas se encuentren en el intervalo.
                           List<Campaña> campañasHoras = new List<Campaña>();
                           foreach (Campaña b in Campañas)
                        {
                               DateTime Hini = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, b.horaInicial.Hour, b.horaInicial.Minute, b.horaInicial.Second);
                                 DateTime HFin = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, b.horaFinal.Hour, b.horaFinal.Minute, b.horaFinal.Second);

                              if (fecha1.Value <= Hini && fecha2.Value >= HFin)
                              { campañasHoras.Add(b); }

                            dataGridView1.DataSource = campañasHoras;
                        }
                        break;
                    }        
            }
        }

        private void comboBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {   //Muestra y oculta controles, segun al busqueda deseada.
            switch (comboBusqueda.Text)
            {
                case "TODOS":
                    {
                        actualizarLista();
                        fecha1.Hide();
                        fecha2.Hide();
                        lblInicio.Hide();
                        lblFin.Hide();
                        btnFiltrar.Enabled = false;
                        break;
                    }
                case "Fechas":
                    {
                        fecha1.Show();
                        fecha2.Show();
                        fecha1.Format = DateTimePickerFormat.Short;
                        fecha2.Format = DateTimePickerFormat.Short;
                        lblInicio.Show();
                        lblFin.Show();
                        btnFiltrar.Enabled = true;
                        break;
                    }
                case "Horas":
                    {
                        fecha1.Show();
                        fecha2.Show();
                        lblInicio.Show();
                        lblFin.Show();
                        fecha1.Format = DateTimePickerFormat.Time;
                        fecha1.ShowUpDown = true;
                        fecha1.CustomFormat = "HH:mm:ss";
                        fecha2.Format = DateTimePickerFormat.Time;
                        fecha2.ShowUpDown = true;
                        fecha2.CustomFormat = "HH:mm:ss";
                        btnFiltrar.Enabled = true;
                        break;
                    }
            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {   //Reordena las filas segun la columna que Clickee el usuario (alterna en ascendente/descendente).
            int column = e.ColumnIndex;

            switch (column) {
                case 1:
                    {
                        if (!ordenFI) { 
                        var newList = Campañas.OrderBy(x => x.fechaInicial).ToList();
                        dataGridView1.DataSource = newList;
                        formatearDataSet();
                    }else{
                            var newList = Campañas.OrderByDescending(x => x.fechaInicial).ToList();
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
                            var newList = Campañas.OrderBy(x => x.fechaFinal).ToList();
                            dataGridView1.DataSource = newList;
                            formatearDataSet();
                        }
                        else
                        {
                            var newList = Campañas.OrderByDescending(x => x.fechaFinal).ToList();
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
                            var newList = Campañas.OrderBy(x => x.horaInicial.Hour).ToList();
                            dataGridView1.DataSource = newList;
                            formatearDataSet();
                        }
                        else
                        {
                            var newList = Campañas.OrderByDescending(x => x.horaInicial.Hour).ToList();
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
                            var newList = Campañas.OrderBy(x => x.horaFinal.Hour).ToList();
                            dataGridView1.DataSource = newList;
                            formatearDataSet();
                        }
                        else
                        {
                            var newList = Campañas.OrderByDescending(x => x.horaFinal.Hour).ToList();
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
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
        }

        private void ListarCampañas_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cursor.Hide();
        }
    }
}
