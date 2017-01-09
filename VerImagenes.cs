using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Carteleria_Digital
{
    public partial class VerImagenes : Form
    {   //Se inicializan variables globales.
        public int idCamp;
        private List<Imagen> imageneS = new List<Imagen>();
        private Campaña laCampaña = new Campaña();
        private ImageList imageList = new ImageList();

        /// <summary>
        /// Muestra las imágenes de la Campaña que coincide con el ID entrante.
        /// </summary>
        /// <param name="Idcmp"></param>
        public VerImagenes(int Idcmp)
        {    //Inicializa la ventana y carga las imágenes de la campaña.
            this.Focus();
            this.idCamp = Idcmp;
            InitializeComponent();
            obtenerCampaña();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {   //Cierra la ventana si se presiona la tecla Escape.
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);
            return res;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {   //Cierra la ventana si se presiona en "Cerrar".
            this.Close();
        }

        private void obtenerCampaña()
        {   //Obtiene la campaña que coincida con el ID ingresado y carga las imágenes al ListView.
            Campaña cmp = Controlador.obtenerCampaña(idCamp);

            if (cmp.campañaID == idCamp)
            {              
                imageneS = cmp.imagens.ToList();

                this.listView1.Items.Clear();
                foreach (Imagen img in imageneS)
                {
                    Image fotoEntrante;
                    this.listView1.Clear();

                    try
                    {
                       fotoEntrante = Image.FromFile(img.ubicacionImagen);
                    }
                    catch
                    {
                        //Si no puede acceder a la imagen de la ubicacion, carga una imagen de error.
                        fotoEntrante = Properties.Resources.noImagen;

                    }

                    imageList.Images.Add(fotoEntrante);
                    imageList.ImageSize = new Size(256, 256);
                    this.listView1.View = View.LargeIcon;

                    for (int counter = 0; counter < imageList.Images.Count; counter++)
                    {
                        ListViewItem item = new ListViewItem();
                        item.ImageIndex = counter;
                        this.listView1.Items.Add(item);
                    }
                }
                this.listView1.LargeImageList = imageList;
                listView1.LargeImageList.ColorDepth = ColorDepth.Depth16Bit;
              
                button1.Enabled = true;
            }
        }

        private void VerImagenes_Load(object sender, EventArgs e)
        {   //Se realizan ajustes de visualizacion de la ventana.       
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }
    }
}
