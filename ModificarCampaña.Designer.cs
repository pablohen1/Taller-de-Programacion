namespace Carteleria_Digital
{
    partial class ModificarCampaña
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModificarCampaña));
            this.dtHFIN = new System.Windows.Forms.DateTimePicker();
            this.dtHINI = new System.Windows.Forms.DateTimePicker();
            this.dtFFIN = new System.Windows.Forms.DateTimePicker();
            this.dtFINI = new System.Windows.Forms.DateTimePicker();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupImgs = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button6 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnBorrarImagen = new System.Windows.Forms.Button();
            this.tBoxduracion = new System.Windows.Forms.TextBox();
            this.btnAgImg = new System.Windows.Forms.Button();
            this.groupImgs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dtHFIN
            // 
            this.dtHFIN.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtHFIN.Location = new System.Drawing.Point(404, 57);
            this.dtHFIN.Name = "dtHFIN";
            this.dtHFIN.Size = new System.Drawing.Size(179, 20);
            this.dtHFIN.TabIndex = 36;
            // 
            // dtHINI
            // 
            this.dtHINI.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtHINI.Location = new System.Drawing.Point(404, 23);
            this.dtHINI.Name = "dtHINI";
            this.dtHINI.Size = new System.Drawing.Size(179, 20);
            this.dtHINI.TabIndex = 35;
            // 
            // dtFFIN
            // 
            this.dtFFIN.Location = new System.Drawing.Point(98, 57);
            this.dtFFIN.Name = "dtFFIN";
            this.dtFFIN.Size = new System.Drawing.Size(200, 20);
            this.dtFFIN.TabIndex = 34;
            // 
            // dtFINI
            // 
            this.dtFINI.Location = new System.Drawing.Point(98, 23);
            this.dtFINI.Name = "dtFINI";
            this.dtFINI.Size = new System.Drawing.Size(200, 20);
            this.dtFINI.TabIndex = 33;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(477, 472);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(110, 32);
            this.button4.TabIndex = 32;
            this.button4.Text = "Cancelar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnCancelar);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(29, 472);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(110, 31);
            this.button3.TabIndex = 31;
            this.button3.Text = "Modificar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.botonModificar);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(343, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Hora Final";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(343, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Hora inicial";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Fecha Final";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Fecha inicial";
            // 
            // groupImgs
            // 
            this.groupImgs.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupImgs.Controls.Add(this.button2);
            this.groupImgs.Controls.Add(this.listView1);
            this.groupImgs.Controls.Add(this.pictureBox1);
            this.groupImgs.Controls.Add(this.button6);
            this.groupImgs.Controls.Add(this.label5);
            this.groupImgs.Controls.Add(this.btnBorrarImagen);
            this.groupImgs.Controls.Add(this.tBoxduracion);
            this.groupImgs.Controls.Add(this.btnAgImg);
            this.groupImgs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupImgs.Location = new System.Drawing.Point(29, 83);
            this.groupImgs.Name = "groupImgs";
            this.groupImgs.Size = new System.Drawing.Size(558, 383);
            this.groupImgs.TabIndex = 42;
            this.groupImgs.TabStop = false;
            this.groupImgs.Text = "Imágenes";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(15, 50);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Seleccionar Imagen";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.btnSelecionarImagen);
            // 
            // listView1
            // 
            this.listView1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.listView1.Location = new System.Drawing.Point(15, 126);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(398, 242);
            this.listView1.TabIndex = 40;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(163, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(121, 87);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button6.Location = new System.Drawing.Point(428, 155);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(121, 23);
            this.button6.TabIndex = 21;
            this.button6.Text = "Limpiar Contenido";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.btnLimpiarContenido_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(314, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Duración";
            // 
            // btnBorrarImagen
            // 
            this.btnBorrarImagen.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBorrarImagen.Location = new System.Drawing.Point(428, 126);
            this.btnBorrarImagen.Name = "btnBorrarImagen";
            this.btnBorrarImagen.Size = new System.Drawing.Size(121, 23);
            this.btnBorrarImagen.TabIndex = 20;
            this.btnBorrarImagen.Text = "Borrar Imagen";
            this.btnBorrarImagen.UseVisualStyleBackColor = false;
            this.btnBorrarImagen.Click += new System.EventHandler(this.btnBorrarImagen_Click);
            // 
            // tBoxduracion
            // 
            this.tBoxduracion.Location = new System.Drawing.Point(375, 53);
            this.tBoxduracion.Name = "tBoxduracion";
            this.tBoxduracion.Size = new System.Drawing.Size(41, 20);
            this.tBoxduracion.TabIndex = 10;
            // 
            // btnAgImg
            // 
            this.btnAgImg.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAgImg.Location = new System.Drawing.Point(428, 53);
            this.btnAgImg.Name = "btnAgImg";
            this.btnAgImg.Size = new System.Drawing.Size(121, 23);
            this.btnAgImg.TabIndex = 5;
            this.btnAgImg.Text = "Agregar imagen";
            this.btnAgImg.UseVisualStyleBackColor = false;
            this.btnAgImg.Click += new System.EventHandler(this.btnAgregarImagen);
            // 
            // ModificarCampaña
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 512);
            this.Controls.Add(this.groupImgs);
            this.Controls.Add(this.dtHFIN);
            this.Controls.Add(this.dtHINI);
            this.Controls.Add(this.dtFFIN);
            this.Controls.Add(this.dtFINI);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ModificarCampaña";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar Campaña";
            this.Load += new System.EventHandler(this.ModificarCampaña_Load);
            this.groupImgs.ResumeLayout(false);
            this.groupImgs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dtHFIN;
        private System.Windows.Forms.DateTimePicker dtHINI;
        private System.Windows.Forms.DateTimePicker dtFFIN;
        private System.Windows.Forms.DateTimePicker dtFINI;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupImgs;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnBorrarImagen;
        private System.Windows.Forms.TextBox tBoxduracion;
        private System.Windows.Forms.Button btnAgImg;
    }
}