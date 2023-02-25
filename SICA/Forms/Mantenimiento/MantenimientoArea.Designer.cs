namespace SICA.Forms.Mantenimiento
{
    partial class MantenimientoArea
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
            this.dgvArea = new System.Windows.Forms.DataGridView();
            this.btAnularArea = new FontAwesome.Sharp.IconButton();
            this.btAgregarArea = new FontAwesome.Sharp.IconButton();
            this.btOrderDownArea = new FontAwesome.Sharp.IconButton();
            this.btOrderUpArea = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArea)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvArea
            // 
            this.dgvArea.AllowUserToAddRows = false;
            this.dgvArea.AllowUserToDeleteRows = false;
            this.dgvArea.AllowUserToResizeRows = false;
            this.dgvArea.BackgroundColor = System.Drawing.Color.MidnightBlue;
            this.dgvArea.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvArea.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvArea.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvArea.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArea.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvArea.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvArea.EnableHeadersVisualStyles = false;
            this.dgvArea.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvArea.Location = new System.Drawing.Point(45, 31);
            this.dgvArea.MultiSelect = false;
            this.dgvArea.Name = "dgvArea";
            this.dgvArea.ReadOnly = true;
            this.dgvArea.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvArea.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvArea.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvArea.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArea.Size = new System.Drawing.Size(400, 600);
            this.dgvArea.TabIndex = 45;
            // 
            // btAnularArea
            // 
            this.btAnularArea.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAnularArea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAnularArea.IconChar = FontAwesome.Sharp.IconChar.X;
            this.btAnularArea.IconColor = System.Drawing.Color.Gainsboro;
            this.btAnularArea.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btAnularArea.IconSize = 17;
            this.btAnularArea.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btAnularArea.Location = new System.Drawing.Point(468, 134);
            this.btAnularArea.Name = "btAnularArea";
            this.btAnularArea.Size = new System.Drawing.Size(26, 25);
            this.btAnularArea.TabIndex = 49;
            this.btAnularArea.UseVisualStyleBackColor = true;
            this.btAnularArea.Click += new System.EventHandler(this.btAnularArea_Click);
            // 
            // btAgregarArea
            // 
            this.btAgregarArea.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAgregarArea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAgregarArea.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btAgregarArea.IconColor = System.Drawing.Color.Gainsboro;
            this.btAgregarArea.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btAgregarArea.IconSize = 17;
            this.btAgregarArea.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btAgregarArea.Location = new System.Drawing.Point(468, 41);
            this.btAgregarArea.Name = "btAgregarArea";
            this.btAgregarArea.Size = new System.Drawing.Size(26, 25);
            this.btAgregarArea.TabIndex = 48;
            this.btAgregarArea.UseVisualStyleBackColor = true;
            this.btAgregarArea.Click += new System.EventHandler(this.btAgregarArea_Click);
            // 
            // btOrderDownArea
            // 
            this.btOrderDownArea.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btOrderDownArea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOrderDownArea.IconChar = FontAwesome.Sharp.IconChar.ArrowDown;
            this.btOrderDownArea.IconColor = System.Drawing.Color.Gainsboro;
            this.btOrderDownArea.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btOrderDownArea.IconSize = 17;
            this.btOrderDownArea.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btOrderDownArea.Location = new System.Drawing.Point(468, 103);
            this.btOrderDownArea.Name = "btOrderDownArea";
            this.btOrderDownArea.Size = new System.Drawing.Size(26, 25);
            this.btOrderDownArea.TabIndex = 47;
            this.btOrderDownArea.UseVisualStyleBackColor = true;
            this.btOrderDownArea.Click += new System.EventHandler(this.btOrderDownArea_Click);
            // 
            // btOrderUpArea
            // 
            this.btOrderUpArea.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btOrderUpArea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOrderUpArea.IconChar = FontAwesome.Sharp.IconChar.ArrowUp;
            this.btOrderUpArea.IconColor = System.Drawing.Color.Gainsboro;
            this.btOrderUpArea.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btOrderUpArea.IconSize = 17;
            this.btOrderUpArea.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btOrderUpArea.Location = new System.Drawing.Point(468, 72);
            this.btOrderUpArea.Name = "btOrderUpArea";
            this.btOrderUpArea.Size = new System.Drawing.Size(26, 25);
            this.btOrderUpArea.TabIndex = 46;
            this.btOrderUpArea.UseVisualStyleBackColor = true;
            this.btOrderUpArea.Click += new System.EventHandler(this.btOrderUpArea_Click);
            // 
            // MantenimientoArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1048, 662);
            this.Controls.Add(this.btAnularArea);
            this.Controls.Add(this.btAgregarArea);
            this.Controls.Add(this.btOrderDownArea);
            this.Controls.Add(this.btOrderUpArea);
            this.Controls.Add(this.dgvArea);
            this.Name = "MantenimientoArea";
            this.Text = "MantenimientoArea";
            this.Load += new System.EventHandler(this.MantenimientoListas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArea)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvArea;
        private FontAwesome.Sharp.IconButton btOrderUpArea;
        private FontAwesome.Sharp.IconButton btOrderDownArea;
        private FontAwesome.Sharp.IconButton btAgregarArea;
        private FontAwesome.Sharp.IconButton btAnularArea;
    }
}