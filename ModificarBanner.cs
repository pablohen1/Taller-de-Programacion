using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Carteleria_Digital
{
    public partial class ModificarBanner : Form
    {   //Se inicializan las variables globales.
        Banner unBanner = new Banner();
        List<RSS> listRSS = new List<RSS>();

        /// <summary>
        /// Permite modificar un banner entrante.
        /// </summary>
        /// <param name="ban"></param>
        public ModificarBanner(Banner ban)
        {   //Se inicializan los controles y se cargan las variables.        
            InitializeComponent();
            this.unBanner = ban;
            dtHINI.Format = DateTimePickerFormat.Time;
            dtHINI.ShowUpDown = true;
            dtHINI.CustomFormat = "hh:mm";
            dtHFIN.Format = DateTimePickerFormat.Time;
            dtHFIN.ShowUpDown = true;
            dtFINI.CustomFormat = "hh:mm";
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {   //Cierra la ventana al presionar la tecla Escape.
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);
            return res;
        }


        public void actualizarRSS()
        {   //Carga el combobox con los RSS existentes.
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

        public void cargarPantalla()
        {   //Se rellenan los campos con los valores actuales del banner que se modificará.
            dtFINI.Value = unBanner.fechaInicial.Date;
            dtFFIN.Value = unBanner.fechaFinal.Date;
            dtHINI.Value = unBanner.horaInicial;
            dtHFIN.Value = unBanner.horaFinal;

            switch (unBanner.unafuente.tipo)
            {
                case 1:
                    {
                        TextoFijo unTXT = (TextoFijo)unBanner.unafuente;
                        textBoxBanner.Text = unTXT.texto;
                        comboBoxRSS.SelectedValue = null;
                        chckTexto.CheckState = CheckState.Checked;
                        chckRSS.CheckState = CheckState.Unchecked;
                    }
                    break;

                case 0:
                    {
                        RSS unrss = (RSS)unBanner.unafuente;
                        RSS tmp = comboBoxRSS.Items.OfType<RSS>().Where(x => x.descripcion == unrss.descripcion).FirstOrDefault();
                        try
                        {
                            comboBoxRSS.SelectedIndex = comboBoxRSS.Items.IndexOf(tmp);
                        }
                        catch { comboBoxRSS.SelectedIndex = 1; }
                        this.comboBoxRSS.ValueMember = "descripcion";
                        chckTexto.CheckState = CheckState.Unchecked;
                        chckRSS.CheckState = CheckState.Checked;
                    }
                    break;
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {   //Se modifica el banner entrante.
            //Si se selecciona Texto, éste no puede estar vacio.
            if (chckTexto.CheckState == CheckState.Checked && !textBoxBanner.Text.Equals("") || chckTexto.CheckState == CheckState.Unchecked)
            {   //Se verifican los datos ingresados.
                if ((dtFFIN.Value > dtFINI.Value) || (dtFFIN.Value.Equals(dtFINI.Value)))
                {
                    if (dtHFIN.Value > dtHINI.Value)
                    {
                        if ((comboBoxRSS.SelectedItem != null) && (chckRSS.CheckState == CheckState.Checked) || chckRSS.CheckState == CheckState.Unchecked)
                        {
                            listRSS = Controlador.obtenerRss().Distinct().ToList();
                            Banner banner1 = new Banner();
                            banner1.fechaInicial = new DateTime(dtFINI.Value.Year, dtFINI.Value.Month, dtFINI.Value.Day, dtFINI.Value.Hour, dtFINI.Value.Minute, dtFINI.Value.Second);
                            banner1.fechaFinal = new DateTime(dtFFIN.Value.Year, dtFFIN.Value.Month, dtFFIN.Value.Day, dtFFIN.Value.Hour, dtFFIN.Value.Minute, dtFFIN.Value.Second);
                            banner1.horaInicial = new DateTime(dtHINI.Value.Year, dtHINI.Value.Month, dtHINI.Value.Day, dtHINI.Value.Hour, dtHINI.Value.Minute, dtHINI.Value.Second);
                            banner1.horaFinal = new DateTime(dtHFIN.Value.Year, dtHFIN.Value.Month, dtHFIN.Value.Day, dtHFIN.Value.Hour, dtHFIN.Value.Minute, dtHFIN.Value.Second);

                            //Dependiendo del checkbox habilitado, es el tipo de banner a incorporar.    
                            if (chckRSS.CheckState == CheckState.Checked)
                            {
                                banner1.unafuente = (RSS)comboBoxRSS.SelectedItem;
                            }
                            else
                            {
                                TextoFijo textf = new TextoFijo();
                                textf.texto = textBoxBanner.Text;
                                textf.tipo = TipoFuente.TextoFijo.GetHashCode();
                                banner1.unafuente = textf;
                            }

                            banner1.bannerID = unBanner.bannerID;
                            Controlador.modificarBanner(banner1);
                            MessageBox.Show("El banner modificó con exito", "Información",
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

        private void buttonCancelar_Click(object sender, EventArgs e)
        {   //Se cierra la ventana al presionar en Cancelar.
            this.Close();
        }

        private void buttonNuevoRss_Click(object sender, EventArgs e)
        {    //Agrega un nuevo RSS al sistema.
            using (var agregarRSS = new NuevaFuente())
            {
                var resultado = agregarRSS.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    actualizarRSS();
                }
            }
        }

        private void ModificarBanner_Load(object sender, EventArgs e)
        {   //Al iniciar la ventana carga el combobox de RSS y los datos que se modificarán.
            actualizarRSS();
            cargarPantalla();           
            comboBoxRSS.DropDownStyle = ComboBoxStyle.DropDownList;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
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

        private void buttonEditarRss_Click(object sender, EventArgs e)
        {   //Obtiene el RSS a editar y se lo transfiere a la clase editarRSS.
            listRSS = Controlador.obtenerRss().Distinct().ToList();

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

        private void btnEliminar_Click(object sender, EventArgs e)
        {   //Elimina el RSS seleccionado en el combobox.
            listRSS = Controlador.obtenerRss();

            RSS unRss1 = listRSS.Find(f => f.descripcion.Equals(comboBoxRSS.Text));
            if (unRss1 != null)
            {
                var resultado = MessageBox.Show("¿Esta seguro que desea eliminar la fuente?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (resultado == DialogResult.OK)
                {
                    Controlador.eliminarRss(unRss1.texto, unRss1.descripcion);
                    actualizarRSS();
                }

            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            RSS unRss1 = listRSS.Find(f => f.descripcion.Equals(comboBoxRSS.Text));
            if (unRss1 != null)
            {
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
    }
}
