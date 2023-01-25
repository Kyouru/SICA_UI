
namespace SICA.Forms.Recibir
{
    partial class UsuarioExternoModificar
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
            this.btRegistrar = new FontAwesome.Sharp.IconButton();
            this.tbCorreo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbNotificar = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(40, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 22);
            this.label2.TabIndex = 47;
            this.label2.Text = "Nombre Usuario:";
            // 
            // tbNombreUsuario
            // 
            this.tbNombreUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNombreUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNombreUsuario.Location = new System.Drawing.Point(198, 15);
            this.tbNombreUsuario.Name = "tbNombreUsuario";
            this.tbNombreUsuario.Size = new System.Drawing.Size(179, 24);
            this.tbNombreUsuario.TabIndex = 2;
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
            this.btRegistrar.Location = new System.Drawing.Point(103, 130);
            this.btRegistrar.Name = "btRegistrar";
            this.btRegistrar.Size = new System.Drawing.Size(217, 32);
            this.btRegistrar.TabIndex = 14;
            this.btRegistrar.Text = "Registrar";
            this.btRegistrar.UseVisualStyleBackColor = true;
            this.btRegistrar.Click += new System.EventHandler(this.btRegistrar_Click);
            // 
            // tbCorreo
            // 
            this.tbCorreo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCorreo.Location = new System.Drawing.Point(198, 45);
            this.tbCorreo.Name = "tbCorreo";
            this.tbCorreo.Size = new System.Drawing.Size(179, 24);
            this.tbCorreo.TabIndex = 50;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(40, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 22);
            this.label3.TabIndex = 51;
            this.label3.Text = "Email:";
            // 
            // cbNotificar
            // 
            this.cbNotificar.AutoSize = true;
            this.cbNotificar.Font = new System.Drawing.Font("Arial", 14F);
            this.cbNotificar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cbNotificar.Location = new System.Drawing.Point(160, 87);
            this.cbNotificar.Name = "cbNotificar";
            this.cbNotificar.Size = new System.Drawing.Size(98, 26);
            this.cbNotificar.TabIndex = 52;
            this.cbNotificar.Text = "Notificar";
            this.cbNotificar.UseVisualStyleBackColor = true;
            // 
            // UsuarioExternoModificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(420, 174);
            this.Controls.Add(this.cbNotificar);
            this.Controls.Add(this.tbCorreo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btRegistrar);
            this.Controls.Add(this.tbNombreUsuario);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "UsuarioExternoModificar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuario Externo Modificar";
            this.Load += new System.EventHandler(this.UsuarioExternoModificar_Load);
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
    }
}