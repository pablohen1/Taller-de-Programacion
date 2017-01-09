using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Carteleria_Digital
{
    public partial class Agregar_campaña_a_pantalla : Form
    {   //Se inicializan variables globales.
        ImageList imageList = new ImageList();
        OpenFileDialog dlg = new OpenFileDialog();
        List<Imagen> ListIMG = new List<Imagen>();

        /// <summary>
        /// Permite incorporar una nueva Campaña al sistema.
        /// </summary>
        public Agregar_campaña_a_pantalla()
        {   //Inicializa controles y carga de variables.
            this.Focus();
            InitializeComponent();
            dtHINI.Format = DateTimePickerFormat.Time;
            dtHINI.ShowUpDown = true;
            dtHINI.CustomFormat = "hh:mm";
            dtHFIN.Format = DateTimePickerFormat.Time;
            dtHFIN.ShowUpDown = true;
            dtFINI.CustomFormat = "hh:mm";
            btnBorrarImagen.Enabled = false;
            Cursor.Show();
            tBoxduracion.Text = ((int)Properties.Settings.Default["intervaloPorDefecto"]).ToString();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {   //Cierra la venta al presioanr la tecla Escape.
            if (keyData == Keys.Escape)
            { this.Close(); }
            bool res = base.ProcessCmdKey(ref msg, keyData);
            return res;
        }

        private void btnAgregarImagen(object sender, EventArgs e)
        {   //Incorpora una nueva Imagen a la lista de imagenes con su correspondiente duración.                     
            if (!dlg.FileName.Equals(""))
            {
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
                        ListIMG.Add(imagen1);
                        pictureBox1.Image=null;
                        pictureBox1.Update();
                        btnAgImg.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("El campo duración debe ser mayor a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("El campo duración tiene un valor inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("El campo de la imagen no puede estar vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Agregar_campaña_a_pantalla_Load(object sender, EventArgs e)
        {   //Se inicializan variables al cargar la ventana.
            btnAgImg.Enabled = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;           
        }

        private void btnSelecionarImagen(object sender, EventArgs e)
        {   //Permite al usuario elegir una imagen y la carga en el picturebox.     
            using (dlg)
           {
        dlg.Title = "Selecciona una imagen";
        dlg.Filter = "Archivos de Imágen (*.jpg, *.jpeg, *.bmp, *.gif, *.png, *.tif)|*.jpg;*.jpeg;*.bmp;*.gif;*.png;*.tif";

        if (dlg.ShowDialog() == DialogResult.OK)
                 {
                    pictureBox1.Image = Image.FromFile(dlg.FileName);
                    btnAgImg.Enabled = true;
                 }
            }            
        }

        private void btnAgregarCampaña(object sender, EventArgs e)
        {   //Se incorpora una nueva campaña al sistema con los datos ingresados.
            //Se verifica que exista almenos 1 imagen adjunta en la campaña.
            if (ListIMG.Count() > 0)
            {   //Se realizan verificaciones de los datos ingresados.
                DateTime fechI = new DateTime(dtFINI.Value.Year, dtFINI.Value.Month, dtFINI.Value.Day, 0, 0, 0);
                DateTime fechF = new DateTime(dtFFIN.Value.Year, dtFFIN.Value.Month, dtFFIN.Value.Day, 0, 0, 0);

                if (fechF > fechI|| fechF.Equals(fechI))
                {
                    if (dtHFIN.Value > dtHINI.Value)
                    {   //Crea un objeto de tipo campaña, lo carga con los datos del usuario y lo agrega al sistema.
                        Campaña camp1 = new Campaña();
                        camp1.imagens = ListIMG;
                        camp1.fechaInicial = fechI;
                        camp1.fechaFinal = fechF;
                        camp1.horaInicial = new DateTime(dtHINI.Value.Year, dtHINI.Value.Month, dtHINI.Value.Day, dtHINI.Value.Hour, dtHINI.Value.Minute, dtHINI.Value.Second);
                        camp1.horaFinal = new DateTime(dtHFIN.Value.Year, dtHFIN.Value.Month, dtHFIN.Value.Day, dtHFIN.Value.Hour, dtHFIN.Value.Minute, dtHFIN.Value.Second);
                        Controlador.agregarCampaña(camp1);

                        MessageBox.Show("La campaña se agrego correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Limpia todos los campos
                        dtFINI.ResetText();
                        dtFFIN.ResetText();
                        dtHINI.ResetText();
                        dtHFIN.ResetText();
                        tBoxduracion.Text = null;
                        pictureBox1.Image = null;
                        listView1.Clear();
                        btnAgImg.Enabled = false;
                        imageList.Dispose();
                        OpenFileDialog dlg = new OpenFileDialog();
                        ListIMG.Clear();
                    }
                    else { MessageBox.Show("Verifique el intervalo de horas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else { MessageBox.Show("Verifique el intervalo de fechas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else { MessageBox.Show("La campaña debe contener imagenes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnCancelar(object sender, EventArgs e)

        {   //Cierra la ventana al presionar el boton Cancelar.
            this.Close();
        }

        //Se borra la imagen seleccionada en el ListView.  
        private void BTNBorrarImagen(object sender, EventArgs e)
        {   //Se obtiene la posicion del elemento seleccionado.
            Int32 pos = listView1.SelectedIndices[0];
            //Se establece el índice de la imágen.
            ListViewItem item = new ListViewItem();            
            item.ImageIndex = pos;
            //Se eleimina la imágen de la posicion.
            imageList.Images.RemoveAt(pos);
            ListIMG.RemoveAt(pos);
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {   //Al seleccionar una imagen se activa el boton Borrar.
            if (listView1.SelectedIndices.Count != 0)
            { btnBorrarImagen.Enabled = true; }
            else { btnBorrarImagen.Enabled = false; }               
        }

        private void limpiarContenido(object sender, EventArgs e)
        {   //Quita todas las imagenes del ListView.
            imageList.Dispose();
            ListIMG.Clear();
            listView1.LargeImageList = null;
            listView1.Clear();
        }

        private void Agregar_campaña_a_pantalla_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cursor.Hide();
        }
    }

}
