using System;
using System.Windows.Forms;
using System.Net.Mail;

namespace PI3
{
    public partial class ScreenSupport : Form
    {
        public ScreenSupport()
        {
            InitializeComponent();
        }

        private void ScreenSupport_Load(object sender, EventArgs e)
        {
            tbEmail.Text = Properties.Settings.Default.email;
            tbContato.Text = Properties.Settings.Default.telefone + " / " + Properties.Settings.Default.celular;
            tbCodigoCliente.Text = Properties.Settings.Default.codigoInstalacao;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if ((tbEmail.Text == "") ||
                (tbContato.Text == "") ||
                (tbCodigoCliente.Text == "") ||
                (tbAssunto.Text == "") ||
                (tbMensagem.Text == ""))
            {
                MessageBox.Show("Todos os campos são obrigatórios, preencha e tente novamente", "Campo(s) Vazio(s)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (tbMensagem.Text == "")
                {
                    tbMensagem.Focus();
                }
                if (tbAssunto.Text == "")
                {
                    tbAssunto.Focus();
                }
                if (tbCodigoCliente.Text == "")
                {
                    tbCodigoCliente.Focus();
                }
                if (tbContato.Text == "")
                {
                    tbContato.Focus();
                }
                if (tbEmail.Text == "")
                {
                    tbEmail.Focus();
                }
            }
            else
            {
                try
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                    mail.From = new MailAddress("smarthome.atendimento@gmail.com");
                    mail.To.Add("smarthome.atendimento@gmail.com");
                    mail.Subject = tbAssunto.Text;
                    mail.Body = "Sent from:    " + tbEmail.Text + Environment.NewLine
                              + "Client name:  " + Properties.Settings.Default.nomeUsuario + Environment.NewLine
                              + "Phone number: " + tbContato.Text + Environment.NewLine
                              + "Message: " + Environment.NewLine
                              + tbMensagem.Text;

                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("smarthome.atendimento@gmail.com", "atendimento1234");
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);
                    MessageBox.Show("Obrigado pelo contato, reponderemos o mais rápido possível.", "Email Enviado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbAssunto.Text = "";
                    tbMensagem.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
