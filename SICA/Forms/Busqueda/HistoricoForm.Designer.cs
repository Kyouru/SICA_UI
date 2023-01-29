namespace SICA.Forms
{
    partial class HistoricoForm
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btCerrar = new FontAwesome.Sharp.IconButton();
            this.btHistorico = new FontAwesome.Sharp.IconButton();
            this.btMovimiento = new FontAwesome.Sharp.IconButton();
            this.btHistoricoEdicion = new FontAwesome.Sharp.IconButton();
            this.pnTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnSubMain
            // 
            this.pnSubMain.BackColor = System.Drawing.Color.MidnightBlue;
            this.pnSubMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnSubMain.Location = new System.Drawing.Point(0, 79);
            this.pnSubMain.Name = "pnSubMain";
            this.pnSubMain.Size = new System.Drawing.Size(1111, 574);
            this.pnSubMain.TabIndex = 36;
            // 
            // pnTop
            // 
            this.pnTop.BackColor = System.Drawing.Color.MidnightBlue;
            this.pnTop.Controls.Add(this.btCerrar);
            this.pnTop.Controls.Add(this.panel2);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1111, 34);
            this.pnTop.TabIndex = 43;
            this.pnTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnTop_MouseDown);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1111, 5);
            this.panel2.TabIndex = 8;
            // 
            // btCerrar
            // 
            this.btCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCerrar.FlatAppearance.BorderSize = 0;
            this.btCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCerrar.IconChar = FontAwesome.Sharp.IconChar.WindowClose;
            this.btCerrar.IconColor = System.Drawing.Color.White;
            this.btCerrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btCerrar.IconSize = 30;
            this.btCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCerrar.Location = new System.Drawing.Point(1072, 3);
            this.btCerrar.Margin = new System.Windows.Forms.Padding(0);
            this.btCerrar.Name = "btCerrar";
            this.btCerrar.Size = new System.Drawing.Size(38, 26);
            this.btCerrar.TabIndex = 3;
            this.btCerrar.UseVisualStyleBackColor = true;
            this.btCerrar.Click += new System.EventHandler(this.btCerrar_Click);
            // 
            // btHistorico
            // 
            this.btHistorico.BackColor = System.Drawing.Color.MidnightBlue;
            this.btHistorico.Dock = System.Windows.Forms.DockStyle.Left;
            this.btHistorico.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btHistorico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btHistorico.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btHistorico.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btHistorico.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btHistorico.IconColor = System.Drawing.Color.Gainsboro;
            this.btHistorico.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btHistorico.IconSize = 30;
            this.btHistorico.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btHistorico.Location = new System.Drawing.Point(0, 34);
            this.btHistorico.Name = "btHistorico";
            this.btHistorico.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btHistorico.Size = new System.Drawing.Size(251, 45);
            this.btHistorico.TabIndex = 46;
            this.btHistorico.Text = "Historico";
            this.btHistorico.UseVisualStyleBackColor = false;
            this.btHistorico.Click += new System.EventHandler(this.btHistorico_Click);
            // 
            // btMovimiento
            // 
            this.btMovimiento.BackColor = System.Drawing.Color.MidnightBlue;
            this.btMovimiento.Dock = System.Windows.Forms.DockStyle.Left;
            this.btMovimiento.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btMovimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btMovimiento.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btMovimiento.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btMovimiento.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btMovimiento.IconColor = System.Drawing.Color.Gainsboro;
            this.btMovimiento.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btMovimiento.IconSize = 30;
            this.btMovimiento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btMovimiento.Location = new System.Drawing.Point(251, 34);
            this.btMovimiento.Name = "btMovimiento";
            this.btMovimiento.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btMovimiento.Size = new System.Drawing.Size(251, 45);
            this.btMovimiento.TabIndex = 48;
            this.btMovimiento.Text = "Historico Movimientos";
            this.btMovimiento.UseVisualStyleBackColor = false;
            this.btMovimiento.Click += new System.EventHandler(this.btMovimiento_Click);
            // 
            // btHistoricoEdicion
            // 
            this.btHistoricoEdicion.BackColor = System.Drawing.Color.MidnightBlue;
            this.btHistoricoEdicion.Dock = System.Windows.Forms.DockStyle.Left;
            this.btHistoricoEdicion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btHistoricoEdicion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btHistoricoEdicion.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btHistoricoEdicion.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btHistoricoEdicion.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btHistoricoEdicion.IconColor = System.Drawing.Color.Gainsboro;
            this.btHistoricoEdicion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btHistoricoEdicion.IconSize = 30;
            this.btHistoricoEdicion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btHistoricoEdicion.Location = new System.Drawing.Point(502, 34);
            this.btHistoricoEdicion.Name = "btHistoricoEdicion";
            this.btHistoricoEdicion.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btHistoricoEdicion.Size = new System.Drawing.Size(229, 45);
            this.btHistoricoEdicion.TabIndex = 49;
            this.btHistoricoEdicion.Text = "Historico Edicion";
            this.btHistoricoEdicion.UseVisualStyleBackColor = false;
            this.btHistoricoEdicion.Click += new System.EventHandler(this.btHistoricoEdicion_Click);
            // 
            // HistoricoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1111, 653);
            this.Controls.Add(this.btHistoricoEdicion);
            this.Controls.Add(this.btMovimiento);
            this.Controls.Add(this.btHistorico);
            this.Controls.Add(this.pnTop);
            this.Controls.Add(this.pnSubMain);
            this.Name = "HistoricoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HistoricoForm";
            this.Load += new System.EventHandler(this.HistoricoForm_Load);
            this.pnTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnSubMain;
        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton btCerrar;
        private FontAwesome.Sharp.IconButton btHistorico;
        private FontAwesome.Sharp.IconButton btMovimiento;
        private FontAwesome.Sharp.IconButton btHistoricoEdicion;
    }
}