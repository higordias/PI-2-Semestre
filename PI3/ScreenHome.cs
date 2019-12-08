using System;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Linq;
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

        /*
         * Fuction used to open a form inside a dock in the screenHome
         * @param Forms form to be opened
         */
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
                {
                    formulario.WindowState = FormWindowState.Normal;
                }
                formulario.BringToFront();
            }
        }

        /*
         * Fuction used to move the window by clicking and holding the top dock
         */
        private void PanelHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        /*
         * Button btnInicio action
         */
        private void btnInicio_Click(object sender, EventArgs e)
        {
            foreach (Button btn in panelSideMenu.Controls.OfType<Button>())
            {
                if (btn.Name != "btnInicio")
                {
                    btn.BackColor = Color.MidnightBlue;
                    btn.Enabled = true;
                }
                btnInicio.BackColor = Color.Goldenrod;
                btnInicio.Enabled = false;
            }
            OpenFormInPanel<ScreenButtons>();
        }

        /*
         * Button btnSair action
         */
        private void btnSair_Click(object sender, EventArgs e)
        {
            DialogResult dialogSairResult = MessageBox.Show("Tem Certeza que deseja sair?", "Deseja Sair?", MessageBoxButtons.YesNo);
            if (dialogSairResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        /*
        * Button btnSuporte action
        */
        private void btnSuporte_Click(object sender, EventArgs e)
        {
            foreach (Button btn in panelSideMenu.Controls.OfType<Button>())
            {
                if (btn.Name != "btnSuporte")
                {
                    btn.BackColor = Color.MidnightBlue;
                    btn.Enabled = true;
                }
                btnSuporte.BackColor = Color.Goldenrod;
                btnSuporte.Enabled = false;
            }
            OpenFormInPanel<ScreenSupport>();
        }

        /*
        * Button btnInformacoes action
        */
        private void btnInformacoes_Click(object sender, EventArgs e)
        {
            foreach (Button btn in panelSideMenu.Controls.OfType<Button>())
            {
                if (btn.Name != "btnInformacoes")
                {
                    btn.BackColor = Color.MidnightBlue;
                    btn.Enabled = true;
                }
                btnInformacoes.BackColor = Color.Goldenrod;
                btnInformacoes.Enabled = false;
            }
            OpenFormInPanel<ScreenInformation>();
        }

        /*
        * Button btnCartoesRFID action
        */
        private void btnCartoesRFID_Click(object sender, EventArgs e)
        {
            foreach (Button btn in panelSideMenu.Controls.OfType<Button>())
            {
                if (btn.Name != "btnCartoesRFID")
                {
                    btn.BackColor = Color.MidnightBlue;
                    btn.Enabled = true;
                }
                btnCartoesRFID.BackColor = Color.Goldenrod;
                btnCartoesRFID.Enabled = false;
            }
            OpenFormInPanel<ScreenRFIDTags>();
        }

        /*
        * Button btnRelatorios action
        */
        private void btnRelatorios_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.privilegio == "Adm")
            {
                foreach (Button btn in panelSideMenu.Controls.OfType<Button>())
                {
                    if (btn.Name != "btnRelatorios")
                    {
                        btn.BackColor = Color.MidnightBlue;
                        btn.Enabled = true;
                    }
                    btnRelatorios.BackColor = Color.Goldenrod;
                    btnRelatorios.Enabled = false;
                }
                OpenFormInPanel<ScreenReport>();
            }
            else
            {
                MessageBox.Show("Apenas usuários com privilégios de administrador podem acessar esta opção!", "Erro de permissão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
