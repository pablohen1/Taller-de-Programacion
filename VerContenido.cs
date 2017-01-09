using System;
using System.Windows.Forms;

namespace Carteleria_Digital
{
    public partial class VerContenido : Form
    {
        /// <summary>
        /// Muestra el contenido de un banner entrante.
        /// </summary>
        /// <param name="contb"></param>
        public VerContenido(ContenidoBanner contb)
        {
            InitializeComponent();           

            switch (contb.tipo)
            { //Segun el tipo de banner, oculta o muestra controles.
               case 1:
                    {
                        lblTipo.Text = TipoFuente.TextoFijo.ToString();
                        TextoFijo unTXT = (TextoFijo)contb;
                        boxTexto.Text = unTXT.texto;
                        tituloURL.Hide();
                        lblUrl.Hide();
                    }
                    break;

                case 0:
                    {
                        lblTipo.Text = TipoFuente.Rss.ToString();
                        RSS unrss = (RSS)contb;
                        lblUrl.Text = unrss.texto;
                        boxTexto.Text = unrss.descripcion;
                        tituloTexto.Text = "Descripcion";                       
                    }
                    break;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {   //Cierra la ventana el presionar la tecla Escape.
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);
            return res;
        }

        private void VerContenido_Load(object sender, EventArgs e)
        {   //Se realizan ajustes de visualizacion el iniciar.
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void btnCerrar(object sender, EventArgs e)
        {   //Se cierra la ventana al presionar en Cerrar.
            Close();
        }
    }
}
