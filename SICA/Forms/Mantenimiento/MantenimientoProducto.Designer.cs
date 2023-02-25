namespace SICA.Forms.Mantenimiento
{
    partial class MantenimientoProducto
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
            this.dgvProducto = new System.Windows.Forms.DataGridView();
            this.btAnularProducto = new FontAwesome.Sharp.IconButton();
            this.btAgregarProducto = new FontAwesome.Sharp.IconButton();
            this.btOrderDownProducto = new FontAwesome.Sharp.IconButton();
            this.btOrderUpProducto = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProducto
            // 
            this.dgvProducto.AllowUserToAddRows = false;
            this.dgvProducto.AllowUserToDeleteRows = false;
            this.dgvProducto.AllowUserToResizeRows = false;
            this.dgvProducto.BackgroundColor = System.Drawing.Color.MidnightBlue;
            this.dgvProducto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProducto.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProducto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducto.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProducto.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProducto.EnableHeadersVisualStyles = false;
            this.dgvProducto.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvProducto.Location = new System.Drawing.Point(45, 31);
            this.dgvProducto.MultiSelect = false;
            this.dgvProducto.Name = "dgvProducto";
            this.dgvProducto.ReadOnly = true;
            this.dgvProducto.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvProducto.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvProducto.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvProducto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducto.Size = new System.Drawing.Size(400, 600);
            this.dgvProducto.TabIndex = 45;
            // 
            // btAnularProducto
            // 
            this.btAnularProducto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAnularProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAnularProducto.IconChar = FontAwesome.Sharp.IconChar.X;
            this.btAnularProducto.IconColor = System.Drawing.Color.Gainsboro;
            this.btAnularProducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btAnularProducto.IconSize = 17;
            this.btAnularProducto.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btAnularProducto.Location = new System.Drawing.Point(467, 133);
            this.btAnularProducto.Name = "btAnularProducto";
            this.btAnularProducto.Size = new System.Drawing.Size(26, 25);
            this.btAnularProducto.TabIndex = 49;
            this.btAnularProducto.UseVisualStyleBackColor = true;
            this.btAnularProducto.Click += new System.EventHandler(this.btAnularProducto_Click);
            // 
            // btAgregarProducto
            // 
            this.btAgregarProducto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAgregarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAgregarProducto.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btAgregarProducto.IconColor = System.Drawing.Color.Gainsboro;
            this.btAgregarProducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btAgregarProducto.IconSize = 17;
            this.btAgregarProducto.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btAgregarProducto.Location = new System.Drawing.Point(467, 40);
            this.btAgregarProducto.Name = "btAgregarProducto";
            this.btAgregarProducto.Size = new System.Drawing.Size(26, 25);
            this.btAgregarProducto.TabIndex = 48;
            this.btAgregarProducto.UseVisualStyleBackColor = true;
            this.btAgregarProducto.Click += new System.EventHandler(this.btAgregarProducto_Click);
            // 
            // btOrderDownProducto
            // 
            this.btOrderDownProducto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btOrderDownProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOrderDownProducto.IconChar = FontAwesome.Sharp.IconChar.ArrowDown;
            this.btOrderDownProducto.IconColor = System.Drawing.Color.Gainsboro;
            this.btOrderDownProducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btOrderDownProducto.IconSize = 17;
            this.btOrderDownProducto.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btOrderDownProducto.Location = new System.Drawing.Point(467, 102);
            this.btOrderDownProducto.Name = "btOrderDownProducto";
            this.btOrderDownProducto.Size = new System.Drawing.Size(26, 25);
            this.btOrderDownProducto.TabIndex = 47;
            this.btOrderDownProducto.UseVisualStyleBackColor = true;
            this.btOrderDownProducto.Click += new System.EventHandler(this.btOrderDownProducto_Click);
            // 
            // btOrderUpProducto
            // 
            this.btOrderUpProducto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btOrderUpProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOrderUpProducto.IconChar = FontAwesome.Sharp.IconChar.ArrowUp;
            this.btOrderUpProducto.IconColor = System.Drawing.Color.Gainsboro;
            this.btOrderUpProducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btOrderUpProducto.IconSize = 17;
            this.btOrderUpProducto.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btOrderUpProducto.Location = new System.Drawing.Point(467, 71);
            this.btOrderUpProducto.Name = "btOrderUpProducto";
            this.btOrderUpProducto.Size = new System.Drawing.Size(26, 25);
            this.btOrderUpProducto.TabIndex = 46;
            this.btOrderUpProducto.UseVisualStyleBackColor = true;
            this.btOrderUpProducto.Click += new System.EventHandler(this.btOrderUpProducto_Click);
            // 
            // MantenimientoProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1048, 662);
            this.Controls.Add(this.btAnularProducto);
            this.Controls.Add(this.btAgregarProducto);
            this.Controls.Add(this.btOrderDownProducto);
            this.Controls.Add(this.btOrderUpProducto);
            this.Controls.Add(this.dgvProducto);
            this.Name = "MantenimientoProducto";
            this.Text = "MantenimientoProducto";
            this.Load += new System.EventHandler(this.MantenimientoListas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProducto;
        private FontAwesome.Sharp.IconButton btOrderUpProducto;
        private FontAwesome.Sharp.IconButton btOrderDownProducto;
        private FontAwesome.Sharp.IconButton btAgregarProducto;
        private FontAwesome.Sharp.IconButton btAnularProducto;
    }
}