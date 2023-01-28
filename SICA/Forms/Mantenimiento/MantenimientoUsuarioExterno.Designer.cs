namespace SICA.Forms.Mantenimiento
{
    partial class MantenimientoUsuarioExterno
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
            this.pnTop = new System.Windows.Forms.Panel();
            this.btOrderDown = new FontAwesome.Sharp.IconButton();
            this.btOrderUp = new FontAwesome.Sharp.IconButton();
            this.btCrearUsuario = new FontAwesome.Sharp.IconButton();
            this.btModificarUsuario = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.pnTop.SuspendLayout();
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
            this.dgv.Location = new System.Drawing.Point(0, 47);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1048, 561);
            this.dgv.TabIndex = 43;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // pnTop
            // 
            this.pnTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.pnTop.Controls.Add(this.btOrderDown);
            this.pnTop.Controls.Add(this.btOrderUp);
            this.pnTop.Controls.Add(this.btCrearUsuario);
            this.pnTop.Controls.Add(this.btModificarUsuario);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1048, 47);
            this.pnTop.TabIndex = 44;
            // 
            // btOrderDown
            // 
            this.btOrderDown.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btOrderDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOrderDown.IconChar = FontAwesome.Sharp.IconChar.ArrowDown;
            this.btOrderDown.IconColor = System.Drawing.Color.Gainsboro;
            this.btOrderDown.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btOrderDown.IconSize = 30;
            this.btOrderDown.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btOrderDown.Location = new System.Drawing.Point(535, 7);
            this.btOrderDown.Name = "btOrderDown";
            this.btOrderDown.Size = new System.Drawing.Size(39, 35);
            this.btOrderDown.TabIndex = 34;
            this.btOrderDown.UseVisualStyleBackColor = true;
            this.btOrderDown.Click += new System.EventHandler(this.btOrderDown_Click);
            // 
            // btOrderUp
            // 
            this.btOrderUp.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btOrderUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOrderUp.IconChar = FontAwesome.Sharp.IconChar.ArrowUp;
            this.btOrderUp.IconColor = System.Drawing.Color.Gainsboro;
            this.btOrderUp.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btOrderUp.IconSize = 30;
            this.btOrderUp.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btOrderUp.Location = new System.Drawing.Point(486, 7);
            this.btOrderUp.Name = "btOrderUp";
            this.btOrderUp.Size = new System.Drawing.Size(39, 35);
            this.btOrderUp.TabIndex = 33;
            this.btOrderUp.UseVisualStyleBackColor = true;
            this.btOrderUp.Click += new System.EventHandler(this.btOrderUp_Click);
            // 
            // btCrearUsuario
            // 
            this.btCrearUsuario.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btCrearUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCrearUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCrearUsuario.ForeColor = System.Drawing.Color.Gainsboro;
            this.btCrearUsuario.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btCrearUsuario.IconColor = System.Drawing.Color.Black;
            this.btCrearUsuario.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btCrearUsuario.IconSize = 16;
            this.btCrearUsuario.Location = new System.Drawing.Point(12, 9);
            this.btCrearUsuario.Name = "btCrearUsuario";
            this.btCrearUsuario.Size = new System.Drawing.Size(217, 32);
            this.btCrearUsuario.TabIndex = 32;
            this.btCrearUsuario.Text = "Crear Usuario";
            this.btCrearUsuario.UseVisualStyleBackColor = true;
            this.btCrearUsuario.Click += new System.EventHandler(this.btCrearUsuario_Click);
            // 
            // btModificarUsuario
            // 
            this.btModificarUsuario.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btModificarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btModificarUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btModificarUsuario.ForeColor = System.Drawing.Color.Gainsboro;
            this.btModificarUsuario.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btModificarUsuario.IconColor = System.Drawing.Color.Black;
            this.btModificarUsuario.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btModificarUsuario.IconSize = 16;
            this.btModificarUsuario.Location = new System.Drawing.Point(235, 9);
            this.btModificarUsuario.Name = "btModificarUsuario";
            this.btModificarUsuario.Size = new System.Drawing.Size(217, 32);
            this.btModificarUsuario.TabIndex = 31;
            this.btModificarUsuario.Text = "Modificar Usuario";
            this.btModificarUsuario.UseVisualStyleBackColor = true;
            this.btModificarUsuario.Click += new System.EventHandler(this.btModificarUsuario_Click);
            // 
            // MantenimientoUsuarioExterno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1048, 608);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.pnTop);
            this.Name = "MantenimientoUsuarioExterno";
            this.Text = "MantenimientoCuenta";
            this.Load += new System.EventHandler(this.MantenimientoCuenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.pnTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Panel pnTop;
        private FontAwesome.Sharp.IconButton btCrearUsuario;
        private FontAwesome.Sharp.IconButton btModificarUsuario;
        private FontAwesome.Sharp.IconButton btOrderDown;
        private FontAwesome.Sharp.IconButton btOrderUp;
    }
}