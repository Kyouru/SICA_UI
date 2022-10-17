using System;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using SimpleLogger;
using System.IO;
using SICA.Forms;
using System.Net;
using System.Web.Script.Serialization;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using SICA.Clases;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SICA
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            SimpleLog.SetLogFile(".\\Log", "MyLog_");

            //Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void pnTop_MouseDown(object sender, MouseEventArgs e)
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

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                entrar();
            }
        }

        private void btEntrar_Click(object sender, EventArgs e)
        {
            entrar();
        }

        private void entrar()
        {
            if (tbPassword.Text != "" && tbUsername.Text != "")
            {
                try
                {
                    bool ingreso = GlobalFunctions.obtenerToken(tbUsername.Text, tbPassword.Text);
                    if (ingreso)
                        this.Close();
                }
                catch (WebException ex)
                {
                    if (!(ex.Response is null))
                    {
                        using (var stream = ex.Response.GetResponseStream())
                        using (var reader = new StreamReader(stream))
                        {
                            GlobalFunctions.casoError(ex, "Error Login\n" + reader.ReadToEnd());
                        }
                    }
                }
                catch (Exception ex)
                {
                    GlobalFunctions.casoError(ex, "Error Login");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Usuario/Contraseña vacio");
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            
        }

        private void tbUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}