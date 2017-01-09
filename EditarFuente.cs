using System;
using System.Windows.Forms;

namespace Carteleria_Digital
{
    public partial class EditarFuente : Form
    {   //Se inicializan variables globales.
        string urlActual;
        string descripcionActual;

        /// <summary>
        /// Permite modificar un fuente RSS entrante.
        /// </summary>
        /// <param name="desACT"></param>
        /// <param name="urlACT"></param>
        public EditarFuente(string desACT,string urlACT)
        {   //Carga de variables.
            InitializeComponent();
            urlActual = urlACT;
            descripcionActual = desACT;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {   //Cierra la ventana al presionar la tecla Escape.
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);
            return res;
        }

        private void EditarFuente_Load(object sender, EventArgs e)
        {   //Al iniciar, se cargan los campos con los valores actuales del RSS y realizan ajustes de visualizacion. 
            textBoxNombre.Text = descripcionActual;
            textBoxURL.Text = urlActual;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {   //Se realizan las modificaciones en el RSS.
            if (!string.IsNullOrWhiteSpace(textBoxNombre.Text))
            {
                if (!string.IsNullOrWhiteSpace(textBoxURL.Text))
                {
                    Controlador.modificarRss(urlActual, descripcionActual, textBoxNombre.Text, textBoxURL.Text);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else { MessageBox.Show("La URL no puede estar vacia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else { MessageBox.Show("La descripción no puede estar vacia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {   //Se cierra la ventana al presionar en "Cancelar".
            this.Close();
        }
    }
}
