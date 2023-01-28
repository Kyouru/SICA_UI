namespace SICA.Forms.Pendiente
{
    partial class PendienteSubMain
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
            this.btRegularizar = new FontAwesome.Sharp.IconButton();
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
            this.pnTop.Controls.Add(this.btRegularizar);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1048, 45);
            this.pnTop.TabIndex = 6;
            // 
            // btRegularizar
            // 
            this.btRegularizar.BackColor = System.Drawing.Color.MidnightBlue;
            this.btRegularizar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btRegularizar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btRegularizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRegularizar.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRegularizar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btRegularizar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btRegularizar.IconColor = System.Drawing.Color.Gainsboro;
            this.btRegularizar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btRegularizar.IconSize = 30;
            this.btRegularizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btRegularizar.Location = new System.Drawing.Point(0, 0);
            this.btRegularizar.Name = "btRegularizar";
            this.btRegularizar.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btRegularizar.Size = new System.Drawing.Size(140, 45);
            this.btRegularizar.TabIndex = 4;
            this.btRegularizar.Text = "Regularizar";
            this.btRegularizar.UseVisualStyleBackColor = false;
            this.btRegularizar.Click += new System.EventHandler(this.btRegularizar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(140, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(908, 1);
            this.panel1.TabIndex = 12;
            // 
            // PendienteSubMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1048, 608);
            this.Controls.Add(this.pnSubMain);
            this.Controls.Add(this.pnTop);
            this.Name = "PendienteSubMain";
            this.Text = "MantenimientoSubMain";
            this.pnTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnSubMain;
        private System.Windows.Forms.Panel pnTop;
        private FontAwesome.Sharp.IconButton btRegularizar;
        private System.Windows.Forms.Panel panel1;
    }
}