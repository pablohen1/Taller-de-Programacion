namespace Carteleria_Digital
{
    partial class ModificarBanner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModificarBanner));
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.dtHFIN = new System.Windows.Forms.DateTimePicker();
            this.dtHINI = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.comboBoxRSS = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonNuevoRss = new System.Windows.Forms.Button();
            this.buttonEditarRss = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxBanner = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtFFIN = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtFINI = new System.Windows.Forms.DateTimePicker();
            this.chckTexto = new System.Windows.Forms.CheckBox();
            this.chckRSS = new System.Windows.Forms.CheckBox();
            this.btnVerificar = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(651, 273);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 52;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(42, 273);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 53;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // dtHFIN
            // 
            this.dtHFIN.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtHFIN.Location = new System.Drawing.Point(473, 61);
            this.dtHFIN.Name = "dtHFIN";
            this.dtHFIN.Size = new System.Drawing.Size(200, 20);
            this.dtHFIN.TabIndex = 50;
            // 
            // dtHINI
            // 
            this.dtHINI.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtHINI.Location = new System.Drawing.Point(473, 27);
            this.dtHINI.Name = "dtHINI";
            this.dtHINI.Size = new System.Drawing.Size(200, 20);
            this.dtHINI.TabIndex = 49;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(397, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 45;
            this.label3.Text = "Hora inicial";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(471, 26);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(92, 23);
            this.btnEliminar.TabIndex = 35;
            this.btnEliminar.Text = "Eliminar Fuente";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // comboBoxRSS
            // 
            this.comboBoxRSS.FormattingEnabled = true;
            this.comboBoxRSS.Location = new System.Drawing.Point(65, 28);
            this.comboBoxRSS.Name = "comboBoxRSS";
            this.comboBoxRSS.Size = new System.Drawing.Size(165, 21);
            this.comboBoxRSS.TabIndex = 33;
            this.comboBoxRSS.SelectedIndexChanged += new System.EventHandler(this.comboBoxRSS_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(397, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 46;
            this.label4.Text = "Hora Final";
            // 
            // buttonNuevoRss
            // 
            this.buttonNuevoRss.Location = new System.Drawing.Point(252, 26);
            this.buttonNuevoRss.Name = "buttonNuevoRss";
            this.buttonNuevoRss.Size = new System.Drawing.Size(90, 23);
            this.buttonNuevoRss.TabIndex = 0;
            this.buttonNuevoRss.Text = "Nueva Fuente";
            this.buttonNuevoRss.UseVisualStyleBackColor = true;
            this.buttonNuevoRss.Click += new System.EventHandler(this.buttonNuevoRss_Click);
            // 
            // buttonEditarRss
            // 
            this.buttonEditarRss.Location = new System.Drawing.Point(362, 26);
            this.buttonEditarRss.Name = "buttonEditarRss";
            this.buttonEditarRss.Size = new System.Drawing.Size(87, 23);
            this.buttonEditarRss.TabIndex = 34;
            this.buttonEditarRss.Text = "Editar Fuente";
            this.buttonEditarRss.UseVisualStyleBackColor = true;
            this.buttonEditarRss.Click += new System.EventHandler(this.buttonEditarRss_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBoxBanner);
            this.groupBox2.Location = new System.Drawing.Point(42, 106);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(684, 65);
            this.groupBox2.TabIndex = 54;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Texto Fijo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Texto del banner";
            // 
            // textBoxBanner
            // 
            this.textBoxBanner.Location = new System.Drawing.Point(97, 24);
            this.textBoxBanner.Name = "textBoxBanner";
            this.textBoxBanner.Size = new System.Drawing.Size(570, 20);
            this.textBoxBanner.TabIndex = 29;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnVerificar);
            this.groupBox1.Controls.Add(this.btnEliminar);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.comboBoxRSS);
            this.groupBox1.Controls.Add(this.buttonNuevoRss);
            this.groupBox1.Controls.Add(this.buttonEditarRss);
            this.groupBox1.Location = new System.Drawing.Point(42, 187);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(684, 71);
            this.groupBox1.TabIndex = 53;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "RSS";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Fuente";
            // 
            // dtFFIN
            // 
            this.dtFFIN.Location = new System.Drawing.Point(139, 61);
            this.dtFFIN.Name = "dtFFIN";
            this.dtFFIN.Size = new System.Drawing.Size(200, 20);
            this.dtFFIN.TabIndex = 48;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "Fecha Final";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 43;
            this.label1.Text = "Fecha inicial";
            // 
            // dtFINI
            // 
            this.dtFINI.Location = new System.Drawing.Point(139, 27);
            this.dtFINI.Name = "dtFINI";
            this.dtFINI.Size = new System.Drawing.Size(200, 20);
            this.dtFINI.TabIndex = 47;
            // 
            // chckTexto
            // 
            this.chckTexto.AutoSize = true;
            this.chckTexto.Location = new System.Drawing.Point(21, 130);
            this.chckTexto.Name = "chckTexto";
            this.chckTexto.Size = new System.Drawing.Size(15, 14);
            this.chckTexto.TabIndex = 55;
            this.chckTexto.UseVisualStyleBackColor = true;
            this.chckTexto.CheckedChanged += new System.EventHandler(this.chckTexto_CheckedChanged);
            // 
            // chckRSS
            // 
            this.chckRSS.AutoSize = true;
            this.chckRSS.Location = new System.Drawing.Point(21, 213);
            this.chckRSS.Name = "chckRSS";
            this.chckRSS.Size = new System.Drawing.Size(15, 14);
            this.chckRSS.TabIndex = 56;
            this.chckRSS.UseVisualStyleBackColor = true;
            this.chckRSS.CheckedChanged += new System.EventHandler(this.chckRSS_CheckedChanged);
            // 
            // btnVerificar
            // 
            this.btnVerificar.Location = new System.Drawing.Point(579, 25);
            this.btnVerificar.Name = "btnVerificar";
            this.btnVerificar.Size = new System.Drawing.Size(88, 23);
            this.btnVerificar.TabIndex = 36;
            this.btnVerificar.Text = "Verificar fuente";
            this.btnVerificar.UseVisualStyleBackColor = true;
            this.btnVerificar.Click += new System.EventHandler(this.button1_Click);
            // 
            // ModificarBanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 310);
            this.Controls.Add(this.chckRSS);
            this.Controls.Add(this.chckTexto);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.dtHFIN);
            this.Controls.Add(this.dtHINI);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtFFIN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtFINI);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ModificarBanner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar Banner";
            this.Load += new System.EventHandler(this.ModificarBanner_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.DateTimePicker dtHFIN;
        private System.Windows.Forms.DateTimePicker dtHINI;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.ComboBox comboBoxRSS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonNuevoRss;
        private System.Windows.Forms.Button buttonEditarRss;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxBanner;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtFFIN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtFINI;
        private System.Windows.Forms.CheckBox chckTexto;
        private System.Windows.Forms.CheckBox chckRSS;
        private System.Windows.Forms.Button btnVerificar;
    }
}