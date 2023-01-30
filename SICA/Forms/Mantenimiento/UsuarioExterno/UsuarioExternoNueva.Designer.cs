
namespace SICA.Forms.Recibir
{
    partial class UsuarioExternoNueva
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
            this.label2 = new System.Windows.Forms.Label();
            this.tbNombreUsuario = new System.Windows.Forms.TextBox();
            this.tbCorreo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btRegistrar = new FontAwesome.Sharp.IconButton();
            this.cbNotificar = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.pnTop = new System.Windows.Forms.Panel();
            this.btCerrar = new FontAwesome.Sharp.IconButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(45, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 22);
            this.label2.TabIndex = 47;
            this.label2.Text = "Nombre Usuario:";
            // 
            // tbNombreUsuario
            // 
            this.tbNombreUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNombreUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNombreUsuario.Location = new System.Drawing.Point(203, 53);
            this.tbNombreUsuario.Name = "tbNombreUsuario";
            this.tbNombreUsuario.Size = new System.Drawing.Size(179, 24);
            this.tbNombreUsuario.TabIndex = 2;
            // 
            // tbCorreo
            // 
            this.tbCorreo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCorreo.Location = new System.Drawing.Point(203, 115);
            this.tbCorreo.Name = "tbCorreo";
            this.tbCorreo.Size = new System.Drawing.Size(179, 24);
            this.tbCorreo.TabIndex = 50;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(45, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 22);
            this.label3.TabIndex = 51;
            this.label3.Text = "Email:";
            // 
            // btRegistrar
            // 
            this.btRegistrar.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRegistrar.ForeColor = System.Drawing.Color.Gainsboro;
            this.btRegistrar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btRegistrar.IconColor = System.Drawing.Color.Black;
            this.btRegistrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btRegistrar.IconSize = 16;
            this.btRegistrar.Location = new System.Drawing.Point(108, 199);
            this.btRegistrar.Name = "btRegistrar";
            this.btRegistrar.Size = new System.Drawing.Size(217, 32);
            this.btRegistrar.TabIndex = 14;
            this.btRegistrar.Text = "Registrar";
            this.btRegistrar.UseVisualStyleBackColor = true;
            this.btRegistrar.Click += new System.EventHandler(this.btRegistrar_Click);
            // 
            // cbNotificar
            // 
            this.cbNotificar.AutoSize = true;
            this.cbNotificar.Font = new System.Drawing.Font("Arial", 14F);
            this.cbNotificar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cbNotificar.Location = new System.Drawing.Point(168, 157);
            this.cbNotificar.Name = "cbNotificar";
            this.cbNotificar.Size = new System.Drawing.Size(98, 26);
            this.cbNotificar.TabIndex = 53;
            this.cbNotificar.Text = "Notificar";
            this.cbNotificar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(45, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 22);
            this.label1.TabIndex = 54;
            this.label1.Text = "Area:";
            // 
            // cmbArea
            // 
            this.cmbArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Location = new System.Drawing.Point(203, 83);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(179, 26);
            this.cmbArea.TabIndex = 55;
            // 
            // pnTop
            // 
            this.pnTop.BackColor = System.Drawing.Color.MidnightBlue;
            this.pnTop.Controls.Add(this.btCerrar);
            this.pnTop.Controls.Add(this.panel2);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(420, 34);
            this.pnTop.TabIndex = 56;
            this.pnTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnTop_MouseDown);
            // 
            // btCerrar
            // 
            this.btCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCerrar.FlatAppearance.BorderSize = 0;
            this.btCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCerrar.IconChar = FontAwesome.Sharp.IconChar.WindowClose;
            this.btCerrar.IconColor = System.Drawing.Color.White;
            this.btCerrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btCerrar.IconSize = 30;
            this.btCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCerrar.Location = new System.Drawing.Point(381, 3);
            this.btCerrar.Margin = new System.Windows.Forms.Padding(0);
            this.btCerrar.Name = "btCerrar";
            this.btCerrar.Size = new System.Drawing.Size(38, 26);
            this.btCerrar.TabIndex = 3;
            this.btCerrar.UseVisualStyleBackColor = true;
            this.btCerrar.Click += new System.EventHandler(this.btCerrar_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(420, 5);
            this.panel2.TabIndex = 8;
            // 
            // UsuarioExternoNueva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(420, 253);
            this.Controls.Add(this.pnTop);
            this.Controls.Add(this.cmbArea);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbNotificar);
            this.Controls.Add(this.tbCorreo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btRegistrar);
            this.Controls.Add(this.tbNombreUsuario);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "UsuarioExternoNueva";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuario Externo Nuevo";
            this.Load += new System.EventHandler(this.CuentaNueva_Load);
            this.pnTop.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNombreUsuario;
        private FontAwesome.Sharp.IconButton btRegistrar;
        private System.Windows.Forms.TextBox tbCorreo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbNotificar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbArea;
        private System.Windows.Forms.Panel pnTop;
        private FontAwesome.Sharp.IconButton btCerrar;
        private System.Windows.Forms.Panel panel2;
    }
}