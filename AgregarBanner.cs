using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Carteleria_Digital
{
    public partial class AgregarBanner : Form
    {   //Se inicializan las variables globales.
        List<RSS> listRSS = new List<RSS>();
        
        /// <summary>
        /// Agrega un nuevo banner al sistema.
        /// </summary>
        public AgregarBanner()
        {   //Se inicializan los controles y se cargan las variables.
            InitializeComponent();
            this.Focus();
            dtHINI.Format= DateTimePickerFormat.Time;
            dtHINI.ShowUpDown = true;
            dtHINI.CustomFormat = "hh:mm";
            dtHFIN.Format = DateTimePickerFormat.Time;
            dtHFIN.ShowUpDown = true;
            dtHFIN.CustomFormat = "hh:mm";
            Cursor.Show();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {  //Cierra la ventana al presionar la tecla Escape.
            if (keyData == Keys.Escape)
            {
                this.Close();
            }
            bool res = base.ProcessCmdKey(ref msg, keyData);
            return res;
        }

        private void editarRss_Click(object sender, EventArgs e)
        {   //Obtiene el RSS a editar y se lo transfiere a la clase editarRSS.
            listRSS = Controlador.obtenerRss().ToList();

            RSS unRss1 = listRSS.Find(f => f.descripcion.Equals(comboBoxRSS.Text));
           
            if (unRss1 != null)
            {
                using (var editarRSS = new EditarFuente(unRss1.descripcion, unRss1.texto))
                {
                    var resultado = editarRSS.ShowDialog();
                    if (resultado == DialogResult.OK)
                    {
                        actualizarRSS();
                    }
                }
            }
        }

        private void agregarRss_Click(object sender, EventArgs e)
        {       //Agrega un nuevo RSS al sistema.
                using (var agregarRSS = new NuevaFuente())
                {
                    var resultado = agregarRSS.ShowDialog();
                    if (resultado == DialogResult.OK)
                    {
                        actualizarRSS();
                    }
                }            
        }

        private void AgregarBanner_Load(object sender, EventArgs e)
        {   //Al iniciar la ventana, carga la lista de RSS y realiza ajuste de visualizacion.
            actualizarRSS();
            buttonEditarRss.Enabled = false;
            comboBoxRSS.DropDownStyle = ComboBoxStyle.DropDownList;
            chckTexto.CheckState = CheckState.Checked;
            chckRSS.CheckState = CheckState.Unchecked;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void agregar_Click(object sender, EventArgs e)
        {   //Agrega el banner el sistema.
            //Si se selecciona Texto, éste no puede estar vacio.
            if (chckTexto.CheckState==CheckState.Checked && !textBoxBanner.Text.Equals("")|| chckTexto.CheckState == CheckState.Unchecked)
            {   //Se realizan verificaciones de los datos ingresados.
                if ((dtFFIN.Value > dtFINI.Value) || (dtFFIN.Value.Equals(dtFINI.Value)))
                {
                    if (dtHFIN.Value > dtHINI.Value)
                    {
                        if ((comboBoxRSS.SelectedItem != null)&&(chckRSS.CheckState == CheckState.Checked)|| chckRSS.CheckState == CheckState.Unchecked)
                        {
                            listRSS = Controlador.obtenerRss();
                            Banner banner1 = new Banner();
                            banner1.fechaInicial = new DateTime(dtFINI.Value.Year, dtFINI.Value.Month, dtFINI.Value.Day, dtFINI.Value.Hour, dtFINI.Value.Minute, dtFINI.Value.Second);
                            banner1.fechaFinal = new DateTime(dtFFIN.Value.Year, dtFFIN.Value.Month, dtFFIN.Value.Day, dtFFIN.Value.Hour, dtFFIN.Value.Minute, dtFFIN.Value.Second);
                            banner1.horaInicial = new DateTime(dtHINI.Value.Year, dtHINI.Value.Month, dtHINI.Value.Day, dtHINI.Value.Hour, dtHINI.Value.Minute, dtHINI.Value.Second);
                            banner1.horaFinal = new DateTime(dtHFIN.Value.Year, dtHFIN.Value.Month, dtHFIN.Value.Day, dtHFIN.Value.Hour, dtHFIN.Value.Minute, dtHFIN.Value.Second);

                            //Dependiendo del checkbox habilitado, es el tipo de banner a incorporar.                      
                            if (chckRSS.CheckState == CheckState.Checked)
                            {   //Agrega el RSS seleccionado en el combobox a la fuente del banner.
                                banner1.unafuente = (RSS)comboBoxRSS.SelectedItem;
                            }
                            else
                            {   //Crea y carga un objeto de tipo textofijo y lo incorpora al banner.
                                TextoFijo textf = new TextoFijo();
                                textf.texto = textBoxBanner.Text;
                                textf.tipo = TipoFuente.TextoFijo.GetHashCode();
                                banner1.unafuente = textf;
                            }
                            //Agrega el banner al sistema e informa al usuario
                            Controlador.agregarBanner(banner1);
                            MessageBox.Show("El banner se agregó con exito", "Información",
                            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else { MessageBox.Show("Debe seleccionar un RSS de la lista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                    else { MessageBox.Show("Verifique el intervalo de horas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else { MessageBox.Show("Verifique el intervalo de fechas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else { MessageBox.Show("El campo texto no puede estar vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnCancelar(object sender, EventArgs e)
        {   //Cierra la ventana al presionar en cancelar.
            this.Close();
        }

        private void comboBoxRSS_SelectedIndexChanged(object sender, EventArgs e)
        {   //Al seleccionar algun RSS habilita botones.
            if (comboBoxRSS.SelectedIndex > -1)
            {
                textBoxBanner.Enabled = false;
                buttonEditarRss.Enabled = true;
            }
            else
            {
                textBoxBanner.Enabled = true;
                buttonEditarRss.Enabled = false;
            }
        }

        public void actualizarRSS()
        {   //Actualiza el combobox correspondiente con sus RSSs.
            comboBoxRSS.Items.Clear();
            listRSS = Controlador.obtenerRss();
            foreach (RSS rss in listRSS)
            {
                if (rss.texto != null)
                {                
                    comboBoxRSS.Items.Add(rss);
                    this.comboBoxRSS.ValueMember = "descripcion";
                }
            }
        }

        private void btnEliminarRss(object sender, EventArgs e)
        {   //Elimina el RSS seleccionado en el combobox.
            listRSS = Controlador.obtenerRss();

            RSS unRss1 = listRSS.Find(f => f.descripcion.Equals(comboBoxRSS.Text));
            if (unRss1 != null)
            {                
                    var resultado = MessageBox.Show("¿Esta seguro que desea eliminar la fuente?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (resultado == DialogResult.OK)
                    {
                    Controlador.eliminarRss(unRss1.texto,unRss1.descripcion);
                    actualizarRSS();
                    }                
            }

        }

        private void chckTexto_CheckedChanged(object sender, EventArgs e)
        {   //Cada vez que cambia el checkbox del texto, cambian los controles.
            chckRSS.Checked = !chckTexto.Checked;
            textBoxBanner.Enabled = true;
            comboBoxRSS.Enabled = false;
            btnEliminar.Enabled = false;
            buttonNuevoRss.Enabled = false;
            buttonEditarRss.Enabled = false;
            btnVerificar.Enabled = false;
        }

        private void chckRSS_CheckedChanged(object sender, EventArgs e)
        {   //Cada vez que cambia el checkbox del RSS, cambian los controles.
            chckTexto.Checked = !chckRSS.Checked;
            comboBoxRSS.Enabled = true;
            textBoxBanner.Enabled = false;
            buttonNuevoRss.Enabled = true;
            buttonEditarRss.Enabled = true;
            btnEliminar.Enabled = true;
            btnVerificar.Enabled = true;
        }

        //Verifica si puede establecer conexion con la fuente RSS seleccionada
        private void button1_Click(object sender, EventArgs e)
        {   //Busca en el comboBox el rss seleccionado 
            RSS unRss1 = listRSS.Find(f => f.descripcion.Equals(comboBoxRSS.Text));
            if (unRss1 != null)
            {   //Llama al metodo verificarRss para ver si puede conectar con el mismo, informando en cada caso.
                if (Controlador.verificarRss(unRss1.texto))
                {
                    MessageBox.Show("Conexion establecida con la fuente RSS", "Información",
                          MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("No se pudo establecer la conexion con la fuente RSS", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                
            }
        }

        private void AgregarBanner_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cursor.Hide();
        }
    }
}
