﻿namespace SICA.Forms.Reporte
{
    partial class ReporteSubMain
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
            this.btCajas = new FontAwesome.Sharp.IconButton();
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
            this.pnTop.Controls.Add(this.btCajas);
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
            this.panel1.Location = new System.Drawing.Point(140, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(908, 1);
            this.panel1.TabIndex = 8;
            // 
            // btCajas
            // 
            this.btCajas.BackColor = System.Drawing.Color.MidnightBlue;
            this.btCajas.Dock = System.Windows.Forms.DockStyle.Left;
            this.btCajas.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btCajas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCajas.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCajas.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btCajas.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btCajas.IconColor = System.Drawing.Color.Gainsboro;
            this.btCajas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btCajas.IconSize = 30;
            this.btCajas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCajas.Location = new System.Drawing.Point(0, 0);
            this.btCajas.Name = "btCajas";
            this.btCajas.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btCajas.Size = new System.Drawing.Size(140, 45);
            this.btCajas.TabIndex = 4;
            this.btCajas.Text = "Cajas";
            this.btCajas.UseVisualStyleBackColor = false;
            this.btCajas.Click += new System.EventHandler(this.btNuevo_Click);
            // 
            // ReporteSubMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1048, 608);
            this.Controls.Add(this.pnSubMain);
            this.Controls.Add(this.pnTop);
            this.Name = "ReporteSubMain";
            this.Text = "ReporteSubMain";
            this.Load += new System.EventHandler(this.RecibirSubMain_Load);
            this.pnTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnSubMain;
        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btCajas;
    }
}