namespace SICA.Forms.Mantenimiento
{
    partial class MantenimientoPendiente
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
            this.dgvNombre = new System.Windows.Forms.DataGridView();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.dgvBanca = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btAnularBanca = new FontAwesome.Sharp.IconButton();
            this.btAgregarBanca = new FontAwesome.Sharp.IconButton();
            this.btOrderDownBanca = new FontAwesome.Sharp.IconButton();
            this.btOrderUpBanca = new FontAwesome.Sharp.IconButton();
            this.btAnularDetalle = new FontAwesome.Sharp.IconButton();
            this.btAgregarDetalle = new FontAwesome.Sharp.IconButton();
            this.btOrderDownDetalle = new FontAwesome.Sharp.IconButton();
            this.btOrderUpDetalle = new FontAwesome.Sharp.IconButton();
            this.btAnularNombre = new FontAwesome.Sharp.IconButton();
            this.btAgregarNombre = new FontAwesome.Sharp.IconButton();
            this.btOrderDownNombre = new FontAwesome.Sharp.IconButton();
            this.btOrderUpNombre = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNombre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBanca)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvNombre
            // 
            this.dgvNombre.AllowUserToAddRows = false;
            this.dgvNombre.AllowUserToDeleteRows = false;
            this.dgvNombre.AllowUserToResizeRows = false;
            this.dgvNombre.BackgroundColor = System.Drawing.Color.MidnightBlue;
            this.dgvNombre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvNombre.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNombre.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvNombre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNombre.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNombre.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvNombre.EnableHeadersVisualStyles = false;
            this.dgvNombre.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvNombre.Location = new System.Drawing.Point(53, 42);
            this.dgvNombre.MultiSelect = false;
            this.dgvNombre.Name = "dgvNombre";
            this.dgvNombre.ReadOnly = true;
            this.dgvNombre.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvNombre.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvNombre.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvNombre.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNombre.Size = new System.Drawing.Size(235, 608);
            this.dgvNombre.TabIndex = 45;
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.AllowUserToResizeRows = false;
            this.dgvDetalle.BackgroundColor = System.Drawing.Color.MidnightBlue;
            this.dgvDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetalle.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.ColumnHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetalle.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDetalle.EnableHeadersVisualStyles = false;
            this.dgvDetalle.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvDetalle.Location = new System.Drawing.Point(384, 42);
            this.dgvDetalle.MultiSelect = false;
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDetalle.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvDetalle.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(235, 608);
            this.dgvDetalle.TabIndex = 50;
            // 
            // dgvBanca
            // 
            this.dgvBanca.AllowUserToAddRows = false;
            this.dgvBanca.AllowUserToDeleteRows = false;
            this.dgvBanca.AllowUserToResizeRows = false;
            this.dgvBanca.BackgroundColor = System.Drawing.Color.MidnightBlue;
            this.dgvBanca.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBanca.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBanca.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvBanca.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBanca.ColumnHeadersVisible = false;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBanca.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvBanca.EnableHeadersVisualStyles = false;
            this.dgvBanca.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvBanca.Location = new System.Drawing.Point(723, 42);
            this.dgvBanca.MultiSelect = false;
            this.dgvBanca.Name = "dgvBanca";
            this.dgvBanca.ReadOnly = true;
            this.dgvBanca.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvBanca.RowHeadersVisible = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvBanca.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvBanca.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBanca.Size = new System.Drawing.Size(235, 608);
            this.dgvBanca.TabIndex = 55;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(49, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 22);
            this.label1.TabIndex = 60;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(380, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 22);
            this.label2.TabIndex = 61;
            this.label2.Text = "Detalle";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(719, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 22);
            this.label3.TabIndex = 62;
            this.label3.Text = "Banca";
            // 
            // btAnularBanca
            // 
            this.btAnularBanca.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAnularBanca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAnularBanca.IconChar = FontAwesome.Sharp.IconChar.X;
            this.btAnularBanca.IconColor = System.Drawing.Color.Gainsboro;
            this.btAnularBanca.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btAnularBanca.IconSize = 17;
            this.btAnularBanca.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btAnularBanca.Location = new System.Drawing.Point(973, 144);
            this.btAnularBanca.Name = "btAnularBanca";
            this.btAnularBanca.Size = new System.Drawing.Size(26, 25);
            this.btAnularBanca.TabIndex = 59;
            this.btAnularBanca.UseVisualStyleBackColor = true;
            this.btAnularBanca.Click += new System.EventHandler(this.btAnularBanca_Click);
            // 
            // btAgregarBanca
            // 
            this.btAgregarBanca.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAgregarBanca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAgregarBanca.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btAgregarBanca.IconColor = System.Drawing.Color.Gainsboro;
            this.btAgregarBanca.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btAgregarBanca.IconSize = 17;
            this.btAgregarBanca.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btAgregarBanca.Location = new System.Drawing.Point(973, 51);
            this.btAgregarBanca.Name = "btAgregarBanca";
            this.btAgregarBanca.Size = new System.Drawing.Size(26, 25);
            this.btAgregarBanca.TabIndex = 58;
            this.btAgregarBanca.UseVisualStyleBackColor = true;
            this.btAgregarBanca.Click += new System.EventHandler(this.btAgregarBanca_Click);
            // 
            // btOrderDownBanca
            // 
            this.btOrderDownBanca.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btOrderDownBanca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOrderDownBanca.IconChar = FontAwesome.Sharp.IconChar.ArrowDown;
            this.btOrderDownBanca.IconColor = System.Drawing.Color.Gainsboro;
            this.btOrderDownBanca.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btOrderDownBanca.IconSize = 17;
            this.btOrderDownBanca.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btOrderDownBanca.Location = new System.Drawing.Point(973, 113);
            this.btOrderDownBanca.Name = "btOrderDownBanca";
            this.btOrderDownBanca.Size = new System.Drawing.Size(26, 25);
            this.btOrderDownBanca.TabIndex = 57;
            this.btOrderDownBanca.UseVisualStyleBackColor = true;
            this.btOrderDownBanca.Click += new System.EventHandler(this.btOrderDownBanca_Click);
            // 
            // btOrderUpBanca
            // 
            this.btOrderUpBanca.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btOrderUpBanca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOrderUpBanca.IconChar = FontAwesome.Sharp.IconChar.ArrowUp;
            this.btOrderUpBanca.IconColor = System.Drawing.Color.Gainsboro;
            this.btOrderUpBanca.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btOrderUpBanca.IconSize = 17;
            this.btOrderUpBanca.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btOrderUpBanca.Location = new System.Drawing.Point(973, 82);
            this.btOrderUpBanca.Name = "btOrderUpBanca";
            this.btOrderUpBanca.Size = new System.Drawing.Size(26, 25);
            this.btOrderUpBanca.TabIndex = 56;
            this.btOrderUpBanca.UseVisualStyleBackColor = true;
            this.btOrderUpBanca.Click += new System.EventHandler(this.btOrderUpBanca_Click);
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
            this.btAnularDetalle.Location = new System.Drawing.Point(634, 144);
            this.btAnularDetalle.Name = "btAnularDetalle";
            this.btAnularDetalle.Size = new System.Drawing.Size(26, 25);
            this.btAnularDetalle.TabIndex = 54;
            this.btAnularDetalle.UseVisualStyleBackColor = true;
            this.btAnularDetalle.Click += new System.EventHandler(this.btAnularDetalle_Click);
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
            this.btAgregarDetalle.Location = new System.Drawing.Point(634, 51);
            this.btAgregarDetalle.Name = "btAgregarDetalle";
            this.btAgregarDetalle.Size = new System.Drawing.Size(26, 25);
            this.btAgregarDetalle.TabIndex = 53;
            this.btAgregarDetalle.UseVisualStyleBackColor = true;
            this.btAgregarDetalle.Click += new System.EventHandler(this.btAgregarDetalle_Click);
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
            this.btOrderDownDetalle.Location = new System.Drawing.Point(634, 113);
            this.btOrderDownDetalle.Name = "btOrderDownDetalle";
            this.btOrderDownDetalle.Size = new System.Drawing.Size(26, 25);
            this.btOrderDownDetalle.TabIndex = 52;
            this.btOrderDownDetalle.UseVisualStyleBackColor = true;
            this.btOrderDownDetalle.Click += new System.EventHandler(this.btOrderDownDetalle_Click);
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
            this.btOrderUpDetalle.Location = new System.Drawing.Point(634, 82);
            this.btOrderUpDetalle.Name = "btOrderUpDetalle";
            this.btOrderUpDetalle.Size = new System.Drawing.Size(26, 25);
            this.btOrderUpDetalle.TabIndex = 51;
            this.btOrderUpDetalle.UseVisualStyleBackColor = true;
            this.btOrderUpDetalle.Click += new System.EventHandler(this.btOrderUpDetalle_Click);
            // 
            // btAnularNombre
            // 
            this.btAnularNombre.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAnularNombre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAnularNombre.IconChar = FontAwesome.Sharp.IconChar.X;
            this.btAnularNombre.IconColor = System.Drawing.Color.Gainsboro;
            this.btAnularNombre.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btAnularNombre.IconSize = 17;
            this.btAnularNombre.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btAnularNombre.Location = new System.Drawing.Point(303, 144);
            this.btAnularNombre.Name = "btAnularNombre";
            this.btAnularNombre.Size = new System.Drawing.Size(26, 25);
            this.btAnularNombre.TabIndex = 49;
            this.btAnularNombre.UseVisualStyleBackColor = true;
            this.btAnularNombre.Click += new System.EventHandler(this.btAnularNombre_Click);
            // 
            // btAgregarNombre
            // 
            this.btAgregarNombre.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAgregarNombre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAgregarNombre.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btAgregarNombre.IconColor = System.Drawing.Color.Gainsboro;
            this.btAgregarNombre.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btAgregarNombre.IconSize = 17;
            this.btAgregarNombre.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btAgregarNombre.Location = new System.Drawing.Point(303, 51);
            this.btAgregarNombre.Name = "btAgregarNombre";
            this.btAgregarNombre.Size = new System.Drawing.Size(26, 25);
            this.btAgregarNombre.TabIndex = 48;
            this.btAgregarNombre.UseVisualStyleBackColor = true;
            this.btAgregarNombre.Click += new System.EventHandler(this.btAgregarNombre_Click);
            // 
            // btOrderDownNombre
            // 
            this.btOrderDownNombre.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btOrderDownNombre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOrderDownNombre.IconChar = FontAwesome.Sharp.IconChar.ArrowDown;
            this.btOrderDownNombre.IconColor = System.Drawing.Color.Gainsboro;
            this.btOrderDownNombre.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btOrderDownNombre.IconSize = 17;
            this.btOrderDownNombre.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btOrderDownNombre.Location = new System.Drawing.Point(303, 113);
            this.btOrderDownNombre.Name = "btOrderDownNombre";
            this.btOrderDownNombre.Size = new System.Drawing.Size(26, 25);
            this.btOrderDownNombre.TabIndex = 47;
            this.btOrderDownNombre.UseVisualStyleBackColor = true;
            this.btOrderDownNombre.Click += new System.EventHandler(this.btOrderDownNombre_Click);
            // 
            // btOrderUpNombre
            // 
            this.btOrderUpNombre.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btOrderUpNombre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOrderUpNombre.IconChar = FontAwesome.Sharp.IconChar.ArrowUp;
            this.btOrderUpNombre.IconColor = System.Drawing.Color.Gainsboro;
            this.btOrderUpNombre.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btOrderUpNombre.IconSize = 17;
            this.btOrderUpNombre.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btOrderUpNombre.Location = new System.Drawing.Point(303, 82);
            this.btOrderUpNombre.Name = "btOrderUpNombre";
            this.btOrderUpNombre.Size = new System.Drawing.Size(26, 25);
            this.btOrderUpNombre.TabIndex = 46;
            this.btOrderUpNombre.UseVisualStyleBackColor = true;
            this.btOrderUpNombre.Click += new System.EventHandler(this.btOrderUpNombre_Click);
            // 
            // MantenimientoPendiente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1048, 662);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btAnularBanca);
            this.Controls.Add(this.btAgregarBanca);
            this.Controls.Add(this.btOrderDownBanca);
            this.Controls.Add(this.btOrderUpBanca);
            this.Controls.Add(this.dgvBanca);
            this.Controls.Add(this.btAnularDetalle);
            this.Controls.Add(this.btAgregarDetalle);
            this.Controls.Add(this.btOrderDownDetalle);
            this.Controls.Add(this.btOrderUpDetalle);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.btAnularNombre);
            this.Controls.Add(this.btAgregarNombre);
            this.Controls.Add(this.btOrderDownNombre);
            this.Controls.Add(this.btOrderUpNombre);
            this.Controls.Add(this.dgvNombre);
            this.Name = "MantenimientoPendiente";
            this.Text = "MantenimientoPendiente";
            this.Load += new System.EventHandler(this.MantenimientoListas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNombre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBanca)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvNombre;
        private FontAwesome.Sharp.IconButton btOrderUpNombre;
        private FontAwesome.Sharp.IconButton btOrderDownNombre;
        private FontAwesome.Sharp.IconButton btAgregarNombre;
        private FontAwesome.Sharp.IconButton btAnularNombre;
        private FontAwesome.Sharp.IconButton btAnularDetalle;
        private FontAwesome.Sharp.IconButton btAgregarDetalle;
        private FontAwesome.Sharp.IconButton btOrderDownDetalle;
        private FontAwesome.Sharp.IconButton btOrderUpDetalle;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private FontAwesome.Sharp.IconButton btAnularBanca;
        private FontAwesome.Sharp.IconButton btAgregarBanca;
        private FontAwesome.Sharp.IconButton btOrderDownBanca;
        private FontAwesome.Sharp.IconButton btOrderUpBanca;
        private System.Windows.Forms.DataGridView dgvBanca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}