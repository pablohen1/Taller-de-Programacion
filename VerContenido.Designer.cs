namespace Carteleria_Digital
{
    partial class VerContenido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerContenido));
            this.label1 = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.tituloTexto = new System.Windows.Forms.Label();
            this.tituloURL = new System.Windows.Forms.Label();
            this.lblUrl = new System.Windows.Forms.Label();
            this.boxTexto = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo";
            // 
            // lblTipo
            // 
            this.lblTipo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(112, 32);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(35, 13);
            this.lblTipo.TabIndex = 1;
            this.lblTipo.Text = "label2";
            // 
            // tituloTexto
            // 
            this.tituloTexto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tituloTexto.AutoSize = true;
            this.tituloTexto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tituloTexto.Location = new System.Drawing.Point(31, 72);
            this.tituloTexto.Name = "tituloTexto";
            this.tituloTexto.Size = new System.Drawing.Size(39, 13);
            this.tituloTexto.TabIndex = 2;
            this.tituloTexto.Text = "Texto";
            // 
            // tituloURL
            // 
            this.tituloURL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tituloURL.AutoSize = true;
            this.tituloURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tituloURL.Location = new System.Drawing.Point(31, 110);
            this.tituloURL.Name = "tituloURL";
            this.tituloURL.Size = new System.Drawing.Size(32, 13);
            this.tituloURL.TabIndex = 4;
            this.tituloURL.Text = "URL";
            // 
            // lblUrl
            // 
            this.lblUrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(112, 110);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(35, 13);
            this.lblUrl.TabIndex = 5;
            this.lblUrl.Text = "label6";
            // 
            // boxTexto
            // 
            this.boxTexto.Cursor = System.Windows.Forms.Cursors.Default;
            this.boxTexto.Location = new System.Drawing.Point(115, 60);
            this.boxTexto.Multiline = true;
            this.boxTexto.Name = "boxTexto";
            this.boxTexto.ReadOnly = true;
            this.boxTexto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.boxTexto.Size = new System.Drawing.Size(172, 37);
            this.boxTexto.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(124, 134);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Cerrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnCerrar);
            // 
            // VerContenido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(311, 169);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.boxTexto);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.tituloURL);
            this.Controls.Add(this.tituloTexto);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "VerContenido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cotenido del Banner";
            this.Load += new System.EventHandler(this.VerContenido_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label tituloTexto;
        private System.Windows.Forms.Label tituloURL;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.TextBox boxTexto;
        private System.Windows.Forms.Button button1;
    }
}