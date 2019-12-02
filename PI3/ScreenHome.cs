using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace PI3
{
    public partial class ScreenHome : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        string dir_projeto = System.AppContext.BaseDirectory; //variable that holds the database path

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public ScreenHome()
        {
            InitializeComponent();
        }

        /**
         * stringConexao connects to the database
         **/
        public string stringConexao()
        {
            string connectionString = "";
            try
            {
                string nomeArquivo = @dir_projeto + "\\DB_SmartHomeAutomation.sdf";
                string senha = "";
                connectionString = string.Format("DataSource=\"{0}\"; Password='HomeAutomationDB'", nomeArquivo, senha);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return connectionString;
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
                    btn.Enabled = true;
                }
                btnInicio.BackColor = Color.Goldenrod;
                btnInicio.Enabled = false;
            }
            OpenFormInPanel<ScreenButtons>();
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
                    btn.Enabled = true;
                }
                btnSuporte.BackColor = Color.Goldenrod;
                btnSuporte.Enabled = false;
            }
        }

        private void btnInformacoes_Click(object sender, EventArgs e)
        {
            OpenFormInPanel<ScreenInformation>();
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

        }

        private void btnCartoesRFID_Click(object sender, EventArgs e)
        {
            OpenFormInPanel<ScreenRFIDTags>();
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
        }

        private void btnRelatorios_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.privilegio == "Adm")
            {
                OpenFormInPanel<ScreenReport>();
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
            }
            else
            {
                MessageBox.Show("Apenas usuários com privilégios de administrador podem acessar esta opção!", "Erro de permissão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
