namespace SICA.Forms.Mantenimiento
{
    partial class MantenimientoListas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDepartamento = new System.Windows.Forms.DataGridView();
            this.btOrderUpDepartamento = new FontAwesome.Sharp.IconButton();
            this.btOrderDownDepartamento = new FontAwesome.Sharp.IconButton();
            this.btAgregarDepartamento = new FontAwesome.Sharp.IconButton();
            this.btAnularDepartamento = new FontAwesome.Sharp.IconButton();
            this.btAnularDocumento = new FontAwesome.Sharp.IconButton();
            this.btAgregarDocumento = new FontAwesome.Sharp.IconButton();
            this.btOrderDownDocumento = new FontAwesome.Sharp.IconButton();
            this.btOrderUpDocumento = new FontAwesome.Sharp.IconButton();
            this.dgvDocumento = new System.Windows.Forms.DataGridView();
            this.btAnularDetalle = new FontAwesome.Sharp.IconButton();
            this.btAgregarDetalle = new FontAwesome.Sharp.IconButton();
            this.btOrderDownDetalle = new FontAwesome.Sharp.IconButton();
            this.btOrderUpDetalle = new FontAwesome.Sharp.IconButton();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartamento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDepartamento
            // 
            this.dgvDepartamento.AllowUserToAddRows = false;
            this.dgvDepartamento.AllowUserToDeleteRows = false;
            this.dgvDepartamento.AllowUserToResizeRows = false;
            this.dgvDepartamento.BackgroundColor = System.Drawing.Color.MidnightBlue;
            this.dgvDepartamento.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDepartamento.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDepartamento.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDepartamento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepartamento.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDepartamento.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDepartamento.EnableHeadersVisualStyles = false;
            this.dgvDepartamento.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvDepartamento.Location = new System.Drawing.Point(37, 67);
            this.dgvDepartamento.MultiSelect = false;
            this.dgvDepartamento.Name = "dgvDepartamento";
            this.dgvDepartamento.ReadOnly = true;
            this.dgvDepartamento.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDepartamento.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvDepartamento.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDepartamento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDepartamento.Size = new System.Drawing.Size(235, 450);
            this.dgvDepartamento.TabIndex = 45;
            this.dgvDepartamento.SelectionChanged += new System.EventHandler(this.dgvDepartamento_SelectionChanged);
            // 
            // btOrderUpDepartamento
            // 
            this.btOrderUpDepartamento.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btOrderUpDepartamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOrderUpDepartamento.IconChar = FontAwesome.Sharp.IconChar.ArrowUp;
            this.btOrderUpDepartamento.IconColor = System.Drawing.Color.Gainsboro;
            this.btOrderUpDepartamento.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btOrderUpDepartamento.IconSize = 17;
            this.btOrderUpDepartamento.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btOrderUpDepartamento.Location = new System.Drawing.Point(287, 103);
            this.btOrderUpDepartamento.Name = "btOrderUpDepartamento";
            this.btOrderUpDepartamento.Size = new System.Drawing.Size(26, 25);
            this.btOrderUpDepartamento.TabIndex = 46;
            this.btOrderUpDepartamento.UseVisualStyleBackColor = true;
            this.btOrderUpDepartamento.Click += new System.EventHandler(this.btOrderUpDepartamento_Click);
            // 
            // btOrderDownDepartamento
            // 
            this.btOrderDownDepartamento.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btOrderDownDepartamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOrderDownDepartamento.IconChar = FontAwesome.Sharp.IconChar.ArrowDown;
            this.btOrderDownDepartamento.IconColor = System.Drawing.Color.Gainsboro;
            this.btOrderDownDepartamento.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btOrderDownDepartamento.IconSize = 17;
            this.btOrderDownDepartamento.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btOrderDownDepartamento.Location = new System.Drawing.Point(287, 134);
            this.btOrderDownDepartamento.Name = "btOrderDownDepartamento";
            this.btOrderDownDepartamento.Size = new System.Drawing.Size(26, 25);
            this.btOrderDownDepartamento.TabIndex = 47;
            this.btOrderDownDepartamento.UseVisualStyleBackColor = true;
            this.btOrderDownDepartamento.Click += new System.EventHandler(this.btOrderDownDepartamento_Click);
            // 
            // btAgregarDepartamento
            // 
            this.btAgregarDepartamento.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAgregarDepartamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAgregarDepartamento.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btAgregarDepartamento.IconColor = System.Drawing.Color.Gainsboro;
            this.btAgregarDepartamento.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btAgregarDepartamento.IconSize = 17;
            this.btAgregarDepartamento.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btAgregarDepartamento.Location = new System.Drawing.Point(287, 72);
            this.btAgregarDepartamento.Name = "btAgregarDepartamento";
            this.btAgregarDepartamento.Size = new System.Drawing.Size(26, 25);
            this.btAgregarDepartamento.TabIndex = 48;
            this.btAgregarDepartamento.UseVisualStyleBackColor = true;
            this.btAgregarDepartamento.Click += new System.EventHandler(this.btAgregarDepartamento_Click);
            // 
            // btAnularDepartamento
            // 
            this.btAnularDepartamento.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAnularDepartamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAnularDepartamento.IconChar = FontAwesome.Sharp.IconChar.X;
            this.btAnularDepartamento.IconColor = System.Drawing.Color.Gainsboro;
            this.btAnularDepartamento.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btAnularDepartamento.IconSize = 17;
            this.btAnularDepartamento.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btAnularDepartamento.Location = new System.Drawing.Point(287, 165);
            this.btAnularDepartamento.Name = "btAnularDepartamento";
            this.btAnularDepartamento.Size = new System.Drawing.Size(26, 25);
            this.btAnularDepartamento.TabIndex = 49;
            this.btAnularDepartamento.UseVisualStyleBackColor = true;
            this.btAnularDepartamento.Click += new System.EventHandler(this.btAnularDepartamento_Click);
            // 
            // btAnularDocumento
            // 
            this.btAnularDocumento.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAnularDocumento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAnularDocumento.IconChar = FontAwesome.Sharp.IconChar.X;
            this.btAnularDocumento.IconColor = System.Drawing.Color.Gainsboro;
            this.btAnularDocumento.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btAnularDocumento.IconSize = 17;
            this.btAnularDocumento.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btAnularDocumento.Location = new System.Drawing.Point(618, 165);
            this.btAnularDocumento.Name = "btAnularDocumento";
            this.btAnularDocumento.Size = new System.Drawing.Size(26, 25);
            this.btAnularDocumento.TabIndex = 54;
            this.btAnularDocumento.UseVisualStyleBackColor = true;
            // 
            // btAgregarDocumento
            // 
            this.btAgregarDocumento.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAgregarDocumento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAgregarDocumento.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btAgregarDocumento.IconColor = System.Drawing.Color.Gainsboro;
            this.btAgregarDocumento.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btAgregarDocumento.IconSize = 17;
            this.btAgregarDocumento.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btAgregarDocumento.Location = new System.Drawing.Point(618, 72);
            this.btAgregarDocumento.Name = "btAgregarDocumento";
            this.btAgregarDocumento.Size = new System.Drawing.Size(26, 25);
            this.btAgregarDocumento.TabIndex = 53;
            this.btAgregarDocumento.UseVisualStyleBackColor = true;
            // 
            // btOrderDownDocumento
            // 
            this.btOrderDownDocumento.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btOrderDownDocumento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOrderDownDocumento.IconChar = FontAwesome.Sharp.IconChar.ArrowDown;
            this.btOrderDownDocumento.IconColor = System.Drawing.Color.Gainsboro;
            this.btOrderDownDocumento.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btOrderDownDocumento.IconSize = 17;
            this.btOrderDownDocumento.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btOrderDownDocumento.Location = new System.Drawing.Point(618, 134);
            this.btOrderDownDocumento.Name = "btOrderDownDocumento";
            this.btOrderDownDocumento.Size = new System.Drawing.Size(26, 25);
            this.btOrderDownDocumento.TabIndex = 52;
            this.btOrderDownDocumento.UseVisualStyleBackColor = true;
            // 
            // btOrderUpDocumento
            // 
            this.btOrderUpDocumento.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btOrderUpDocumento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOrderUpDocumento.IconChar = FontAwesome.Sharp.IconChar.ArrowUp;
            this.btOrderUpDocumento.IconColor = System.Drawing.Color.Gainsboro;
            this.btOrderUpDocumento.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btOrderUpDocumento.IconSize = 17;
            this.btOrderUpDocumento.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btOrderUpDocumento.Location = new System.Drawing.Point(618, 103);
            this.btOrderUpDocumento.Name = "btOrderUpDocumento";
            this.btOrderUpDocumento.Size = new System.Drawing.Size(26, 25);
            this.btOrderUpDocumento.TabIndex = 51;
            this.btOrderUpDocumento.UseVisualStyleBackColor = true;
            // 
            // dgvDocumento
            // 
            this.dgvDocumento.AllowUserToAddRows = false;
            this.dgvDocumento.AllowUserToDeleteRows = false;
            this.dgvDocumento.AllowUserToResizeRows = false;
            this.dgvDocumento.BackgroundColor = System.Drawing.Color.MidnightBlue;
            this.dgvDocumento.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDocumento.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDocumento.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDocumento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocumento.ColumnHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDocumento.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDocumento.EnableHeadersVisualStyles = false;
            this.dgvDocumento.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvDocumento.Location = new System.Drawing.Point(368, 67);
            this.dgvDocumento.MultiSelect = false;
            this.dgvDocumento.Name = "dgvDocumento";
            this.dgvDocumento.ReadOnly = true;
            this.dgvDocumento.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDocumento.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvDocumento.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDocumento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocumento.Size = new System.Drawing.Size(235, 450);
            this.dgvDocumento.TabIndex = 50;
            // 
            // btAnularDetalle
            // 
            this.btAnularDetalle.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAnularDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAnularDetalle.IconChar = FontAwesome.Sharp.IconChar.X;
            this.btAnularDetalle.IconColor = System.Drawing.Color.Gainsboro;
            this.btAnularDetalle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btAnularDetalle.IconSize = 17;
            this.btAnularDetalle.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btAnularDetalle.Location = new System.Drawing.Point(957, 165);
            this.btAnularDetalle.Name = "btAnularDetalle";
            this.btAnularDetalle.Size = new System.Drawing.Size(26, 25);
            this.btAnularDetalle.TabIndex = 59;
            this.btAnularDetalle.UseVisualStyleBackColor = true;
            // 
            // btAgregarDetalle
            // 
            this.btAgregarDetalle.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAgregarDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAgregarDetalle.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btAgregarDetalle.IconColor = System.Drawing.Color.Gainsboro;
            this.btAgregarDetalle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btAgregarDetalle.IconSize = 17;
            this.btAgregarDetalle.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btAgregarDetalle.Location = new System.Drawing.Point(957, 72);
            this.btAgregarDetalle.Name = "btAgregarDetalle";
            this.btAgregarDetalle.Size = new System.Drawing.Size(26, 25);
            this.btAgregarDetalle.TabIndex = 58;
            this.btAgregarDetalle.UseVisualStyleBackColor = true;
            // 
            // btOrderDownDetalle
            // 
            this.btOrderDownDetalle.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btOrderDownDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOrderDownDetalle.IconChar = FontAwesome.Sharp.IconChar.ArrowDown;
            this.btOrderDownDetalle.IconColor = System.Drawing.Color.Gainsboro;
            this.btOrderDownDetalle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btOrderDownDetalle.IconSize = 17;
            this.btOrderDownDetalle.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btOrderDownDetalle.Location = new System.Drawing.Point(957, 134);
            this.btOrderDownDetalle.Name = "btOrderDownDetalle";
            this.btOrderDownDetalle.Size = new System.Drawing.Size(26, 25);
            this.btOrderDownDetalle.TabIndex = 57;
            this.btOrderDownDetalle.UseVisualStyleBackColor = true;
            // 
            // btOrderUpDetalle
            // 
            this.btOrderUpDetalle.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btOrderUpDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOrderUpDetalle.IconChar = FontAwesome.Sharp.IconChar.ArrowUp;
            this.btOrderUpDetalle.IconColor = System.Drawing.Color.Gainsboro;
            this.btOrderUpDetalle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btOrderUpDetalle.IconSize = 17;
            this.btOrderUpDetalle.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btOrderUpDetalle.Location = new System.Drawing.Point(957, 103);
            this.btOrderUpDetalle.Name = "btOrderUpDetalle";
            this.btOrderUpDetalle.Size = new System.Drawing.Size(26, 25);
            this.btOrderUpDetalle.TabIndex = 56;
            this.btOrderUpDetalle.UseVisualStyleBackColor = true;
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.AllowUserToResizeRows = false;
            this.dgvDetalle.BackgroundColor = System.Drawing.Color.MidnightBlue;
            this.dgvDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetalle.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.ColumnHeadersVisible = false;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetalle.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDetalle.EnableHeadersVisualStyles = false;
            this.dgvDetalle.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvDetalle.Location = new System.Drawing.Point(707, 67);
            this.dgvDetalle.MultiSelect = false;
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDetalle.RowHeadersVisible = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvDetalle.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(235, 450);
            this.dgvDetalle.TabIndex = 55;
            // 
            // MantenimientoListas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1048, 608);
            this.Controls.Add(this.btAnularDetalle);
            this.Controls.Add(this.btAgregarDetalle);
            this.Controls.Add(this.btOrderDownDetalle);
            this.Controls.Add(this.btOrderUpDetalle);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.btAnularDocumento);
            this.Controls.Add(this.btAgregarDocumento);
            this.Controls.Add(this.btOrderDownDocumento);
            this.Controls.Add(this.btOrderUpDocumento);
            this.Controls.Add(this.dgvDocumento);
            this.Controls.Add(this.btAnularDepartamento);
            this.Controls.Add(this.btAgregarDepartamento);
            this.Controls.Add(this.btOrderDownDepartamento);
            this.Controls.Add(this.btOrderUpDepartamento);
            this.Controls.Add(this.dgvDepartamento);
            this.Name = "MantenimientoListas";
            this.Text = "MantenimientoListas";
            this.Load += new System.EventHandler(this.MantenimientoListas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartamento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDepartamento;
        private FontAwesome.Sharp.IconButton btOrderUpDepartamento;
        private FontAwesome.Sharp.IconButton btOrderDownDepartamento;
        private FontAwesome.Sharp.IconButton btAgregarDepartamento;
        private FontAwesome.Sharp.IconButton btAnularDepartamento;
        private FontAwesome.Sharp.IconButton btAnularDocumento;
        private FontAwesome.Sharp.IconButton btAgregarDocumento;
        private FontAwesome.Sharp.IconButton btOrderDownDocumento;
        private FontAwesome.Sharp.IconButton btOrderUpDocumento;
        private System.Windows.Forms.DataGridView dgvDocumento;
        private FontAwesome.Sharp.IconButton btAnularDetalle;
        private FontAwesome.Sharp.IconButton btAgregarDetalle;
        private FontAwesome.Sharp.IconButton btOrderDownDetalle;
        private FontAwesome.Sharp.IconButton btOrderUpDetalle;
        private System.Windows.Forms.DataGridView dgvDetalle;
    }
}