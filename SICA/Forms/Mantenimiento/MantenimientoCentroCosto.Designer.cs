namespace SICA.Forms.Mantenimiento
{
    partial class MantenimientoCentroCosto
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
            this.dgvCentroCosto = new System.Windows.Forms.DataGridView();
            this.btAnularCentroCosto = new FontAwesome.Sharp.IconButton();
            this.btAgregarCentroCosto = new FontAwesome.Sharp.IconButton();
            this.btOrderDownCentroCosto = new FontAwesome.Sharp.IconButton();
            this.btOrderUpCentroCosto = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCentroCosto)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCentroCosto
            // 
            this.dgvCentroCosto.AllowUserToAddRows = false;
            this.dgvCentroCosto.AllowUserToDeleteRows = false;
            this.dgvCentroCosto.AllowUserToResizeRows = false;
            this.dgvCentroCosto.BackgroundColor = System.Drawing.Color.MidnightBlue;
            this.dgvCentroCosto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCentroCosto.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCentroCosto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCentroCosto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCentroCosto.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCentroCosto.EnableHeadersVisualStyles = false;
            this.dgvCentroCosto.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvCentroCosto.Location = new System.Drawing.Point(45, 31);
            this.dgvCentroCosto.MultiSelect = false;
            this.dgvCentroCosto.Name = "dgvCentroCosto";
            this.dgvCentroCosto.ReadOnly = true;
            this.dgvCentroCosto.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCentroCosto.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvCentroCosto.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCentroCosto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCentroCosto.Size = new System.Drawing.Size(692, 600);
            this.dgvCentroCosto.TabIndex = 45;
            // 
            // btAnularCentroCosto
            // 
            this.btAnularCentroCosto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAnularCentroCosto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAnularCentroCosto.IconChar = FontAwesome.Sharp.IconChar.X;
            this.btAnularCentroCosto.IconColor = System.Drawing.Color.Gainsboro;
            this.btAnularCentroCosto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btAnularCentroCosto.IconSize = 17;
            this.btAnularCentroCosto.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btAnularCentroCosto.Location = new System.Drawing.Point(759, 134);
            this.btAnularCentroCosto.Name = "btAnularCentroCosto";
            this.btAnularCentroCosto.Size = new System.Drawing.Size(26, 25);
            this.btAnularCentroCosto.TabIndex = 49;
            this.btAnularCentroCosto.UseVisualStyleBackColor = true;
            this.btAnularCentroCosto.Click += new System.EventHandler(this.btAnularCentroCosto_Click);
            // 
            // btAgregarCentroCosto
            // 
            this.btAgregarCentroCosto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAgregarCentroCosto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAgregarCentroCosto.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btAgregarCentroCosto.IconColor = System.Drawing.Color.Gainsboro;
            this.btAgregarCentroCosto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btAgregarCentroCosto.IconSize = 17;
            this.btAgregarCentroCosto.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btAgregarCentroCosto.Location = new System.Drawing.Point(759, 41);
            this.btAgregarCentroCosto.Name = "btAgregarCentroCosto";
            this.btAgregarCentroCosto.Size = new System.Drawing.Size(26, 25);
            this.btAgregarCentroCosto.TabIndex = 48;
            this.btAgregarCentroCosto.UseVisualStyleBackColor = true;
            this.btAgregarCentroCosto.Click += new System.EventHandler(this.btAgregarCentroCosto_Click);
            // 
            // btOrderDownCentroCosto
            // 
            this.btOrderDownCentroCosto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btOrderDownCentroCosto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOrderDownCentroCosto.IconChar = FontAwesome.Sharp.IconChar.ArrowDown;
            this.btOrderDownCentroCosto.IconColor = System.Drawing.Color.Gainsboro;
            this.btOrderDownCentroCosto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btOrderDownCentroCosto.IconSize = 17;
            this.btOrderDownCentroCosto.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btOrderDownCentroCosto.Location = new System.Drawing.Point(759, 103);
            this.btOrderDownCentroCosto.Name = "btOrderDownCentroCosto";
            this.btOrderDownCentroCosto.Size = new System.Drawing.Size(26, 25);
            this.btOrderDownCentroCosto.TabIndex = 47;
            this.btOrderDownCentroCosto.UseVisualStyleBackColor = true;
            this.btOrderDownCentroCosto.Click += new System.EventHandler(this.btOrderDownCentroCosto_Click);
            // 
            // btOrderUpCentroCosto
            // 
            this.btOrderUpCentroCosto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btOrderUpCentroCosto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOrderUpCentroCosto.IconChar = FontAwesome.Sharp.IconChar.ArrowUp;
            this.btOrderUpCentroCosto.IconColor = System.Drawing.Color.Gainsboro;
            this.btOrderUpCentroCosto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btOrderUpCentroCosto.IconSize = 17;
            this.btOrderUpCentroCosto.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btOrderUpCentroCosto.Location = new System.Drawing.Point(759, 72);
            this.btOrderUpCentroCosto.Name = "btOrderUpCentroCosto";
            this.btOrderUpCentroCosto.Size = new System.Drawing.Size(26, 25);
            this.btOrderUpCentroCosto.TabIndex = 46;
            this.btOrderUpCentroCosto.UseVisualStyleBackColor = true;
            this.btOrderUpCentroCosto.Click += new System.EventHandler(this.btOrderUpCentroCosto_Click);
            // 
            // MantenimientoCentroCosto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1048, 662);
            this.Controls.Add(this.btAnularCentroCosto);
            this.Controls.Add(this.btAgregarCentroCosto);
            this.Controls.Add(this.btOrderDownCentroCosto);
            this.Controls.Add(this.btOrderUpCentroCosto);
            this.Controls.Add(this.dgvCentroCosto);
            this.Name = "MantenimientoCentroCosto";
            this.Text = "MantenimientoProducto";
            this.Load += new System.EventHandler(this.MantenimientoListas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCentroCosto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCentroCosto;
        private FontAwesome.Sharp.IconButton btOrderUpCentroCosto;
        private FontAwesome.Sharp.IconButton btOrderDownCentroCosto;
        private FontAwesome.Sharp.IconButton btAgregarCentroCosto;
        private FontAwesome.Sharp.IconButton btAnularCentroCosto;
    }
}