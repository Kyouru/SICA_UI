using FontAwesome.Sharp;
using SICA.Forms;
using SICA.Forms.Boveda;
using SICA.Forms.DocuClass;
using SICA.Forms.Entregar;
using SICA.Forms.IronMountain;
using SICA.Forms.Letras;
using SICA.Forms.Mantenimiento;
using SICA.Forms.Pagare;
using SICA.Forms.Recibir;
using SICA.Forms.Pendiente;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static SICA.GlobalFunctions;
using SICA.Forms.Reporte;
using SICA.Forms.Prestar;

namespace SICA
{
    public partial class MainForm : Form
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        public MainForm()
        {
            InitializeComponent();

            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            pnLeft.Controls.Add(leftBorderBtn);

            //Form
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            lbUsuario.Text = Globals.Username;
        }

        private void OpenChildForm(Form childForm)
        {
            //open only form
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;

            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnMain.Controls.Add(childForm);
            pnMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            //lblTitleChildForm.Text = childForm.Text;
        }

        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                //currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                //currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                //currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //Current Child Form Icon
                //iconCurrentChildForm.IconChar = currentBtn.IconChar;
                //iconCurrentChildForm.IconColor = color;
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.MidnightBlue;
                currentBtn.ForeColor = Color.Gainsboro;
                //currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                //currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                //currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void pnTop_MouseDown(object sender, MouseEventArgs e)
        {
            moverVentana();
        }
        private void icMain_MouseDown(object sender, MouseEventArgs e)
        {
            moverVentana();
        }
        private void lbEstado_MouseDown(object sender, MouseEventArgs e)
        {
            moverVentana();
        }
        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            moverVentana();
        }
        private void lbUsuario_MouseDown(object sender, MouseEventArgs e)
        {
            moverVentana();
        }

        private void moverVentana()
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //Close-Maximize-Minimize
        private void btCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btMaximizar_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }
        private void btMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }


        private void btBusqueda_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new BusquedaForm());
        }

        private void btValija_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new RecibirSubMain());
        }

        private void btMover_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new EntregarSubMain());
        }

        private void btIronMountain_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new DataManagerSubMain());
        }

        private void btBoveda_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new BovedaSubMain());
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //timer1_Tick(sender, e);
            GlobalFunctions.limpiarTodoCarrito();
            //btBoveda.Visible = int2bool(Globals.auBoveda);
            //btPagare.Visible = int2bool(Globals.auPagare);
            //btLetra.Visible = int2bool(Globals.auLetra);
            //btIronMountain.Visible = int2bool(Globals.auIronMountain);
            //btImportar.Visible = int2bool(Globals.auImportar);
            btMantenimiento.Visible = int2bool(Globals.auMantenimiento);
            btReporte.Visible = int2bool(Globals.auReporte);
            btPrestar.Visible = int2bool(Globals.auPrestar);
            btMover.Visible = int2bool(Globals.auMover);
            btValija.Visible = int2bool(Globals.auValija);
            btBusqueda.Visible = int2bool(Globals.auBusqueda);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            /*
            int n = GlobalFunctions.pendienteConfirmarRecepcion();
            if (n == 0)
            {
                lbEstado.Text = "No tiene documentos por confirmar recepcion";
                lbEstado.ForeColor = Color.Gainsboro;
            }
            else if (n > 0)
            {
                lbEstado.Text = "Tiene " + n.ToString() + " documentos por confirmar recepcion";
                lbEstado.ForeColor = Color.Red;
            }
            else
            {
                timer1.Enabled = false;
            }
            */
        }

        private void btActualizar_Click(object sender, EventArgs e)
        {
            //timer1_Tick(sender, e);
        }

        private void icMain_Click(object sender, EventArgs e)
        {
            InfoForm infoFrm = new InfoForm();
            infoFrm.Show();
        }

        private void btDocuClass_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new DocuClassSubMain());
        }

        private void btLetras_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new LetrasSubMain());
        }

        private void btPagare_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new PagareSubMain());
        }

        private void btImportar_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new ImportarSISGO());
        }

        private void btMantenimiento_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new MantenimientoSubMain());
        }

        private void tmUltimaActividad_Tick(object sender, EventArgs e)
        {
            TimeSpan diff;
            diff = Globals.UltimaActividad.AddMinutes(Globals.SesionDuracion).Subtract(DateTime.Now);
            lbTiempoSesion.Text = diff.ToString("mm':'ss");
            if (DateTime.Now.Subtract(Globals.UltimaActividad).TotalMinutes > Globals.SesionDuracion)
            {
                tmUltimaActividad.Enabled = false;
                this.Close();
                //MessageBox.Show("cerrar");
            }
            else if (DateTime.Now.Subtract(Globals.UltimaActividad).TotalMinutes > Globals.SesionDuracion - Globals.SesionAlerta)
            {
                lbTiempoSesion.ForeColor = Color.Red;
            }
            else
            {
                lbTiempoSesion.ForeColor = Color.White;
            }
        }

        private void btPendiente_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new PendienteSubMain());
        }

        private void btReporte_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new ReporteSubMain());
        }

        private void btPrestar_Click(object sender, EventArgs e)
        {

            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new PrestarSubMain());
        }
    }
}
