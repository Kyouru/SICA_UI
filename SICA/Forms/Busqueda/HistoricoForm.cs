﻿using FontAwesome.Sharp;
using SICA.Forms.Busqueda;
using SICA.Forms.Busqueda.Historico;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SICA.GlobalFunctions;

namespace SICA.Forms
{
    public partial class HistoricoForm : Form
    {
        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private IconButton currentBtn;
        private Form currentChildForm;

        public HistoricoForm()
        {
            GlobalFunctions.UltimaActividad();
            InitializeComponent();

            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private void HistoricoForm_Load(object sender, EventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            //btEditar.Visible = int2bool(Globals.BusquedaEditar);
        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            EditarForm ef = new EditarForm();
            ef.ShowDialog();
        }

        private void btMovimiento_Click(object sender, EventArgs e)
        {

            GlobalFunctions.UltimaActividad();
            ActivateButton(sender, RGBColors.color4);
            OpenChildForm(new HistoricoMovimiento());
        }

        private void btHistoricoEdicion_Click(object sender, EventArgs e)
        {

            GlobalFunctions.UltimaActividad();
            ActivateButton(sender, RGBColors.color4);
            OpenChildForm(new HistoricoEdicion());
        }
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(0, 0, 64);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(0, 0, 64);
                currentBtn.ForeColor = color;
                currentBtn.FlatAppearance.BorderSize = 0;
                currentBtn.IconColor = color;
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.MidnightBlue;
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.FlatAppearance.BorderSize = 1;
                //currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                //currentBtn.IconColor = Color.Gainsboro;
                //currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                //currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
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
            pnSubMain.Controls.Add(childForm);
            pnSubMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            //lblTitleChildForm.Text = childForm.Text;
        }

        private void btHistorico_Click(object sender, EventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            ActivateButton(sender, RGBColors.color4);
            OpenChildForm(new HistoricoGeneral());
        }

        private void btCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void moverVentana()
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pnTop_MouseDown(object sender, MouseEventArgs e)
        {
            moverVentana();
        }
    }
}
