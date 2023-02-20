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
            this.btDepDocDet = new FontAwesome.Sharp.IconButton();
            this.btUsuarioExterno = new FontAwesome.Sharp.IconButton();
            this.btArea = new FontAwesome.Sharp.IconButton();
            this.btPendiente = new FontAwesome.Sharp.IconButton();
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
            this.pnTop.Controls.Add(this.btPendiente);
            this.pnTop.Controls.Add(this.btArea);
            this.pnTop.Controls.Add(this.btDepDocDet);
            this.pnTop.Controls.Add(this.btUsuarioExterno);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1048, 45);
            this.pnTop.TabIndex = 6;
            // 
            // btDepDocDet
            // 
            this.btDepDocDet.BackColor = System.Drawing.Color.MidnightBlue;
            this.btDepDocDet.Dock = System.Windows.Forms.DockStyle.Left;
            this.btDepDocDet.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btDepDocDet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDepDocDet.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDepDocDet.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btDepDocDet.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btDepDocDet.IconColor = System.Drawing.Color.Gainsboro;
            this.btDepDocDet.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btDepDocDet.IconSize = 30;
            this.btDepDocDet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDepDocDet.Location = new System.Drawing.Point(205, 0);
            this.btDepDocDet.Name = "btDepDocDet";
            this.btDepDocDet.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btDepDocDet.Size = new System.Drawing.Size(167, 45);
            this.btDepDocDet.TabIndex = 13;
            this.btDepDocDet.Text = "Dep-Doc-Det";
            this.btDepDocDet.UseVisualStyleBackColor = false;
            this.btDepDocDet.Visible = false;
            this.btDepDocDet.Click += new System.EventHandler(this.btListas_Click);
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
            // btArea
            // 
            this.btArea.BackColor = System.Drawing.Color.MidnightBlue;
            this.btArea.Dock = System.Windows.Forms.DockStyle.Left;
            this.btArea.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btArea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btArea.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btArea.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btArea.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btArea.IconColor = System.Drawing.Color.Gainsboro;
            this.btArea.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btArea.IconSize = 30;
            this.btArea.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btArea.Location = new System.Drawing.Point(372, 0);
            this.btArea.Name = "btArea";
            this.btArea.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btArea.Size = new System.Drawing.Size(114, 45);
            this.btArea.TabIndex = 15;
            this.btArea.Text = "Area";
            this.btArea.UseVisualStyleBackColor = false;
            this.btArea.Visible = false;
            this.btArea.Click += new System.EventHandler(this.btArea_Click);
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
            this.btPendiente.Location = new System.Drawing.Point(486, 0);
            this.btPendiente.Name = "btPendiente";
            this.btPendiente.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btPendiente.Size = new System.Drawing.Size(130, 45);
            this.btPendiente.TabIndex = 16;
            this.btPendiente.Text = "Pendiente";
            this.btPendiente.UseVisualStyleBackColor = false;
            this.btPendiente.Visible = false;
            this.btPendiente.Click += new System.EventHandler(this.btPendiente_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(616, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(432, 1);
            this.panel1.TabIndex = 17;
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
            this.Load += new System.EventHandler(this.MantenimientoSubMain_Load);
            this.pnTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnSubMain;
        private System.Windows.Forms.Panel pnTop;
        private FontAwesome.Sharp.IconButton btUsuarioExterno;
        private FontAwesome.Sharp.IconButton btDepDocDet;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btPendiente;
        private FontAwesome.Sharp.IconButton btArea;
    }
}