namespace SICA.Forms.Entregar
{
    partial class EntregarSubMain
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
            this.pnTop = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnSubMain = new System.Windows.Forms.Panel();
            this.btDocumento = new FontAwesome.Sharp.IconButton();
            this.btExpediente = new FontAwesome.Sharp.IconButton();
            this.btMasivo = new FontAwesome.Sharp.IconButton();
            this.pnTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnTop
            // 
            this.pnTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.pnTop.Controls.Add(this.btMasivo);
            this.pnTop.Controls.Add(this.btExpediente);
            this.pnTop.Controls.Add(this.btDocumento);
            this.pnTop.Controls.Add(this.panel1);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1048, 44);
            this.pnTop.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1048, 1);
            this.panel1.TabIndex = 8;
            // 
            // pnSubMain
            // 
            this.pnSubMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnSubMain.Location = new System.Drawing.Point(0, 44);
            this.pnSubMain.Name = "pnSubMain";
            this.pnSubMain.Size = new System.Drawing.Size(1048, 564);
            this.pnSubMain.TabIndex = 1;
            // 
            // btDocumento
            // 
            this.btDocumento.BackColor = System.Drawing.Color.MidnightBlue;
            this.btDocumento.Dock = System.Windows.Forms.DockStyle.Left;
            this.btDocumento.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btDocumento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDocumento.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDocumento.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btDocumento.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btDocumento.IconColor = System.Drawing.Color.Gainsboro;
            this.btDocumento.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btDocumento.IconSize = 30;
            this.btDocumento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDocumento.Location = new System.Drawing.Point(0, 0);
            this.btDocumento.Name = "btDocumento";
            this.btDocumento.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btDocumento.Size = new System.Drawing.Size(140, 43);
            this.btDocumento.TabIndex = 10;
            this.btDocumento.Text = "Documentos";
            this.btDocumento.UseVisualStyleBackColor = false;
            this.btDocumento.Click += new System.EventHandler(this.btDocumento_Click);
            // 
            // btExpediente
            // 
            this.btExpediente.BackColor = System.Drawing.Color.MidnightBlue;
            this.btExpediente.Dock = System.Windows.Forms.DockStyle.Left;
            this.btExpediente.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btExpediente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btExpediente.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExpediente.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btExpediente.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btExpediente.IconColor = System.Drawing.Color.Gainsboro;
            this.btExpediente.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btExpediente.IconSize = 30;
            this.btExpediente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btExpediente.Location = new System.Drawing.Point(140, 0);
            this.btExpediente.Name = "btExpediente";
            this.btExpediente.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btExpediente.Size = new System.Drawing.Size(140, 43);
            this.btExpediente.TabIndex = 11;
            this.btExpediente.Text = "Expedientes";
            this.btExpediente.UseVisualStyleBackColor = false;
            this.btExpediente.Visible = false;
            // 
            // btMasivo
            // 
            this.btMasivo.BackColor = System.Drawing.Color.MidnightBlue;
            this.btMasivo.Dock = System.Windows.Forms.DockStyle.Left;
            this.btMasivo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btMasivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btMasivo.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btMasivo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btMasivo.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btMasivo.IconColor = System.Drawing.Color.Gainsboro;
            this.btMasivo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btMasivo.IconSize = 30;
            this.btMasivo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btMasivo.Location = new System.Drawing.Point(280, 0);
            this.btMasivo.Name = "btMasivo";
            this.btMasivo.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btMasivo.Size = new System.Drawing.Size(140, 43);
            this.btMasivo.TabIndex = 12;
            this.btMasivo.Text = "Masivo";
            this.btMasivo.UseVisualStyleBackColor = false;
            this.btMasivo.Click += new System.EventHandler(this.btMasivo_Click);
            // 
            // EntregarSubMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1048, 608);
            this.Controls.Add(this.pnSubMain);
            this.Controls.Add(this.pnTop);
            this.Name = "EntregarSubMain";
            this.Text = "EntregarSubMain";
            this.pnTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.Panel pnSubMain;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btMasivo;
        private FontAwesome.Sharp.IconButton btExpediente;
        private FontAwesome.Sharp.IconButton btDocumento;
    }
}