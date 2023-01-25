namespace SICA.Forms.Mantenimiento
{
    partial class MantenimientoSubMain
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
            this.pnSubMain = new System.Windows.Forms.Panel();
            this.pnTop = new System.Windows.Forms.Panel();
            this.btUsuarioExterno = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btSocio = new FontAwesome.Sharp.IconButton();
            this.btCredito = new FontAwesome.Sharp.IconButton();
            this.pnTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnSubMain
            // 
            this.pnSubMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnSubMain.Location = new System.Drawing.Point(0, 45);
            this.pnSubMain.Name = "pnSubMain";
            this.pnSubMain.Size = new System.Drawing.Size(1048, 563);
            this.pnSubMain.TabIndex = 7;
            // 
            // pnTop
            // 
            this.pnTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.pnTop.Controls.Add(this.btUsuarioExterno);
            this.pnTop.Controls.Add(this.btSocio);
            this.pnTop.Controls.Add(this.btCredito);
            this.pnTop.Controls.Add(this.panel1);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1048, 45);
            this.pnTop.TabIndex = 6;
            // 
            // btUsuarioExterno
            // 
            this.btUsuarioExterno.BackColor = System.Drawing.Color.MidnightBlue;
            this.btUsuarioExterno.Dock = System.Windows.Forms.DockStyle.Left;
            this.btUsuarioExterno.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btUsuarioExterno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btUsuarioExterno.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btUsuarioExterno.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btUsuarioExterno.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btUsuarioExterno.IconColor = System.Drawing.Color.Gainsboro;
            this.btUsuarioExterno.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btUsuarioExterno.IconSize = 30;
            this.btUsuarioExterno.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btUsuarioExterno.Location = new System.Drawing.Point(280, 0);
            this.btUsuarioExterno.Name = "btUsuarioExterno";
            this.btUsuarioExterno.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btUsuarioExterno.Size = new System.Drawing.Size(205, 44);
            this.btUsuarioExterno.TabIndex = 10;
            this.btUsuarioExterno.Text = "Usuario Externo";
            this.btUsuarioExterno.UseVisualStyleBackColor = false;
            this.btUsuarioExterno.Click += new System.EventHandler(this.btUsuarioExterno_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1048, 1);
            this.panel1.TabIndex = 8;
            // 
            // btSocio
            // 
            this.btSocio.BackColor = System.Drawing.Color.MidnightBlue;
            this.btSocio.Dock = System.Windows.Forms.DockStyle.Left;
            this.btSocio.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btSocio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSocio.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSocio.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btSocio.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btSocio.IconColor = System.Drawing.Color.Gainsboro;
            this.btSocio.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btSocio.IconSize = 30;
            this.btSocio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSocio.Location = new System.Drawing.Point(140, 0);
            this.btSocio.Name = "btSocio";
            this.btSocio.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btSocio.Size = new System.Drawing.Size(140, 44);
            this.btSocio.TabIndex = 9;
            this.btSocio.Text = "Socio";
            this.btSocio.UseVisualStyleBackColor = false;
            this.btSocio.Click += new System.EventHandler(this.btSocio_Click);
            // 
            // btCredito
            // 
            this.btCredito.BackColor = System.Drawing.Color.MidnightBlue;
            this.btCredito.Dock = System.Windows.Forms.DockStyle.Left;
            this.btCredito.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btCredito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCredito.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCredito.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btCredito.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btCredito.IconColor = System.Drawing.Color.Gainsboro;
            this.btCredito.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btCredito.IconSize = 30;
            this.btCredito.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCredito.Location = new System.Drawing.Point(0, 0);
            this.btCredito.Name = "btCredito";
            this.btCredito.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btCredito.Size = new System.Drawing.Size(140, 44);
            this.btCredito.TabIndex = 4;
            this.btCredito.Text = "Credito";
            this.btCredito.UseVisualStyleBackColor = false;
            this.btCredito.Click += new System.EventHandler(this.btCredito_Click);
            // 
            // MantenimientoSubMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1048, 608);
            this.Controls.Add(this.pnSubMain);
            this.Controls.Add(this.pnTop);
            this.Name = "MantenimientoSubMain";
            this.Text = "MantenimientoSubMain";
            this.pnTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnSubMain;
        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btSocio;
        private FontAwesome.Sharp.IconButton btCredito;
        private FontAwesome.Sharp.IconButton btUsuarioExterno;
    }
}