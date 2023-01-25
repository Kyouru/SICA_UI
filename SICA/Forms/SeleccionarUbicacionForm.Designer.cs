namespace SICA.Forms
{
    partial class SeleccionarUbicacionForm
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
            this.cmbUbicacion = new System.Windows.Forms.ComboBox();
            this.btSeleccionar = new System.Windows.Forms.Button();
            this.lbSeleccionarUsuario = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbUbicacion
            // 
            this.cmbUbicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUbicacion.FormattingEnabled = true;
            this.cmbUbicacion.Location = new System.Drawing.Point(89, 9);
            this.cmbUbicacion.Name = "cmbUbicacion";
            this.cmbUbicacion.Size = new System.Drawing.Size(257, 21);
            this.cmbUbicacion.TabIndex = 0;
            this.cmbUbicacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbUsuario_KeyPress);
            // 
            // btSeleccionar
            // 
            this.btSeleccionar.Location = new System.Drawing.Point(126, 36);
            this.btSeleccionar.Name = "btSeleccionar";
            this.btSeleccionar.Size = new System.Drawing.Size(106, 23);
            this.btSeleccionar.TabIndex = 2;
            this.btSeleccionar.Text = "Seleccionar";
            this.btSeleccionar.UseVisualStyleBackColor = true;
            this.btSeleccionar.Click += new System.EventHandler(this.btSeleccionar_Click);
            // 
            // lbSeleccionarUsuario
            // 
            this.lbSeleccionarUsuario.AutoSize = true;
            this.lbSeleccionarUsuario.ForeColor = System.Drawing.Color.Gainsboro;
            this.lbSeleccionarUsuario.Location = new System.Drawing.Point(12, 9);
            this.lbSeleccionarUsuario.Name = "lbSeleccionarUsuario";
            this.lbSeleccionarUsuario.Size = new System.Drawing.Size(0, 13);
            this.lbSeleccionarUsuario.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Ubicacion:";
            // 
            // SeleccionarUbicacionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(358, 69);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbSeleccionarUsuario);
            this.Controls.Add(this.btSeleccionar);
            this.Controls.Add(this.cmbUbicacion);
            this.Name = "SeleccionarUbicacionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ubicacion";
            this.Load += new System.EventHandler(this.SeleccionarUbicacionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbUbicacion;
        private System.Windows.Forms.Button btSeleccionar;
        private System.Windows.Forms.Label lbSeleccionarUsuario;
        private System.Windows.Forms.Label label1;
    }
}