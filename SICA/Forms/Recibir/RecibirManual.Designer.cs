
namespace SICA.Forms.Recibir
{
    partial class RecibirManual
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
            this.btGuadar = new FontAwesome.Sharp.IconButton();
            this.cbClasificacion = new System.Windows.Forms.CheckBox();
            this.cbProducto = new System.Windows.Forms.CheckBox();
            this.cbCentroCosto = new System.Windows.Forms.CheckBox();
            this.cmbProducto = new System.Windows.Forms.ComboBox();
            this.cmbCentroCosto = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbObservacion = new System.Windows.Forms.TextBox();
            this.cmbClasificacion = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbNombreSocio = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tbCodigoSocio = new System.Windows.Forms.TextBox();
            this.btValidarSolicitud = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbNumeroSolicitud = new System.Windows.Forms.TextBox();
            this.cmbDetalle = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbHasta = new System.Windows.Forms.Label();
            this.lbDesde = new System.Windows.Forms.Label();
            this.cmbDocumento = new System.Windows.Forms.ComboBox();
            this.cmbDepartamento = new System.Windows.Forms.ComboBox();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFecha = new System.Windows.Forms.CheckBox();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.tbCaja = new System.Windows.Forms.TextBox();
            this.cbPagare = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btGuadar
            // 
            this.btGuadar.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btGuadar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btGuadar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGuadar.ForeColor = System.Drawing.Color.Gainsboro;
            this.btGuadar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btGuadar.IconColor = System.Drawing.Color.Black;
            this.btGuadar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btGuadar.IconSize = 16;
            this.btGuadar.Location = new System.Drawing.Point(220, 527);
            this.btGuadar.Name = "btGuadar";
            this.btGuadar.Size = new System.Drawing.Size(119, 32);
            this.btGuadar.TabIndex = 142;
            this.btGuadar.Text = "Guardar";
            this.btGuadar.UseVisualStyleBackColor = true;
            this.btGuadar.Click += new System.EventHandler(this.btGuardar_Click);
            // 
            // cbClasificacion
            // 
            this.cbClasificacion.AutoSize = true;
            this.cbClasificacion.Font = new System.Drawing.Font("Arial", 14F);
            this.cbClasificacion.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cbClasificacion.Location = new System.Drawing.Point(23, 318);
            this.cbClasificacion.Name = "cbClasificacion";
            this.cbClasificacion.Size = new System.Drawing.Size(136, 26);
            this.cbClasificacion.TabIndex = 141;
            this.cbClasificacion.Text = "Clasificacion";
            this.cbClasificacion.UseVisualStyleBackColor = true;
            this.cbClasificacion.CheckedChanged += new System.EventHandler(this.cbClasificacion_CheckedChanged);
            // 
            // cbProducto
            // 
            this.cbProducto.AutoSize = true;
            this.cbProducto.Font = new System.Drawing.Font("Arial", 14F);
            this.cbProducto.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cbProducto.Location = new System.Drawing.Point(23, 439);
            this.cbProducto.Name = "cbProducto";
            this.cbProducto.Size = new System.Drawing.Size(106, 26);
            this.cbProducto.TabIndex = 140;
            this.cbProducto.Text = "Producto";
            this.cbProducto.UseVisualStyleBackColor = true;
            this.cbProducto.CheckedChanged += new System.EventHandler(this.cbProducto_CheckedChanged);
            // 
            // cbCentroCosto
            // 
            this.cbCentroCosto.AutoSize = true;
            this.cbCentroCosto.Font = new System.Drawing.Font("Arial", 14F);
            this.cbCentroCosto.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cbCentroCosto.Location = new System.Drawing.Point(23, 408);
            this.cbCentroCosto.Name = "cbCentroCosto";
            this.cbCentroCosto.Size = new System.Drawing.Size(142, 26);
            this.cbCentroCosto.TabIndex = 139;
            this.cbCentroCosto.Text = "Centro Costo";
            this.cbCentroCosto.UseVisualStyleBackColor = true;
            this.cbCentroCosto.CheckedChanged += new System.EventHandler(this.cbCentroCosto_CheckedChanged);
            // 
            // cmbProducto
            // 
            this.cmbProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.cmbProducto.FormattingEnabled = true;
            this.cmbProducto.Location = new System.Drawing.Point(220, 440);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new System.Drawing.Size(188, 26);
            this.cmbProducto.TabIndex = 138;
            // 
            // cmbCentroCosto
            // 
            this.cmbCentroCosto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCentroCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.cmbCentroCosto.FormattingEnabled = true;
            this.cmbCentroCosto.Location = new System.Drawing.Point(220, 408);
            this.cmbCentroCosto.Name = "cmbCentroCosto";
            this.cmbCentroCosto.Size = new System.Drawing.Size(284, 26);
            this.cmbCentroCosto.TabIndex = 137;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label9.Location = new System.Drawing.Point(19, 367);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 22);
            this.label9.TabIndex = 136;
            this.label9.Text = "Observacion:";
            // 
            // tbObservacion
            // 
            this.tbObservacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbObservacion.Location = new System.Drawing.Point(220, 351);
            this.tbObservacion.Multiline = true;
            this.tbObservacion.Name = "tbObservacion";
            this.tbObservacion.Size = new System.Drawing.Size(310, 51);
            this.tbObservacion.TabIndex = 135;
            // 
            // cmbClasificacion
            // 
            this.cmbClasificacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClasificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.cmbClasificacion.FormattingEnabled = true;
            this.cmbClasificacion.Location = new System.Drawing.Point(220, 319);
            this.cmbClasificacion.Name = "cmbClasificacion";
            this.cmbClasificacion.Size = new System.Drawing.Size(188, 26);
            this.cmbClasificacion.TabIndex = 134;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.Location = new System.Drawing.Point(18, 277);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 22);
            this.label7.TabIndex = 133;
            this.label7.Text = "Nombre Socio:";
            // 
            // tbNombreSocio
            // 
            this.tbNombreSocio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNombreSocio.Location = new System.Drawing.Point(220, 260);
            this.tbNombreSocio.Multiline = true;
            this.tbNombreSocio.Name = "tbNombreSocio";
            this.tbNombreSocio.Size = new System.Drawing.Size(310, 53);
            this.tbNombreSocio.TabIndex = 132;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(414, 230);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 24);
            this.button1.TabIndex = 131;
            this.button1.Text = "Validar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Location = new System.Drawing.Point(18, 230);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 22);
            this.label6.TabIndex = 130;
            this.label6.Text = "Codigo Socio:";
            // 
            // tbCodigoSocio
            // 
            this.tbCodigoSocio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCodigoSocio.Location = new System.Drawing.Point(220, 230);
            this.tbCodigoSocio.Name = "tbCodigoSocio";
            this.tbCodigoSocio.Size = new System.Drawing.Size(188, 24);
            this.tbCodigoSocio.TabIndex = 129;
            // 
            // btValidarSolicitud
            // 
            this.btValidarSolicitud.Enabled = false;
            this.btValidarSolicitud.Location = new System.Drawing.Point(414, 200);
            this.btValidarSolicitud.Name = "btValidarSolicitud";
            this.btValidarSolicitud.Size = new System.Drawing.Size(74, 24);
            this.btValidarSolicitud.TabIndex = 128;
            this.btValidarSolicitud.Text = "Validar";
            this.btValidarSolicitud.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(18, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 22);
            this.label5.TabIndex = 127;
            this.label5.Text = "Numero Solicitud:";
            // 
            // tbNumeroSolicitud
            // 
            this.tbNumeroSolicitud.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNumeroSolicitud.Location = new System.Drawing.Point(220, 200);
            this.tbNumeroSolicitud.Name = "tbNumeroSolicitud";
            this.tbNumeroSolicitud.Size = new System.Drawing.Size(188, 24);
            this.tbNumeroSolicitud.TabIndex = 126;
            // 
            // cmbDetalle
            // 
            this.cmbDetalle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.cmbDetalle.FormattingEnabled = true;
            this.cmbDetalle.Location = new System.Drawing.Point(220, 108);
            this.cmbDetalle.Name = "cmbDetalle";
            this.cmbDetalle.Size = new System.Drawing.Size(284, 26);
            this.cmbDetalle.TabIndex = 125;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(18, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 22);
            this.label4.TabIndex = 124;
            this.label4.Text = "Cod. Detalle:";
            // 
            // lbHasta
            // 
            this.lbHasta.AutoSize = true;
            this.lbHasta.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHasta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbHasta.Location = new System.Drawing.Point(128, 172);
            this.lbHasta.Name = "lbHasta";
            this.lbHasta.Size = new System.Drawing.Size(63, 22);
            this.lbHasta.TabIndex = 123;
            this.lbHasta.Text = "Hasta:";
            this.lbHasta.Visible = false;
            // 
            // lbDesde
            // 
            this.lbDesde.AutoSize = true;
            this.lbDesde.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDesde.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbDesde.Location = new System.Drawing.Point(128, 142);
            this.lbDesde.Name = "lbDesde";
            this.lbDesde.Size = new System.Drawing.Size(72, 22);
            this.lbDesde.TabIndex = 122;
            this.lbDesde.Text = "Desde:";
            this.lbDesde.Visible = false;
            // 
            // cmbDocumento
            // 
            this.cmbDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.cmbDocumento.FormattingEnabled = true;
            this.cmbDocumento.Location = new System.Drawing.Point(220, 76);
            this.cmbDocumento.Name = "cmbDocumento";
            this.cmbDocumento.Size = new System.Drawing.Size(284, 26);
            this.cmbDocumento.TabIndex = 121;
            this.cmbDocumento.SelectedIndexChanged += new System.EventHandler(this.cmbDocumento_SelectedIndexChanged);
            // 
            // cmbDepartamento
            // 
            this.cmbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.cmbDepartamento.FormattingEnabled = true;
            this.cmbDepartamento.Location = new System.Drawing.Point(220, 44);
            this.cmbDepartamento.Name = "cmbDepartamento";
            this.cmbDepartamento.Size = new System.Drawing.Size(284, 26);
            this.cmbDepartamento.TabIndex = 120;
            this.cmbDepartamento.SelectedIndexChanged += new System.EventHandler(this.cmbDepartamento_SelectedIndexChanged);
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaHasta.Location = new System.Drawing.Point(220, 170);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(119, 24);
            this.dtpFechaHasta.TabIndex = 119;
            this.dtpFechaHasta.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(18, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 22);
            this.label3.TabIndex = 118;
            this.label3.Text = "Cod. Documento:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(19, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 22);
            this.label2.TabIndex = 117;
            this.label2.Text = "Cod. Departamento:";
            // 
            // cbFecha
            // 
            this.cbFecha.AutoSize = true;
            this.cbFecha.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFecha.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cbFecha.Location = new System.Drawing.Point(22, 153);
            this.cbFecha.Name = "cbFecha";
            this.cbFecha.Size = new System.Drawing.Size(82, 26);
            this.cbFecha.TabIndex = 116;
            this.cbFecha.Text = "Fecha";
            this.cbFecha.UseVisualStyleBackColor = true;
            this.cbFecha.CheckedChanged += new System.EventHandler(this.cbFecha_CheckedChanged);
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaDesde.Location = new System.Drawing.Point(220, 140);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(119, 24);
            this.dtpFechaDesde.TabIndex = 115;
            this.dtpFechaDesde.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(18, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 22);
            this.label1.TabIndex = 114;
            this.label1.Text = "Caja:";
            // 
            // tbCaja
            // 
            this.tbCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCaja.Location = new System.Drawing.Point(220, 14);
            this.tbCaja.Name = "tbCaja";
            this.tbCaja.Size = new System.Drawing.Size(188, 24);
            this.tbCaja.TabIndex = 113;
            // 
            // cbPagare
            // 
            this.cbPagare.AutoSize = true;
            this.cbPagare.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPagare.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cbPagare.Location = new System.Drawing.Point(23, 488);
            this.cbPagare.Name = "cbPagare";
            this.cbPagare.Size = new System.Drawing.Size(90, 26);
            this.cbPagare.TabIndex = 143;
            this.cbPagare.Text = "Pagare";
            this.cbPagare.UseVisualStyleBackColor = true;
            // 
            // RecibirManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(549, 571);
            this.Controls.Add(this.cbPagare);
            this.Controls.Add(this.btGuadar);
            this.Controls.Add(this.cbClasificacion);
            this.Controls.Add(this.cbProducto);
            this.Controls.Add(this.cbCentroCosto);
            this.Controls.Add(this.cmbProducto);
            this.Controls.Add(this.cmbCentroCosto);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbObservacion);
            this.Controls.Add(this.cmbClasificacion);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbNombreSocio);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbCodigoSocio);
            this.Controls.Add(this.btValidarSolicitud);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbNumeroSolicitud);
            this.Controls.Add(this.cmbDetalle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbHasta);
            this.Controls.Add(this.lbDesde);
            this.Controls.Add(this.cmbDocumento);
            this.Controls.Add(this.cmbDepartamento);
            this.Controls.Add(this.dtpFechaHasta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbFecha);
            this.Controls.Add(this.dtpFechaDesde);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbCaja);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "RecibirManual";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recibir Documento";
            this.Load += new System.EventHandler(this.RecibirManual_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton btGuadar;
        private System.Windows.Forms.CheckBox cbClasificacion;
        private System.Windows.Forms.CheckBox cbProducto;
        private System.Windows.Forms.CheckBox cbCentroCosto;
        private System.Windows.Forms.ComboBox cmbProducto;
        private System.Windows.Forms.ComboBox cmbCentroCosto;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbObservacion;
        private System.Windows.Forms.ComboBox cmbClasificacion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbNombreSocio;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbCodigoSocio;
        private System.Windows.Forms.Button btValidarSolicitud;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbNumeroSolicitud;
        private System.Windows.Forms.ComboBox cmbDetalle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbHasta;
        private System.Windows.Forms.Label lbDesde;
        private System.Windows.Forms.ComboBox cmbDocumento;
        private System.Windows.Forms.ComboBox cmbDepartamento;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbFecha;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCaja;
        private System.Windows.Forms.CheckBox cbPagare;
    }
}