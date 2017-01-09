using System;
using System.Windows.Forms;

namespace Carteleria_Digital
{
    public partial class NuevaFuente : Form
    {/// <summary>
    /// Permite incorporar una nueva fuente RSS.
    /// </summary>
        public NuevaFuente()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {   //Cierra la ventana si se presiona la tecla Escape.
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);
            return res;
        }

        private void btnAgregarRss_Click(object sender, EventArgs e)
        {   //Incorpora el nuevo RSS al sistema con los datos ingresados.
            if (!string.IsNullOrWhiteSpace(textBoxNombre.Text))
            {   
                if (!string.IsNullOrWhiteSpace(textBoxURL.Text))
                {   //Si los datos son validos, crea un nuevo RSS, lo carga con los datos del usuario y lo agrega al sistema.
                    RSS unRss = new RSS();
                    unRss.descripcion = textBoxNombre.Text;
                    unRss.texto = textBoxURL.Text;
                    unRss.tipo = TipoFuente.Rss.GetHashCode();
                    Controlador.agregarRss(unRss);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else { MessageBox.Show("La URL no puede estar vacia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else { MessageBox.Show("La descripción no puede estar vacia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {   //Cierra la ventana al presionar en "Cancelar".
            this.Close();
        }

        private void NuevoRSS_Load(object sender, EventArgs e)
        {   //Se realizan ajustes de visualizacion al iniciar la ventana.
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }
    }
}
