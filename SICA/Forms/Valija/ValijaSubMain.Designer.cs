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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btPendiente = new FontAwesome.Sharp.IconButton();
            this.btOK = new FontAwesome.Sharp.IconButton();
            this.btNuevo = new FontAwesome.Sharp.IconButton();
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
            this.pnTop.Controls.Add(this.btPendiente);
            this.pnTop.Controls.Add(this.btOK);
            this.pnTop.Controls.Add(this.btNuevo);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1048, 45);
            this.pnTop.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(420, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(628, 1);
            this.panel1.TabIndex = 8;
            // 
            // btPendiente
            // 
            this.btPendiente.BackColor = System.Drawing.Color.MidnightBlue;
            this.btPendiente.Dock = System.Windows.Forms.DockStyle.Left;
            this.btPendiente.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btPendiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPendiente.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPendiente.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btPendiente.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btPendiente.IconColor = System.Drawing.Color.Gainsboro;
            this.btPendiente.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btPendiente.IconSize = 30;
            this.btPendiente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPendiente.Location = new System.Drawing.Point(280, 0);
            this.btPendiente.Name = "btPendiente";
            this.btPendiente.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btPendiente.Size = new System.Drawing.Size(140, 45);
            this.btPendiente.TabIndex = 9;
            this.btPendiente.Text = "Pendiente";
            this.btPendiente.UseVisualStyleBackColor = false;
            this.btPendiente.Click += new System.EventHandler(this.btPendiente_Click);
            // 
            // btOK
            // 
            this.btOK.BackColor = System.Drawing.Color.MidnightBlue;
            this.btOK.Dock = System.Windows.Forms.DockStyle.Left;
            this.btOK.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOK.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOK.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btOK.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btOK.IconColor = System.Drawing.Color.Gainsboro;
            this.btOK.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btOK.IconSize = 30;
            this.btOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btOK.Location = new System.Drawing.Point(140, 0);
            this.btOK.Name = "btOK";
            this.btOK.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btOK.Size = new System.Drawing.Size(140, 45);
            this.btOK.TabIndex = 5;
            this.btOK.Text = "OK";
            this.btOK.UseVisualStyleBackColor = false;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
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
            // RecibirSubMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1048, 608);
            this.Controls.Add(this.pnSubMain);
            this.Controls.Add(this.pnTop);
            this.Name = "RecibirSubMain";
            this.Text = "RecibirSubMain";
            this.Load += new System.EventHandler(this.RecibirSubMain_Load);
            this.pnTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnSubMain;
        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btOK;
        private FontAwesome.Sharp.IconButton btNuevo;
        private FontAwesome.Sharp.IconButton btPendiente;
    }
}