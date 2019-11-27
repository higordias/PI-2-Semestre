using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.Runtime.InteropServices;
using System.Net.Mail;

namespace PI3
{
    public partial class ScreenForgotLogin : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        string dir_projeto = System.AppContext.BaseDirectory; //variable that holds the database path

        public ScreenForgotLogin()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            var screenLogin = new ScreenLogin();
            screenLogin.Show();
        }

        public void enviarSenhaEmail(string email, string login)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("smarthome.atendimento@gmail.com");
                mail.To.Add(email);
                mail.Subject = "Recuperação de Senha";
                mail.Body = "Seu Login é " + login + ". Guarde-o em local seguro e não compartilhe com ninguém"
                          + Environment.NewLine
                          + "Caso não tenha solicitado a recuperação de login, entre em contato conosco o mais rápido possível"
                          + Environment.NewLine
                          + Environment.NewLine
                          + "Não responda a este email, ele foi gerado automaticamente após uma solicitação pelo aplicativo"
                          + Environment.NewLine
                          + Environment.NewLine
                          + "SMART Home Automation"
                          + Environment.NewLine
                          + "Endereço: Rua 24 de Maio, 761, Centro – Indaiatuba-SP"
                          + Environment.NewLine
                          + "Telefone: 19 3003-4001"
                          + Environment.NewLine
                          + "Email: atedimento@smarthome.com"
                          + Environment.NewLine
                          + "Visite nosso site: www.smarthome.com";

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("smarthome.atendimento@gmail.com", "atendimento1234");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                MessageBox.Show("Login enviado para o email " + email + ".", "Login Enviado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ScreenForgotLogin_Load(object sender, EventArgs e)
        {
            cbPergunta.Items.Clear();
            cbPergunta.Items.Add("Qual seu animal favorito?");
            cbPergunta.Items.Add("Qual o nome da sua primeira escola?");
            cbPergunta.Items.Add("Qual o nome da sua primeira professora?");
            cbPergunta.Items.Add("Qual o seu carro favorito?");
            cbPergunta.Items.Add("Qual o nome do seu primeiro animal de estimação?");
            cbPergunta.Items.Add("Qual a cidade natal de sua avó?");
            cbPergunta.Items.Add("Qual país você mais deseja conhecer?");
            cbPergunta.DropDownStyle = ComboBoxStyle.DropDownList;
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

        private string getInfo(string dado, string tabela, string coluna, string campo, SqlCeConnection cn)
        {
            string info = "";
            SqlCeCommand command = new SqlCeCommand("SELECT " + dado + " FROM " + tabela + " WHERE " + coluna + "='" + campo + "'", cn);
            SqlCeDataAdapter da = new SqlCeDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                info = dr[dado].ToString();
            }
            return info;
        }

        public int countEntries(string tabela, string coluna, string campo, SqlCeConnection cn)
        {
            string check = "SELECT COUNT(*) from " + tabela + " WHERE " + coluna + "='" + campo + "'";
            SqlCeCommand command = new SqlCeCommand(check, cn);
            int count = (int)command.ExecuteScalar();
            return count;
        }

        private void btnRecuperarLogin_Click(object sender, EventArgs e)
        {
            SqlCeConnection cn = new SqlCeConnection(stringConexao());
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }

            if ((tbNome.Text == "") ||
                (tbEmail.Text == "") ||
                (tbRG.Text == "") ||
                (tbCPF.Text == "") ||
                (tbResposta.Text == ""))
            {
                MessageBox.Show("Todos os campos devem ser preenchidos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (tbResposta.Text == "")
                {
                    tbResposta.Focus();
                }
                if (tbCPF.Text == "")
                {
                    tbCPF.Focus();
                }
                if (tbRG.Text == "")
                {
                    tbRG.Focus();
                }
                if (tbEmail.Text == "")
                {
                    tbEmail.Focus();
                }
                if (tbNome.Text == "")
                {
                    tbNome.Focus();
                }
            }
            else
            {
                int countEmail = countEntries("TabelaLogin", "Email", tbEmail.Text, cn);

                if (countEmail <= 0)
                {
                    MessageBox.Show("Email não existe!", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string nome = getInfo("Nome", "TabelaLogin", "Email", tbEmail.Text, cn);
                    string RG = getInfo("RG", "TabelaLogin", "Email", tbEmail.Text, cn);
                    string CPF = getInfo("CPF", "TabelaLogin", "Email", tbEmail.Text, cn);
                    string pergunta = getInfo("Pergunta", "TabelaLogin", "Email", tbEmail.Text, cn);
                    string resposta = getInfo("Resposta", "TabelaLogin", "Email", tbEmail.Text, cn);
                    //string email = getInfo("Email", "TabelaLogin", "Email", tbEmail.Text, cn);
                    MessageBox.Show(nome + Environment.NewLine
                                  + RG + Environment.NewLine
                                  + CPF + Environment.NewLine
                                  + pergunta + Environment.NewLine
                                  + resposta + Environment.NewLine);
                                  //+ email + Environment.NewLine);

                    if ((tbNome.Text == nome) &&
                        (tbRG.Text == RG) &&
                        (tbCPF.Text == CPF) &&
                        (cbPergunta.SelectedItem.ToString() == pergunta) &&
                        (tbResposta.Text == resposta))
                    {
                        string login = getInfo("Login", "TabelaLogin", "Email", tbEmail.Text, cn);

                        enviarSenhaEmail(tbEmail.Text, login);
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                }
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
