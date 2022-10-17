namespace SICA.Forms
{
    partial class ImportarSISGO
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btImportarActivas = new FontAwesome.Sharp.IconButton();
            this.btImportarPasivas = new FontAwesome.Sharp.IconButton();
            this.btCargar = new FontAwesome.Sharp.IconButton();
            this.lbCarga = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.Gainsboro;
            this.dgv.Location = new System.Drawing.Point(0, 53);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1048, 555);
            this.dgv.TabIndex = 30;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbCarga);
            this.panel1.Controls.Add(this.btCargar);
            this.panel1.Controls.Add(this.btImportarActivas);
            this.panel1.Controls.Add(this.btImportarPasivas);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1048, 53);
            this.panel1.TabIndex = 31;
            // 
            // btImportarActivas
            // 
            this.btImportarActivas.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btImportarActivas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btImportarActivas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btImportarActivas.ForeColor = System.Drawing.Color.Gainsboro;
            this.btImportarActivas.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btImportarActivas.IconColor = System.Drawing.Color.Black;
            this.btImportarActivas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btImportarActivas.IconSize = 16;
            this.btImportarActivas.Location = new System.Drawing.Point(12, 12);
            this.btImportarActivas.Name = "btImportarActivas";
            this.btImportarActivas.Size = new System.Drawing.Size(217, 32);
            this.btImportarActivas.TabIndex = 30;
            this.btImportarActivas.Text = "Cuentas Activas";
            this.btImportarActivas.UseVisualStyleBackColor = true;
            this.btImportarActivas.Visible = false;
            this.btImportarActivas.Click += new System.EventHandler(this.btImportarCuentasActivas_Click);
            // 
            // btImportarPasivas
            // 
            this.btImportarPasivas.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btImportarPasivas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btImportarPasivas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btImportarPasivas.ForeColor = System.Drawing.Color.Gainsboro;
            this.btImportarPasivas.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btImportarPasivas.IconColor = System.Drawing.Color.Black;
            this.btImportarPasivas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btImportarPasivas.IconSize = 16;
            this.btImportarPasivas.Location = new System.Drawing.Point(235, 12);
            this.btImportarPasivas.Name = "btImportarPasivas";
            this.btImportarPasivas.Size = new System.Drawing.Size(217, 32);
            this.btImportarPasivas.TabIndex = 28;
            this.btImportarPasivas.Text = "Cuentas Pasivas";
            this.btImportarPasivas.UseVisualStyleBackColor = true;
            this.btImportarPasivas.Visible = false;
            // 
            // btCargar
            // 
            this.btCargar.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btCargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCargar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCargar.ForeColor = System.Drawing.Color.Gainsboro;
            this.btCargar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btCargar.IconColor = System.Drawing.Color.Black;
            this.btCargar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btCargar.IconSize = 16;
            this.btCargar.Location = new System.Drawing.Point(819, 12);
            this.btCargar.Name = "btCargar";
            this.btCargar.Size = new System.Drawing.Size(217, 32);
            this.btCargar.TabIndex = 31;
            this.btCargar.Text = "Cargar";
            this.btCargar.UseVisualStyleBackColor = true;
            this.btCargar.Visible = false;
            this.btCargar.Click += new System.EventHandler(this.btCargar_Click);
            // 
            // lbCarga
            // 
            this.lbCarga.AutoSize = true;
            this.lbCarga.Location = new System.Drawing.Point(740, 23);
            this.lbCarga.Name = "lbCarga";
            this.lbCarga.Size = new System.Drawing.Size(35, 13);
            this.lbCarga.TabIndex = 32;
            this.lbCarga.Text = "label1";
            this.lbCarga.Visible = false;
            // 
            // ImportarSISGO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1048, 608);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.panel1);
            this.Name = "ImportarSISGO";
            this.Text = "ImportarSISGO";
            this.Load += new System.EventHandler(this.ImportarSISGO_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btImportarActivas;
        private FontAwesome.Sharp.IconButton btImportarPasivas;
        private FontAwesome.Sharp.IconButton btCargar;
        private System.Windows.Forms.Label lbCarga;
    }
}