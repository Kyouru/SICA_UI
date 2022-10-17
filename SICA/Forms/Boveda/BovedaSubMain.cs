﻿using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SICA.GlobalFunctions;

namespace SICA.Forms.Boveda
{
    public partial class BovedaSubMain : Form
    {
        private IconButton currentBtn;
        private Panel topBorderBtn;
        private Form currentChildForm;
        public BovedaSubMain()
        {
            InitializeComponent();

            topBorderBtn = new Panel();
            topBorderBtn.Size = new Size(250, 3);
            pnTop.Controls.Add(topBorderBtn);

            btGuardarCaja.Visible = int2bool(Globals.auBovedaCajaGuardar);
            btGuardarDoc.Visible = int2bool(Globals.auBovedaDocumentoGuardar);
            btRetirarCaja.Visible = int2bool(Globals.auBovedaCajaRetirar);
            btRetirarDoc.Visible = int2bool(Globals.auBovedaDocumentoRetirar);
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
                //currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                //currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                //currentBtn.ImageAlign = ContentAlignment.MiddleRight;

                topBorderBtn.BackColor = color;
                topBorderBtn.Location = new Point(currentBtn.Location.X, 0);
                topBorderBtn.Visible = true;
                topBorderBtn.BringToFront();
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
                currentBtn.FlatAppearance.BorderSize = 1;
                //currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                //currentBtn.IconColor = Color.Gainsboro;
                //currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                //currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
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

        private void btRetirar_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            OpenChildForm(new BovedaRetirarDoc());
        }

        private void btGuardarDoc_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            OpenChildForm(new BovedaGuardarDoc());
        }

        private void btGuardarCaja_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            OpenChildForm(new BovedaGuardarCaja());
        }

        private void btRetirarCaja_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            OpenChildForm(new BovedaRetirarCaja());
        }
    }
}
