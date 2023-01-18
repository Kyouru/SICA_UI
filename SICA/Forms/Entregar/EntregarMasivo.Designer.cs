namespace SICA.Forms.Entregar
{
    partial class EntregarMasivo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btBuscarCargo = new FontAwesome.Sharp.IconButton();
            this.btCargarValido = new FontAwesome.Sharp.IconButton();
            this.btExcel = new FontAwesome.Sharp.IconButton();
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
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle20;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.Gainsboro;
            this.dgv.Location = new System.Drawing.Point(0, 53);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv.RowHeadersVisible = false;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv.RowsDefaultCellStyle = dataGridViewCellStyle21;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1048, 555);
            this.dgv.TabIndex = 30;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btExcel);
            this.panel1.Controls.Add(this.btBuscarCargo);
            this.panel1.Controls.Add(this.btCargarValido);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1048, 53);
            this.panel1.TabIndex = 31;
            // 
            // btBuscarCargo
            // 
            this.btBuscarCargo.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btBuscarCargo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscarCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscarCargo.ForeColor = System.Drawing.Color.Gainsboro;
            this.btBuscarCargo.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btBuscarCargo.IconColor = System.Drawing.Color.Black;
            this.btBuscarCargo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btBuscarCargo.IconSize = 16;
            this.btBuscarCargo.Location = new System.Drawing.Point(12, 12);
            this.btBuscarCargo.Name = "btBuscarCargo";
            this.btBuscarCargo.Size = new System.Drawing.Size(217, 32);
            this.btBuscarCargo.TabIndex = 30;
            this.btBuscarCargo.Text = "Buscar Cargo Masivo";
            this.btBuscarCargo.UseVisualStyleBackColor = true;
            this.btBuscarCargo.Click += new System.EventHandler(this.btBuscarCargo_Click);
            // 
            // btCargarValido
            // 
            this.btCargarValido.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btCargarValido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCargarValido.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCargarValido.ForeColor = System.Drawing.Color.Gainsboro;
            this.btCargarValido.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btCargarValido.IconColor = System.Drawing.Color.Black;
            this.btCargarValido.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btCargarValido.IconSize = 16;
            this.btCargarValido.Location = new System.Drawing.Point(235, 12);
            this.btCargarValido.Name = "btCargarValido";
            this.btCargarValido.Size = new System.Drawing.Size(217, 32);
            this.btCargarValido.TabIndex = 28;
            this.btCargarValido.Text = "Procesar";
            this.btCargarValido.UseVisualStyleBackColor = true;
            this.btCargarValido.Visible = false;
            this.btCargarValido.Click += new System.EventHandler(this.btCargarValido_Click);
            // 
            // btExcel
            // 
            this.btExcel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btExcel.IconChar = FontAwesome.Sharp.IconChar.FileExcel;
            this.btExcel.IconColor = System.Drawing.Color.Gainsboro;
            this.btExcel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btExcel.IconSize = 30;
            this.btExcel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btExcel.Location = new System.Drawing.Point(908, 9);
            this.btExcel.Name = "btExcel";
            this.btExcel.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.btExcel.Size = new System.Drawing.Size(48, 38);
            this.btExcel.TabIndex = 31;
            this.btExcel.UseVisualStyleBackColor = true;
            this.btExcel.Click += new System.EventHandler(this.btExcel_Click);
            // 
            // EntregarMasivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1048, 608);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.panel1);
            this.Name = "EntregarMasivo";
            this.Text = "EntregarDocumento";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btBuscarCargo;
        private FontAwesome.Sharp.IconButton btCargarValido;
        private FontAwesome.Sharp.IconButton btExcel;
    }
}