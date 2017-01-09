using System;
using System.Drawing;
using System.Windows.Forms;

namespace Carteleria_Digital
{
    public partial class Configuración : Form
    {
        Color color1;

        /// <summary>
        /// Perite realizar configuraciones al sistema.
        /// </summary>
        public Configuración()
        {   //Se cargan las configuraciones actuales del usuario y se hacen ajustes de visualización.
            InitializeComponent();
            pictureBox1.BackColor = (Color)Properties.Settings.Default["colorFondo"];
            boxIntervalo.Text= ((int)Properties.Settings.Default["intervaloPorDefecto"]).ToString();
            boxVelocidad.Text = ((int)Properties.Settings.Default["velocidadBanner"]).ToString();
            Cursor.Show();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {   //Al presionar en el pictureBox se abre la ventana de selección de color.
            DialogResult result = colorDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                color1 = colorDialog1.Color;
                pictureBox1.BackColor = color1;             
            }
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

        private void button1_Click(object sender, EventArgs e)
        {   //Si todos los datos son correctos, se cargan las nuevas configuraciones.
            try
            {
                if (int.Parse(boxIntervalo.Text) > 0 && int.Parse(boxVelocidad.Text) > 0)
                {
                    try
                    {   
                        Properties.Settings.Default["colorFondo"] = (Color)pictureBox1.BackColor;
                        Properties.Settings.Default["intervaloPorDefecto"] = int.Parse(boxIntervalo.Text);
                        Properties.Settings.Default["velocidadBanner"] = int.Parse(boxVelocidad.Text);
                        this.DialogResult = DialogResult.OK;
                        Properties.Settings.Default.Save();
                        this.Close();
                    }
                    catch { MessageBox.Show("Valor del Intervalo o Velocidad demaciado grandes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else { MessageBox.Show("No puede haber valores nulos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            catch { MessageBox.Show("Datos inválidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Configuración_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cursor.Hide();
        }
    }
}
