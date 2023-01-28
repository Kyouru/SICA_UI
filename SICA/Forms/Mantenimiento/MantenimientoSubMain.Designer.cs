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
            this.btListas = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.pnTop.Controls.Add(this.panel1);
            this.pnTop.Controls.Add(this.btListas);
            this.pnTop.Controls.Add(this.btUsuarioExterno);
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
            this.btUsuarioExterno.Location = new System.Drawing.Point(0, 0);
            this.btUsuarioExterno.Name = "btUsuarioExterno";
            this.btUsuarioExterno.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btUsuarioExterno.Size = new System.Drawing.Size(205, 45);
            this.btUsuarioExterno.TabIndex = 10;
            this.btUsuarioExterno.Text = "Usuario Externo";
            this.btUsuarioExterno.UseVisualStyleBackColor = false;
            this.btUsuarioExterno.Click += new System.EventHandler(this.btUsuarioExterno_Click);
            // 
            // btListas
            // 
            this.btListas.BackColor = System.Drawing.Color.MidnightBlue;
            this.btListas.Dock = System.Windows.Forms.DockStyle.Left;
            this.btListas.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btListas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btListas.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btListas.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btListas.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btListas.IconColor = System.Drawing.Color.Gainsboro;
            this.btListas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btListas.IconSize = 30;
            this.btListas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btListas.Location = new System.Drawing.Point(205, 0);
            this.btListas.Name = "btListas";
            this.btListas.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btListas.Size = new System.Drawing.Size(126, 45);
            this.btListas.TabIndex = 13;
            this.btListas.Text = "Listas";
            this.btListas.UseVisualStyleBackColor = false;
            this.btListas.Click += new System.EventHandler(this.btListas_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(331, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(717, 1);
            this.panel1.TabIndex = 14;
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
        private FontAwesome.Sharp.IconButton btUsuarioExterno;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btListas;
    }
}