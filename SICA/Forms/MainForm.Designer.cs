namespace SICA
{
    partial class MainForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pnLeft = new System.Windows.Forms.Panel();
            this.btMantenimiento = new FontAwesome.Sharp.IconButton();
            this.btReporte = new FontAwesome.Sharp.IconButton();
            this.btPrestar = new FontAwesome.Sharp.IconButton();
            this.btMover = new FontAwesome.Sharp.IconButton();
            this.btValija = new FontAwesome.Sharp.IconButton();
            this.btPendiente = new FontAwesome.Sharp.IconButton();
            this.btBusqueda = new FontAwesome.Sharp.IconButton();
            this.icMain = new FontAwesome.Sharp.IconPictureBox();
            this.pnTop = new System.Windows.Forms.Panel();
            this.lbTiempoSesion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbUsuario = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btMinimizar = new FontAwesome.Sharp.IconButton();
            this.btCerrar = new FontAwesome.Sharp.IconButton();
            this.pnMain = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tmUltimaActividad = new System.Windows.Forms.Timer(this.components);
            this.pnLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icMain)).BeginInit();
            this.pnTop.SuspendLayout();
            this.pnMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnLeft
            // 
            this.pnLeft.Controls.Add(this.btMantenimiento);
            this.pnLeft.Controls.Add(this.btReporte);
            this.pnLeft.Controls.Add(this.btPrestar);
            this.pnLeft.Controls.Add(this.btMover);
            this.pnLeft.Controls.Add(this.btValija);
            this.pnLeft.Controls.Add(this.btPendiente);
            this.pnLeft.Controls.Add(this.btBusqueda);
            this.pnLeft.Controls.Add(this.icMain);
            this.pnLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnLeft.Location = new System.Drawing.Point(0, 0);
            this.pnLeft.Name = "pnLeft";
            this.pnLeft.Size = new System.Drawing.Size(200, 746);
            this.pnLeft.TabIndex = 0;
            // 
            // btMantenimiento
            // 
            this.btMantenimiento.Dock = System.Windows.Forms.DockStyle.Top;
            this.btMantenimiento.FlatAppearance.BorderSize = 0;
            this.btMantenimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btMantenimiento.Font = new System.Drawing.Font("Arial", 15.75F);
            this.btMantenimiento.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btMantenimiento.IconChar = FontAwesome.Sharp.IconChar.FileSignature;
            this.btMantenimiento.IconColor = System.Drawing.Color.Gainsboro;
            this.btMantenimiento.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btMantenimiento.IconSize = 30;
            this.btMantenimiento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btMantenimiento.Location = new System.Drawing.Point(0, 436);
            this.btMantenimiento.Name = "btMantenimiento";
            this.btMantenimiento.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btMantenimiento.Size = new System.Drawing.Size(200, 61);
            this.btMantenimiento.TabIndex = 6;
            this.btMantenimiento.Text = "Mantenimiento";
            this.btMantenimiento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btMantenimiento.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btMantenimiento.UseVisualStyleBackColor = true;
            this.btMantenimiento.Visible = false;
            this.btMantenimiento.Click += new System.EventHandler(this.btMantenimiento_Click);
            // 
            // btReporte
            // 
            this.btReporte.Dock = System.Windows.Forms.DockStyle.Top;
            this.btReporte.FlatAppearance.BorderSize = 0;
            this.btReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btReporte.Font = new System.Drawing.Font("Arial", 15.75F);
            this.btReporte.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btReporte.IconChar = FontAwesome.Sharp.IconChar.ChartPie;
            this.btReporte.IconColor = System.Drawing.Color.Gainsboro;
            this.btReporte.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btReporte.IconSize = 30;
            this.btReporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btReporte.Location = new System.Drawing.Point(0, 375);
            this.btReporte.Name = "btReporte";
            this.btReporte.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btReporte.Size = new System.Drawing.Size(200, 61);
            this.btReporte.TabIndex = 5;
            this.btReporte.Text = "Reporte";
            this.btReporte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btReporte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btReporte.UseVisualStyleBackColor = true;
            this.btReporte.Visible = false;
            this.btReporte.Click += new System.EventHandler(this.btReporte_Click);
            // 
            // btPrestar
            // 
            this.btPrestar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btPrestar.FlatAppearance.BorderSize = 0;
            this.btPrestar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPrestar.Font = new System.Drawing.Font("Arial", 15.75F);
            this.btPrestar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btPrestar.IconChar = FontAwesome.Sharp.IconChar.Cat;
            this.btPrestar.IconColor = System.Drawing.Color.Gainsboro;
            this.btPrestar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btPrestar.IconSize = 30;
            this.btPrestar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPrestar.Location = new System.Drawing.Point(0, 314);
            this.btPrestar.Name = "btPrestar";
            this.btPrestar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btPrestar.Size = new System.Drawing.Size(200, 61);
            this.btPrestar.TabIndex = 4;
            this.btPrestar.Text = "Prestar";
            this.btPrestar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPrestar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btPrestar.UseVisualStyleBackColor = true;
            this.btPrestar.Visible = false;
            this.btPrestar.Click += new System.EventHandler(this.btPrestar_Click);
            // 
            // btMover
            // 
            this.btMover.Dock = System.Windows.Forms.DockStyle.Top;
            this.btMover.FlatAppearance.BorderSize = 0;
            this.btMover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btMover.Font = new System.Drawing.Font("Arial", 15.75F);
            this.btMover.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btMover.IconChar = FontAwesome.Sharp.IconChar.LuggageCart;
            this.btMover.IconColor = System.Drawing.Color.Gainsboro;
            this.btMover.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btMover.IconSize = 30;
            this.btMover.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btMover.Location = new System.Drawing.Point(0, 253);
            this.btMover.Name = "btMover";
            this.btMover.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btMover.Size = new System.Drawing.Size(200, 61);
            this.btMover.TabIndex = 3;
            this.btMover.Text = "Mover";
            this.btMover.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btMover.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btMover.UseVisualStyleBackColor = true;
            this.btMover.Visible = false;
            this.btMover.Click += new System.EventHandler(this.btMover_Click);
            // 
            // btValija
            // 
            this.btValija.Dock = System.Windows.Forms.DockStyle.Top;
            this.btValija.FlatAppearance.BorderSize = 0;
            this.btValija.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btValija.Font = new System.Drawing.Font("Arial", 15.75F);
            this.btValija.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btValija.IconChar = FontAwesome.Sharp.IconChar.FileDownload;
            this.btValija.IconColor = System.Drawing.Color.Gainsboro;
            this.btValija.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btValija.IconSize = 30;
            this.btValija.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btValija.Location = new System.Drawing.Point(0, 192);
            this.btValija.Name = "btValija";
            this.btValija.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btValija.Size = new System.Drawing.Size(200, 61);
            this.btValija.TabIndex = 2;
            this.btValija.Text = "Valija";
            this.btValija.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btValija.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btValija.UseVisualStyleBackColor = true;
            this.btValija.Visible = false;
            this.btValija.Click += new System.EventHandler(this.btValija_Click);
            // 
            // btPendiente
            // 
            this.btPendiente.Dock = System.Windows.Forms.DockStyle.Top;
            this.btPendiente.FlatAppearance.BorderSize = 0;
            this.btPendiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPendiente.Font = new System.Drawing.Font("Arial", 15.75F);
            this.btPendiente.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btPendiente.IconChar = FontAwesome.Sharp.IconChar.CheckDouble;
            this.btPendiente.IconColor = System.Drawing.Color.Gainsboro;
            this.btPendiente.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btPendiente.IconSize = 30;
            this.btPendiente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPendiente.Location = new System.Drawing.Point(0, 131);
            this.btPendiente.Name = "btPendiente";
            this.btPendiente.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btPendiente.Size = new System.Drawing.Size(200, 61);
            this.btPendiente.TabIndex = 1;
            this.btPendiente.Text = "Pendiente";
            this.btPendiente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPendiente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btPendiente.UseVisualStyleBackColor = true;
            this.btPendiente.Visible = false;
            this.btPendiente.Click += new System.EventHandler(this.btPendiente_Click);
            // 
            // btBusqueda
            // 
            this.btBusqueda.Dock = System.Windows.Forms.DockStyle.Top;
            this.btBusqueda.FlatAppearance.BorderSize = 0;
            this.btBusqueda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBusqueda.Font = new System.Drawing.Font("Arial", 15.75F);
            this.btBusqueda.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btBusqueda.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btBusqueda.IconColor = System.Drawing.Color.Gainsboro;
            this.btBusqueda.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btBusqueda.IconSize = 30;
            this.btBusqueda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btBusqueda.Location = new System.Drawing.Point(0, 70);
            this.btBusqueda.Name = "btBusqueda";
            this.btBusqueda.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btBusqueda.Size = new System.Drawing.Size(200, 61);
            this.btBusqueda.TabIndex = 0;
            this.btBusqueda.Text = "Busqueda";
            this.btBusqueda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btBusqueda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btBusqueda.UseVisualStyleBackColor = true;
            this.btBusqueda.Visible = false;
            this.btBusqueda.Click += new System.EventHandler(this.btBusqueda_Click);
            // 
            // icMain
            // 
            this.icMain.BackColor = System.Drawing.Color.MidnightBlue;
            this.icMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("icMain.BackgroundImage")));
            this.icMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.icMain.ForeColor = System.Drawing.SystemColors.ControlText;
            this.icMain.IconChar = FontAwesome.Sharp.IconChar.None;
            this.icMain.IconColor = System.Drawing.SystemColors.ControlText;
            this.icMain.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icMain.IconSize = 70;
            this.icMain.Location = new System.Drawing.Point(0, 0);
            this.icMain.Name = "icMain";
            this.icMain.Size = new System.Drawing.Size(200, 70);
            this.icMain.TabIndex = 0;
            this.icMain.TabStop = false;
            this.icMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.icMain_MouseDown);
            // 
            // pnTop
            // 
            this.pnTop.BackColor = System.Drawing.Color.MidnightBlue;
            this.pnTop.Controls.Add(this.lbTiempoSesion);
            this.pnTop.Controls.Add(this.label2);
            this.pnTop.Controls.Add(this.panel2);
            this.pnTop.Controls.Add(this.lbUsuario);
            this.pnTop.Controls.Add(this.label1);
            this.pnTop.Controls.Add(this.btMinimizar);
            this.pnTop.Controls.Add(this.btCerrar);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(5, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1129, 34);
            this.pnTop.TabIndex = 1;
            this.pnTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnTop_MouseDown);
            // 
            // lbTiempoSesion
            // 
            this.lbTiempoSesion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTiempoSesion.AutoSize = true;
            this.lbTiempoSesion.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbTiempoSesion.Location = new System.Drawing.Point(787, 10);
            this.lbTiempoSesion.Name = "lbTiempoSesion";
            this.lbTiempoSesion.Size = new System.Drawing.Size(34, 13);
            this.lbTiempoSesion.TabIndex = 44;
            this.lbTiempoSesion.Text = "00:00";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(690, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "Tiempo Restante:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1129, 5);
            this.panel2.TabIndex = 8;
            // 
            // lbUsuario
            // 
            this.lbUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbUsuario.AutoSize = true;
            this.lbUsuario.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbUsuario.Location = new System.Drawing.Point(902, 10);
            this.lbUsuario.Name = "lbUsuario";
            this.lbUsuario.Size = new System.Drawing.Size(109, 13);
            this.lbUsuario.TabIndex = 7;
            this.lbUsuario.Text = "NOMBRE_USUARIO";
            this.lbUsuario.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbUsuario_MouseDown);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(850, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Usuario:";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            // 
            // btMinimizar
            // 
            this.btMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btMinimizar.FlatAppearance.BorderSize = 0;
            this.btMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btMinimizar.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.btMinimizar.IconColor = System.Drawing.Color.White;
            this.btMinimizar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btMinimizar.IconSize = 24;
            this.btMinimizar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btMinimizar.Location = new System.Drawing.Point(1076, 0);
            this.btMinimizar.Margin = new System.Windows.Forms.Padding(0);
            this.btMinimizar.Name = "btMinimizar";
            this.btMinimizar.Size = new System.Drawing.Size(26, 23);
            this.btMinimizar.TabIndex = 5;
            this.btMinimizar.UseVisualStyleBackColor = true;
            this.btMinimizar.Click += new System.EventHandler(this.btMinimizar_Click);
            // 
            // btCerrar
            // 
            this.btCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCerrar.FlatAppearance.BorderSize = 0;
            this.btCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCerrar.IconChar = FontAwesome.Sharp.IconChar.WindowClose;
            this.btCerrar.IconColor = System.Drawing.Color.White;
            this.btCerrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btCerrar.IconSize = 24;
            this.btCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCerrar.Location = new System.Drawing.Point(1102, 0);
            this.btCerrar.Margin = new System.Windows.Forms.Padding(0);
            this.btCerrar.Name = "btCerrar";
            this.btCerrar.Size = new System.Drawing.Size(26, 23);
            this.btCerrar.TabIndex = 3;
            this.btCerrar.UseVisualStyleBackColor = true;
            this.btCerrar.Click += new System.EventHandler(this.btCerrar_Click);
            // 
            // pnMain
            // 
            this.pnMain.Controls.Add(this.pnTop);
            this.pnMain.Controls.Add(this.panel1);
            this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMain.Location = new System.Drawing.Point(200, 0);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(1134, 746);
            this.pnMain.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 746);
            this.panel1.TabIndex = 12;
            // 
            // tmUltimaActividad
            // 
            this.tmUltimaActividad.Enabled = true;
            this.tmUltimaActividad.Interval = 1000;
            this.tmUltimaActividad.Tick += new System.EventHandler(this.tmUltimaActividad_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1334, 746);
            this.Controls.Add(this.pnMain);
            this.Controls.Add(this.pnLeft);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.icMain)).EndInit();
            this.pnTop.ResumeLayout(false);
            this.pnTop.PerformLayout();
            this.pnMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnLeft;
        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.Panel pnMain;
        private FontAwesome.Sharp.IconPictureBox icMain;
        private FontAwesome.Sharp.IconButton btMinimizar;
        private FontAwesome.Sharp.IconButton btCerrar;
        private System.Windows.Forms.Label lbUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Timer tmUltimaActividad;
        private System.Windows.Forms.Label lbTiempoSesion;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton btPendiente;
        private FontAwesome.Sharp.IconButton btBusqueda;
        private FontAwesome.Sharp.IconButton btValija;
        private FontAwesome.Sharp.IconButton btMover;
        private FontAwesome.Sharp.IconButton btMantenimiento;
        private FontAwesome.Sharp.IconButton btReporte;
        private FontAwesome.Sharp.IconButton btPrestar;
    }
}

