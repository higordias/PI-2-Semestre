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
    public partial class ScreenForgotPassword : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        string dir_projeto = System.AppContext.BaseDirectory; //variable that holds the database path

        public ScreenForgotPassword()
        {
            InitializeComponent();
        }

        public void enviarSenhaEmail(string email, string senha)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("smarthome.atendimento@gmail.com");
                mail.To.Add(email);
                mail.Subject = "Recuperação de Senha";
                mail.Body = "Sua senha é " + senha + ". Guarde-a em local seguro e não compartilhe com ninguém"
                          + Environment.NewLine
                          + "Caso não tenha solicitado a troca da senha, entre em contato conosco o mais rápido possível"
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
                MessageBox.Show("Senha enviada para o email " + email + ".", "Senha Enviada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ScreenForgotPassword_Load(object sender, EventArgs e)
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            var screenLogin = new ScreenLogin();
            screenLogin.Show();
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


        private void btnRecuperarSenha_Click(object sender, EventArgs e)
        {
            SqlCeConnection cn = new SqlCeConnection(stringConexao());
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }

            if ((tbNome.Text == "") || 
                (tbLogin.Text == "") ||
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
                if (tbLogin.Text == "")
                {
                    tbLogin.Focus();
                }
                if (tbNome.Text == "")
                {
                    tbNome.Focus();
                }
            }
            else
            {
                int countLogin = countEntries("TabelaLogin", "Login", tbLogin.Text, cn);

                if (countLogin <= 0)
                {
                    MessageBox.Show("Login não existe!", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string nome = getInfo("Nome", "TabelaLogin", "Login", tbLogin.Text, cn);
                    //string login = getInfo("Login", "TabelaLogin", "Nome", tbLogin.Text, cn);
                    string RG = getInfo("RG", "TabelaLogin", "Login", tbLogin.Text, cn);
                    string CPF = getInfo("CPF", "TabelaLogin", "Login", tbLogin.Text, cn);
                    string pergunta = getInfo("Pergunta", "TabelaLogin", "Login", tbLogin.Text, cn);
                    string resposta = getInfo("Resposta", "TabelaLogin", "Login", tbLogin.Text, cn);
                    string email = getInfo("Email", "TabelaLogin", "Login", tbLogin.Text, cn);
                    MessageBox.Show(nome + Environment.NewLine
                                  + RG + Environment.NewLine
                                  + CPF + Environment.NewLine
                                  + pergunta + Environment.NewLine
                                  + resposta + Environment.NewLine
                                  + email + Environment.NewLine);

                    if ((tbNome.Text == nome) && 
                        (tbRG.Text == RG) &&
                        (tbCPF.Text == CPF) &&
                        (tbEmail.Text == email) &&
                        (cbPergunta.SelectedItem.ToString() == pergunta) &&
                        (tbResposta.Text == resposta))
                    {
                        string senhaHex = getInfo("Senha", "TabelaLogin", "Login", tbLogin.Text, cn);
                        string senha = "";

                        for (int i = 0; i < senhaHex.Length / 2; i++)
                        {
                            senha += Char.ConvertFromUtf32(Convert.ToInt32(senhaHex.Substring(i * 2, 2), 16));
                        }

                        enviarSenhaEmail(tbEmail.Text, senha);
                        //MessageBox.Show("A senha para o login " + tbLogin.Text + " é " + senha, "Recuperação de Senha", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
