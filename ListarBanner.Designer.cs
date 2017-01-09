namespace Carteleria_Digital
{
    partial class ListarBanner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListarBanner));
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnEliminarBanner = new System.Windows.Forms.Button();
            this.btnModificarBanner = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnVerContenido = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboTipo = new System.Windows.Forms.ComboBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.fecha2 = new System.Windows.Forms.DateTimePicker();
            this.lblFin = new System.Windows.Forms.Label();
            this.lblInicio = new System.Windows.Forms.Label();
            this.fecha1 = new System.Windows.Forms.DateTimePicker();
            this.comboBusqueda = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(486, 360);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(109, 23);
            this.btnSalir.TabIndex = 8;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.BTNSalir);
            // 
            // btnEliminarBanner
            // 
            this.btnEliminarBanner.Location = new System.Drawing.Point(486, 85);
            this.btnEliminarBanner.Name = "btnEliminarBanner";
            this.btnEliminarBanner.Size = new System.Drawing.Size(109, 23);
            this.btnEliminarBanner.TabIndex = 7;
            this.btnEliminarBanner.Text = "Eliminar Banner";
            this.btnEliminarBanner.UseVisualStyleBackColor = true;
            this.btnEliminarBanner.Click += new System.EventHandler(this.btnEliminarBanner_Click);
            // 
            // btnModificarBanner
            // 
            this.btnModificarBanner.Location = new System.Drawing.Point(486, 56);
            this.btnModificarBanner.Name = "btnModificarBanner";
            this.btnModificarBanner.Size = new System.Drawing.Size(109, 23);
            this.btnModificarBanner.TabIndex = 6;
            this.btnModificarBanner.Text = "Modificar Banner";
            this.btnModificarBanner.UseVisualStyleBackColor = true;
            this.btnModificarBanner.Click += new System.EventHandler(this.btnModificarBanner_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(21, 27);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(430, 356);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.TabStop = false;
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            // 
            // btnVerContenido
            // 
            this.btnVerContenido.Location = new System.Drawing.Point(486, 27);
            this.btnVerContenido.Name = "btnVerContenido";
            this.btnVerContenido.Size = new System.Drawing.Size(109, 23);
            this.btnVerContenido.TabIndex = 9;
            this.btnVerContenido.Text = "Ver Contenido";
            this.btnVerContenido.UseVisualStyleBackColor = true;
            this.btnVerContenido.Click += new System.EventHandler(this.btnVerContenido_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboTipo);
            this.groupBox1.Controls.Add(this.btnFiltrar);
            this.groupBox1.Controls.Add(this.fecha2);
            this.groupBox1.Controls.Add(this.lblFin);
            this.groupBox1.Controls.Add(this.lblInicio);
            this.groupBox1.Controls.Add(this.fecha1);
            this.groupBox1.Controls.Add(this.comboBusqueda);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(467, 114);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(156, 206);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Búsqueda por";
            // 
            // comboTipo
            // 
            this.comboTipo.FormattingEnabled = true;
            this.comboTipo.Location = new System.Drawing.Point(31, 54);
            this.comboTipo.Name = "comboTipo";
            this.comboTipo.Size = new System.Drawing.Size(97, 21);
            this.comboTipo.TabIndex = 6;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(31, 168);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(83, 23);
            this.btnFiltrar.TabIndex = 5;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // fecha2
            // 
            this.fecha2.Location = new System.Drawing.Point(6, 133);
            this.fecha2.Name = "fecha2";
            this.fecha2.Size = new System.Drawing.Size(144, 20);
            this.fecha2.TabIndex = 4;
            // 
            // lblFin
            // 
            this.lblFin.AutoSize = true;
            this.lblFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFin.Location = new System.Drawing.Point(53, 117);
            this.lblFin.Name = "lblFin";
            this.lblFin.Size = new System.Drawing.Size(40, 13);
            this.lblFin.TabIndex = 3;
            this.lblFin.Text = "Hasta";
            // 
            // lblInicio
            // 
            this.lblInicio.AutoSize = true;
            this.lblInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInicio.Location = new System.Drawing.Point(53, 78);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Size = new System.Drawing.Size(43, 13);
            this.lblInicio.TabIndex = 2;
            this.lblInicio.Text = "Desde";
            // 
            // fecha1
            // 
            this.fecha1.Location = new System.Drawing.Point(6, 94);
            this.fecha1.Name = "fecha1";
            this.fecha1.Size = new System.Drawing.Size(144, 20);
            this.fecha1.TabIndex = 1;
            // 
            // comboBusqueda
            // 
            this.comboBusqueda.FormattingEnabled = true;
            this.comboBusqueda.Location = new System.Drawing.Point(31, 20);
            this.comboBusqueda.Name = "comboBusqueda";
            this.comboBusqueda.Size = new System.Drawing.Size(97, 21);
            this.comboBusqueda.TabIndex = 0;
            this.comboBusqueda.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // ListarBanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 398);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnVerContenido);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnEliminarBanner);
            this.Controls.Add(this.btnModificarBanner);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ListarBanner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Banners";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ListarBanner_FormClosed);
            this.Load += new System.EventHandler(this.ListarBanner_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnEliminarBanner;
        private System.Windows.Forms.Button btnModificarBanner;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnVerContenido;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.DateTimePicker fecha2;
        private System.Windows.Forms.Label lblFin;
        private System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.DateTimePicker fecha1;
        private System.Windows.Forms.ComboBox comboBusqueda;
        private System.Windows.Forms.ComboBox comboTipo;
    }
}