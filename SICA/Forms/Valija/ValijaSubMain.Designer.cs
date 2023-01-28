namespace SICA.Forms.Recibir
{
    partial class ValijaSubMain
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
            this.btTransicion = new FontAwesome.Sharp.IconButton();
            this.btValija = new FontAwesome.Sharp.IconButton();
            this.btNuevo = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnSubMain
            // 
            this.pnSubMain.BackColor = System.Drawing.Color.MidnightBlue;
            this.pnSubMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnSubMain.Location = new System.Drawing.Point(0, 45);
            this.pnSubMain.Name = "pnSubMain";
            this.pnSubMain.Size = new System.Drawing.Size(1048, 563);
            this.pnSubMain.TabIndex = 3;
            // 
            // pnTop
            // 
            this.pnTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.pnTop.Controls.Add(this.panel1);
            this.pnTop.Controls.Add(this.btTransicion);
            this.pnTop.Controls.Add(this.btValija);
            this.pnTop.Controls.Add(this.btNuevo);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1048, 45);
            this.pnTop.TabIndex = 2;
            // 
            // btTransicion
            // 
            this.btTransicion.BackColor = System.Drawing.Color.MidnightBlue;
            this.btTransicion.Dock = System.Windows.Forms.DockStyle.Left;
            this.btTransicion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btTransicion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btTransicion.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTransicion.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btTransicion.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btTransicion.IconColor = System.Drawing.Color.Gainsboro;
            this.btTransicion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btTransicion.IconSize = 30;
            this.btTransicion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btTransicion.Location = new System.Drawing.Point(280, 0);
            this.btTransicion.Name = "btTransicion";
            this.btTransicion.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btTransicion.Size = new System.Drawing.Size(140, 45);
            this.btTransicion.TabIndex = 10;
            this.btTransicion.Text = "Transicion";
            this.btTransicion.UseVisualStyleBackColor = false;
            this.btTransicion.Click += new System.EventHandler(this.btTransicion_Click);
            // 
            // btValija
            // 
            this.btValija.BackColor = System.Drawing.Color.MidnightBlue;
            this.btValija.Dock = System.Windows.Forms.DockStyle.Left;
            this.btValija.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btValija.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btValija.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btValija.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btValija.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btValija.IconColor = System.Drawing.Color.Gainsboro;
            this.btValija.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btValija.IconSize = 30;
            this.btValija.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btValija.Location = new System.Drawing.Point(140, 0);
            this.btValija.Name = "btValija";
            this.btValija.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btValija.Size = new System.Drawing.Size(140, 45);
            this.btValija.TabIndex = 5;
            this.btValija.Text = "Valija";
            this.btValija.UseVisualStyleBackColor = false;
            this.btValija.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btNuevo
            // 
            this.btNuevo.BackColor = System.Drawing.Color.MidnightBlue;
            this.btNuevo.Dock = System.Windows.Forms.DockStyle.Left;
            this.btNuevo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btNuevo.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNuevo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btNuevo.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btNuevo.IconColor = System.Drawing.Color.Gainsboro;
            this.btNuevo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btNuevo.IconSize = 30;
            this.btNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btNuevo.Location = new System.Drawing.Point(0, 0);
            this.btNuevo.Name = "btNuevo";
            this.btNuevo.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btNuevo.Size = new System.Drawing.Size(140, 45);
            this.btNuevo.TabIndex = 4;
            this.btNuevo.Text = "Nuevo";
            this.btNuevo.UseVisualStyleBackColor = false;
            this.btNuevo.Click += new System.EventHandler(this.btNuevo_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(420, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(628, 1);
            this.panel1.TabIndex = 11;
            // 
            // ValijaSubMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1048, 608);
            this.Controls.Add(this.pnSubMain);
            this.Controls.Add(this.pnTop);
            this.Name = "ValijaSubMain";
            this.Text = "RecibirSubMain";
            this.Load += new System.EventHandler(this.RecibirSubMain_Load);
            this.pnTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnSubMain;
        private System.Windows.Forms.Panel pnTop;
        private FontAwesome.Sharp.IconButton btValija;
        private FontAwesome.Sharp.IconButton btNuevo;
        private FontAwesome.Sharp.IconButton btTransicion;
        private System.Windows.Forms.Panel panel1;
    }
}