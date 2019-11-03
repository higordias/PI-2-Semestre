﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PI3
{
    public partial class ScreenHome : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public ScreenHome()
        {
            InitializeComponent();
        }

        private void OpenFormInPanel<Forms>() where Forms : Form, new()
        {
            Form formulario;
            formulario = panelContent.Controls.OfType<Forms>().FirstOrDefault();

            if (formulario == null)
            {
                formulario = new Forms();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panelContent.Controls.Add(formulario);
                panelContent.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
            }
            else
            {
                if (formulario.WindowState == FormWindowState.Minimized)
                    formulario.WindowState = FormWindowState.Normal;
                formulario.BringToFront();
            }
        }


        private void PanelHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            foreach (Button btn in panelSideMenu.Controls.OfType<Button>())
            {
                if (btn.Name != "btnInicio")
                {
                    btn.BackColor = Color.MidnightBlue;
                }
                btnInicio.BackColor = Color.Goldenrod;
            }
            OpenFormInPanel<ScreenInicio>();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            DialogResult dialogSairResult = MessageBox.Show("Tem Certeza que deseja sair?", "Deseja Sair?", MessageBoxButtons.YesNo);
            if (dialogSairResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnSuporte_Click(object sender, EventArgs e)
        {
            OpenFormInPanel<ScreenSupport>();
            foreach (Button btn in panelSideMenu.Controls.OfType<Button>())
            {
                if (btn.Name != "btnSuporte")
                {
                    btn.BackColor = Color.MidnightBlue;
                }
                btnSuporte.BackColor = Color.Goldenrod;
            }
        }
    }
}
