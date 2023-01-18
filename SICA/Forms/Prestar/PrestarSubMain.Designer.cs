namespace SICA.Forms.Prestar
{
    partial class PrestarSubMain
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btPrestar = new FontAwesome.Sharp.IconButton();
            this.btRecibir = new FontAwesome.Sharp.IconButton();
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
            this.pnTop.Controls.Add(this.btRecibir);
            this.pnTop.Controls.Add(this.panel1);
            this.pnTop.Controls.Add(this.btPrestar);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1048, 45);
            this.pnTop.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(140, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(908, 1);
            this.panel1.TabIndex = 8;
            // 
            // btPrestar
            // 
            this.btPrestar.BackColor = System.Drawing.Color.MidnightBlue;
            this.btPrestar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btPrestar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btPrestar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPrestar.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPrestar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btPrestar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btPrestar.IconColor = System.Drawing.Color.Gainsboro;
            this.btPrestar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btPrestar.IconSize = 30;
            this.btPrestar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPrestar.Location = new System.Drawing.Point(0, 0);
            this.btPrestar.Name = "btPrestar";
            this.btPrestar.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btPrestar.Size = new System.Drawing.Size(140, 45);
            this.btPrestar.TabIndex = 4;
            this.btPrestar.Text = "Prestar";
            this.btPrestar.UseVisualStyleBackColor = false;
            this.btPrestar.Click += new System.EventHandler(this.btPrestar_Click);
            // 
            // btRecibir
            // 
            this.btRecibir.BackColor = System.Drawing.Color.MidnightBlue;
            this.btRecibir.Dock = System.Windows.Forms.DockStyle.Left;
            this.btRecibir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btRecibir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRecibir.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRecibir.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btRecibir.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btRecibir.IconColor = System.Drawing.Color.Gainsboro;
            this.btRecibir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btRecibir.IconSize = 30;
            this.btRecibir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btRecibir.Location = new System.Drawing.Point(140, 0);
            this.btRecibir.Name = "btRecibir";
            this.btRecibir.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btRecibir.Size = new System.Drawing.Size(140, 44);
            this.btRecibir.TabIndex = 9;
            this.btRecibir.Text = "Recibir";
            this.btRecibir.UseVisualStyleBackColor = false;
            this.btRecibir.Click += new System.EventHandler(this.btRecibir_Click);
            // 
            // PrestarSubMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1048, 608);
            this.Controls.Add(this.pnSubMain);
            this.Controls.Add(this.pnTop);
            this.Name = "PrestarSubMain";
            this.Text = "MantenimientoSubMain";
            this.pnTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnSubMain;
        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btPrestar;
        private FontAwesome.Sharp.IconButton btRecibir;
    }
}