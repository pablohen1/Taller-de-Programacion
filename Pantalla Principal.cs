using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Carteleria_Digital
{
    public partial class Pantalla_Principal : Form
    {   //Definición de variables globales.
        bool detener = false;
        Thread thread1;
        Thread thread2;
        bool fullscreen;
        bool verCursor=false;
        
        public Pantalla_Principal()
        {   //Se inicializan los controles.
            this.Focus();
            InitializeComponent();
            BackColor= (Color)Properties.Settings.Default["colorFondo"];
            this.KeyDown += new KeyEventHandler(this.teclaPresionada);
            menuStrip1.Visible = false;
            //Definición de los atajos de teclado.
            agregarBannersToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.B;
            agregarCampañaToolStripMenuItem1.ShortcutKeys = Keys.Control | Keys.C;
            listaDeBannersToolStripMenuItem1.ShortcutKeys = Keys.Control | Keys.L;
            listaDeCampañasToolStripMenuItem1.ShortcutKeys = Keys.Control | Keys.P;
            pantallaCompletaToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.W;
            salirToolStripMenuItem1.ShortcutKeys = Keys.Control | Keys.S;
            manualDeUsuarioToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.H;
            configuraciónToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.F;
        }

        private void teclaPresionada(object sender, KeyEventArgs e)
        {   // Oculta/Muestra el cursor y la barrar de control adminstrativo al presionar la tecla F1.
            if (e.KeyCode == Keys.F1)
            {
                ocultarControles();
            }

            //Oculta la barra al presionar Escape.
            if ((e.KeyCode == Keys.Escape)&& (menuStrip1.Visible))
            {
                Cursor.Hide(); verCursor = false;
                    menuStrip1.Visible = false;            
            }
        }

        private void Pantalla_Principal_Load(object sender, EventArgs e)
        {
            //Inicia la aplicacion en pantalla completa.
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.pantallaCompletaToolStripMenuItem.Text = "Cambiar a Ventana";
            fullscreen = true;
            Cursor.Hide();
            //Se inician 2 hilos correspondientes a las campañas y banners
            thread1 = new Thread(new ThreadStart(SliderCampaña));
            thread2 = new Thread(new ThreadStart(SliderBanners));
            thread1.Start();
            thread1.Priority = ThreadPriority.Normal;
            thread2.Start();
            thread2.Priority = ThreadPriority.Normal;
        }

        //Metodo asincrono correspondiente a la visualizacion de Campañas.
        private async void SliderCampaña()
        {   //Se le solicitan todas las campañas a la clase Controlador
            List<Imagen> IMGcampañas = Controlador.obtenerImagenesCampañas();
            //Se itera sobre la lista de imagenes y se las va cargando periodicamente a un picturebox
            while (detener != true) {
                if (IMGcampañas != null)
                {
                    foreach (Imagen img in IMGcampañas)
                    {
                        try
                        {
                            Image imagen = Image.FromFile(img.ubicacionImagen);
                            pictureBox1.Image = imagen;
                        }
                        catch {
                            //Si no puede acceder a la imagen de la ubicacion, carga una imagen de error.
                            pictureBox1.Image = Properties.Resources.noImagen; 

                        }
                        await Task.Delay(1000 * img.duracion);
                    }
                }
                //Al finalizar la lista, vuelve a cargarla con nuevas imágenes correspondientes a la fecha y hora actual.
                IMGcampañas = Controlador.obtenerImagenesCampañas();
            }
        }

        //Metodo correspondiente a la visualizacion de Banners.
        private void SliderBanners()
        { 
            string caracterTemporal = string.Empty;
            string textoTemporal = string.Empty;
            while (!detener) {
                string elTexto = generarCadenaDeBanners();
                textoTemporal = "                                                                                                                                                                               " + elTexto;
                //Se le solicita a la clase controlador el banner actual y se lo va recortando para dar el efecto deslizante
                for (int i = 0; i < textoTemporal.Length; i++)
                {
                    caracterTemporal = textoTemporal.Substring(0, 1);
                    textoTemporal = textoTemporal.Remove(0, 1) + caracterTemporal;
                    textoBanner.Invoke(new ScrollEnTxtBox(this.ActualizarTextBox), new object[] { textoTemporal });
                    Thread.Sleep((int)Properties.Settings.Default["velocidadBanner"]);
                }
                elTexto = generarCadenaDeBanners();
            }
        }

        public delegate void ScrollEnTxtBox(string t);
        string elTexto = generarCadenaDeBanners();

        //Actualiza el string del banner.
        private void ActualizarTextBox(string m_text)
	    {   
            textoBanner.Text = m_text;
	    }

        //Genera la cadena con todos los banners correspondientes a la hora y fecha actual.
        private static string generarCadenaDeBanners()
        {
            string laCadena = " ";
            //Obtiene una lista de textos correspondientes a los banners que se deben mostrar en ese momento.
            List<string> losBanners = Controlador.obtenerBannersActuales();

            foreach (var i in losBanners)
            {   //Se aplica un separador entre cada banner.
                laCadena = laCadena + "     |     " + i;
            }

            return laCadena;
        }

        //Lama al winform AgregarCampaña
        private void agregarCampañaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Agregar_campaña_a_pantalla camp1 = new Agregar_campaña_a_pantalla();
            camp1.ShowDialog();
        }

        //Llama al winform AgregarBanner
        private void agregarBannersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarBanner banner1 = new AgregarBanner();
            banner1.ShowDialog();
        }

        //Llama al winform ListarCampañas
        private void listaDeCampañasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ListarCampañas listaC = new ListarCampañas();
            listaC.ShowDialog();
        }

        //Llama al winform ListarCampañas
        private void listaDeBannersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ListarBanner bnrs = new ListarBanner();
            bnrs.ShowDialog();
        }

        //Alterna entre pantalla completa/ventana
        private void pantallaCompletaToolStripMenuItem_Click(object sender, EventArgs e)
        {
                fullscreen = !fullscreen;
          
                if (fullscreen)
                {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                this.pantallaCompletaToolStripMenuItem.Text = "Cambiar a Ventana";
                 }
                else
                {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Normal;
                this.pantallaCompletaToolStripMenuItem.Text = "Cambiar a Pantalla Completa";
                }
        }

        //Al cerrar la ventana con el boton "X", tambien se terminan los hilos.
        private void Pantalla_Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            thread1.Abort();
            thread2.Abort();
        }

        //Llama al winform AcercaDe, con los datos del autor
        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AcercaDe acd = new AcercaDe();
            acd.Show();
        }

        //Abre el manual de usuario de la aplicación.
        private void manualDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {   //obtiene la ruta donde se encuentra almacenada la ayuda
            string ruta = Directory.GetCurrentDirectory() + "\\Manual de Usuario de Carteleria Digital.chm";

            try
            {
                //Se verifica si el archivo existe
                if (!File.Exists(ruta))
                {
                    var data = Properties.Resources.Manual_de_Usuario_de_Carteleria_Digital;
                    using (var stream = new FileStream("Manual de Usuario de Carteleria Digital.chm", FileMode.Create))
                    {
                        stream.Write(data, 0, data.Count());
                        stream.Flush();
                    }
                }
            }
            catch
            {

            }

            if (verCursor==false) { ocultarControles(); }
                        
            Help.ShowHelp(this, ruta);
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ocultarControles()
        {
            if (verCursor)
            {
                Cursor.Hide(); verCursor = !verCursor;
            }
            else
            {
                Cursor.Show(); verCursor = !verCursor;
            }

            menuStrip1.Visible = !menuStrip1.Visible;
        }

        private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var config = new Configuración())
            {
                var resultado = config.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    BackColor = (Color)Properties.Settings.Default["colorFondo"];
                }
            }
        }
    }
}
