using System;
using System.Windows.Forms;

namespace Carteleria_Digital
{
    public partial class AcercaDe : Form
    {   
        /// <summary>
    /// Muestra información del autor de la aplicación.
    /// </summary>
        public AcercaDe()
        {   //Carga el picture box con el logo de la UTN.
            InitializeComponent();
            pictureBox1.Image = Properties.Resources.utn;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AcercaDe_Load(object sender, EventArgs e)
        {   //Ajustes de visualización.
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }
    }
}
