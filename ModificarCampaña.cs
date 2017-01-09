using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Carteleria_Digital
{
    public partial class ModificarCampaña : Form
    {   //Se inicializan variables globales.
        public int idCamp;
        private List<Imagen> imageneS = new List<Imagen>();
        private Campaña laCampaña = new Campaña();
        private ImageList imageList = new ImageList();
        private OpenFileDialog dlg = new OpenFileDialog();

        /// <summary>
        /// Permite modificar una Campaña entrante.
        /// </summary>
        /// <param name="cmpID"></param>
        public ModificarCampaña(int cmpID)
        {   //Se realizan ajustes de visualizacion y se cargan variables.
            this.idCamp = cmpID;
            InitializeComponent();
            listView1.AutoArrange = true;
            dtHINI.Format = DateTimePickerFormat.Time;
            dtHINI.ShowUpDown = true;
            dtHINI.CustomFormat = "hh:mm";
            dtHFIN.Format = DateTimePickerFormat.Time;
            dtHFIN.ShowUpDown = true;
            dtFINI.CustomFormat = "hh:mm";
            btnBorrarImagen.Enabled = false;
            obtenerCampaña();
            tBoxduracion.Text = ((int)Properties.Settings.Default["intervaloPorDefecto"]).ToString();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {   //Se cierra la ventana al presionar la tecla Escape.
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);
            return res;
        }

        private void obtenerCampaña()
        {   //Se cargan los controles de la ventana con los datos de la campaña a modificar entrante.
                    Campaña cmp = Controlador.obtenerCampaña(idCamp);
                    
                    laCampaña = cmp;

                    dtFFIN.Value = new DateTime(cmp.fechaFinal.Year, cmp.fechaFinal.Month, cmp.fechaFinal.Day, 0, 0, 0);
                    dtFINI.Value = new DateTime(cmp.fechaInicial.Year, cmp.fechaInicial.Month, cmp.fechaInicial.Day, 0, 0, 0);
                    dtHFIN.Value = new DateTime(cmp.horaFinal.Year, cmp.horaFinal.Month, cmp.horaFinal.Day, cmp.horaFinal.Hour, cmp.horaFinal.Minute, cmp.horaFinal.Second);
                    dtHINI.Value = new DateTime(cmp.horaInicial.Year, cmp.horaInicial.Month, cmp.horaInicial.Day, cmp.horaInicial.Hour, cmp.horaInicial.Minute, cmp.horaInicial.Second);

                    imageneS = cmp.imagens.ToList();

                    this.listView1.Items.Clear();
                    foreach (Imagen img in imageneS)
                    {
                        this.listView1.Clear();

                    Image fotoEntrante;
                    try
                    {   //Intenta cargar la imagen desde la ruta indicada
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
                        //Prepara los indices de la lista.
                        for (int counter = 0; counter < imageList.Images.Count; counter++)
                        { 
                            ListViewItem item = new ListViewItem();
                            item.ImageIndex = counter;
                            this.listView1.Items.Add(item);
                        }                      
                    }
                    //Carga la lista de imagenes al listview.
                this.listView1.LargeImageList = imageList;
                listView1.LargeImageList.ColorDepth = ColorDepth.Depth16Bit;            
                btnAgImg.Enabled = true;                  
                          
        }

        private void ModificarCampaña_Load(object sender, EventArgs e)
        {   //Se realizan ajustes de visualizacion.
            btnAgImg.Enabled = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;           
        }

        private void botonModificar(object sender, EventArgs e)
        {   //Se modifican los valores de la campaña entrante.
            //Se verifica que exista almenos 1 imagen adjunta en la campaña.
            if (imageneS.Count() > 0)
            {   //Se realizan verificaciones de los datos ingresados.
                if ((dtFFIN.Value > dtFINI.Value)||(dtFFIN.Value.Equals(dtFINI.Value)))
                {
                    if (dtHFIN.Value > dtHINI.Value)
                    {   //Crea un objeto de tipo campaña, lo carga con los datos del usuario y lo agrega al sistema.
                        laCampaña.imagens = imageneS;
                        laCampaña.fechaInicial = new DateTime(dtFINI.Value.Year, dtFINI.Value.Month, dtFINI.Value.Day, dtFINI.Value.Hour, dtFINI.Value.Minute, dtFINI.Value.Second);
                        laCampaña.fechaFinal = new DateTime(dtFFIN.Value.Year, dtFFIN.Value.Month, dtFFIN.Value.Day, dtFFIN.Value.Hour, dtFFIN.Value.Minute, dtFFIN.Value.Second);
                        laCampaña.horaInicial = new DateTime(dtHINI.Value.Year, dtHINI.Value.Month, dtHINI.Value.Day, dtHINI.Value.Hour, dtHINI.Value.Minute, dtHINI.Value.Second);
                        laCampaña.horaFinal = new DateTime(dtHINI.Value.Year, dtHINI.Value.Month, dtHINI.Value.Day, dtHFIN.Value.Hour, dtHFIN.Value.Minute, dtHFIN.Value.Second);

                        Controlador.modificarCampaña(laCampaña);

                        MessageBox.Show("La campaña se modificó correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Limpia todos los controles.
                        dtFINI.ResetText();
                        dtFFIN.ResetText();
                        dtHINI.ResetText();
                        dtHFIN.ResetText();
                        tBoxduracion.Text = null;
                        pictureBox1.Image = null;
                        listView1.Clear();
                        btnAgImg.Enabled = false;
                        imageneS = null;
                        imageList = null;
                        dlg = null;
                        this.Close();
                    }
                    else { MessageBox.Show("Verifique el intervalo de horas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else { MessageBox.Show("Verifique el intervalo de fechas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else { MessageBox.Show("La campaña debe contener imagenes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnCancelar(object sender, EventArgs e)
        {   //Se cierra la ventana al presioanr en Cancelar.
            this.Close();
        }

        private void btnBorrarImagen_Click(object sender, EventArgs e)
        {   //Se borra la imagen seleccionada en el ListView.
            Int32 pos = listView1.SelectedIndices[0];
            //Se establece el índice de la imágen.
            ListViewItem item = new ListViewItem();
            item.ImageIndex = pos;
            //Se eleimina la imágen de la posicion.
            imageList.Images.RemoveAt(pos);
            imageneS.RemoveAt(pos);
            listView1.Clear();
            //Actualizo los indices.
            for (int counter = 0; counter < imageList.Images.Count; counter++)
            {
                ListViewItem item1 = new ListViewItem();
                item1.ImageIndex = counter;
                this.listView1.Items.Add(item1);
            }
            this.listView1.LargeImageList = imageList;
        }

        private void btnSelecionarImagen(object sender, EventArgs e)
        {   //Permite al usuario elegir una imagen y la carga en el picturebox.
            using (dlg)
            {
                dlg.Title = "Seleccione una imagen";
                dlg.Filter = "Archivos de Imágen (*.jpg, *.jpeg, *.bmp, *.gif, *.png, *.tif)|*.jpg;*.jpeg;*.bmp;*.gif;*.png;*.tif";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(dlg.FileName);
                    btnAgImg.Enabled = true;
                }
            }
        }

        private void btnAgregarImagen(object sender, EventArgs e)
        {   //Incorpora una nueva Imagen a la lista de imagenes con su correspondiente duración.
            if (!dlg.FileName.Equals("")) {
                try
                {
                    if (Convert.ToInt16(tBoxduracion.Text) > 0)
                    {
                        this.listView1.Items.Clear();
                        //Carga la imagen desde la ruta y de la un formato, luego la agrega la lista de img.
                        Image fotoEntrante = Image.FromFile(dlg.FileName);
                        imageList.Images.Add(fotoEntrante);
                        imageList.ImageSize = new Size(256, 256);

                        this.listView1.View = View.LargeIcon;
                        //Arma los indices del listview.
                        for (int counter = 0; counter < imageList.Images.Count; counter++)
                        {
                            ListViewItem item = new ListViewItem();
                            item.ImageIndex = counter;
                            this.listView1.Items.Add(item);
                        }
                        //Carga la lista de imagenes al listview
                        imageList.ColorDepth = ColorDepth.Depth16Bit;
                        this.listView1.LargeImageList = imageList;
                        //Carga el objeto de tipo imagen con los datos del usuario.
                        Imagen imagen1 = new Imagen();
                        imagen1.duracion = Convert.ToInt16(tBoxduracion.Text);
                        imagen1.ubicacionImagen = dlg.FileName;
                        dlg.FileName = "";
                        //Lo agrega a la lista de imagenes de la campaña y vacia el picturebox.
                        imageneS.Add(imagen1);
                        pictureBox1.Image = null;
                        pictureBox1.Update();
                        btnAgImg.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("El campo duración debe ser mayor a cero.", "Error");
                    }
                }
                catch
                {
                    MessageBox.Show("El campo duración tiene un valor inválido.", "Error");
                }
            }
            else
            {
                MessageBox.Show("El campo de la imagen no puede estar vacio.", "Error");
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {   //Si se selecciono una imagen, activa el boton Borrar imagen.
            if (listView1.SelectedIndices.Count != 0)
            { btnBorrarImagen.Enabled = true; }
            else { btnBorrarImagen.Enabled = false; }
        }

        private void btnLimpiarContenido_Click(object sender, EventArgs e)
        {   //Limpia el ListView de todas las imagenes cargadas.
            imageList.Dispose();
            imageneS.Clear();
            listView1.LargeImageList = null;
            listView1.Clear();
        }
    }
}
