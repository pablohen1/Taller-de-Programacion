namespace Carteleria_Digital
{
    partial class ListarCampañas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListarCampañas));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnVerimagenes = new System.Windows.Forms.Button();
            this.btnModificarCampaña = new System.Windows.Forms.Button();
            this.btnEliminarCampaña = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(23, 24);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(387, 356);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.TabStop = false;
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            // 
            // btnVerimagenes
            // 
            this.btnVerimagenes.Location = new System.Drawing.Point(456, 24);
            this.btnVerimagenes.Name = "btnVerimagenes";
            this.btnVerimagenes.Size = new System.Drawing.Size(109, 23);
            this.btnVerimagenes.TabIndex = 1;
            this.btnVerimagenes.Text = "Ver imagenes";
            this.btnVerimagenes.UseVisualStyleBackColor = true;
            this.btnVerimagenes.Click += new System.EventHandler(this.btnVerImagenes);
            // 
            // btnModificarCampaña
            // 
            this.btnModificarCampaña.Location = new System.Drawing.Point(456, 53);
            this.btnModificarCampaña.Name = "btnModificarCampaña";
            this.btnModificarCampaña.Size = new System.Drawing.Size(109, 23);
            this.btnModificarCampaña.TabIndex = 2;
            this.btnModificarCampaña.Text = "Modificar Campaña";
            this.btnModificarCampaña.UseVisualStyleBackColor = true;
            this.btnModificarCampaña.Click += new System.EventHandler(this.btnModificarCampaña_Click);
            // 
            // btnEliminarCampaña
            // 
            this.btnEliminarCampaña.Location = new System.Drawing.Point(456, 82);
            this.btnEliminarCampaña.Name = "btnEliminarCampaña";
            this.btnEliminarCampaña.Size = new System.Drawing.Size(109, 23);
            this.btnEliminarCampaña.TabIndex = 3;
            this.btnEliminarCampaña.Text = "Eliminar Campaña";
            this.btnEliminarCampaña.UseVisualStyleBackColor = true;
            this.btnEliminarCampaña.Click += new System.EventHandler(this.btnEliminarCampaña_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(456, 357);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(109, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Salir";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnSalir);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFiltrar);
            this.groupBox1.Controls.Add(this.fecha2);
            this.groupBox1.Controls.Add(this.lblFin);
            this.groupBox1.Controls.Add(this.lblInicio);
            this.groupBox1.Controls.Add(this.fecha1);
            this.groupBox1.Controls.Add(this.comboBusqueda);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(436, 111);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(156, 206);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Búsqueda por";
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
            this.lblFin.Location = new System.Drawing.Point(58, 117);
            this.lblFin.Name = "lblFin";
            this.lblFin.Size = new System.Drawing.Size(40, 13);
            this.lblFin.TabIndex = 3;
            this.lblFin.Text = "Hasta";
            // 
            // lblInicio
            // 
            this.lblInicio.AutoSize = true;
            this.lblInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInicio.Location = new System.Drawing.Point(58, 78);
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
            this.comboBusqueda.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBusqueda.Location = new System.Drawing.Point(31, 20);
            this.comboBusqueda.Name = "comboBusqueda";
            this.comboBusqueda.Size = new System.Drawing.Size(97, 21);
            this.comboBusqueda.TabIndex = 0;
            this.comboBusqueda.SelectedIndexChanged += new System.EventHandler(this.comboBusqueda_SelectedIndexChanged);
            // 
            // ListarCampañas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 402);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnEliminarCampaña);
            this.Controls.Add(this.btnModificarCampaña);
            this.Controls.Add(this.btnVerimagenes);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ListarCampañas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Campañas";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ListarCampañas_FormClosed);
            this.Load += new System.EventHandler(this.ListarCampañas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnVerimagenes;
        private System.Windows.Forms.Button btnModificarCampaña;
        private System.Windows.Forms.Button btnEliminarCampaña;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.DateTimePicker fecha2;
        private System.Windows.Forms.Label lblFin;
        private System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.DateTimePicker fecha1;
        private System.Windows.Forms.ComboBox comboBusqueda;
    }
}