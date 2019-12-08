using System;
using System.Windows.Forms;

namespace PI3
{
    public partial class ScreenInformation : Form
    {
        public ScreenInformation()
        {
            InitializeComponent();
        }

        /*
         * Function used to fill the screen with the user informations
         */
        private void ScreenInformation_Load(object sender, EventArgs e)
        {
            lblComponente1.Text      =   Properties.Settings.Default.componente1;
            lblComponente2.Text      =   Properties.Settings.Default.componente2;
            lblComponente3.Text      =   Properties.Settings.Default.componente3;
            lblCodigoInstalacao.Text =   Properties.Settings.Default.codigoInstalacao;
            lblResponsavel.Text      =   Properties.Settings.Default.nomeUsuario;
            lblTelefone.Text         =   Properties.Settings.Default.telefone;
            lblCelular.Text          =   Properties.Settings.Default.celular;
            lblEmail.Text            =   Properties.Settings.Default.email;
            lblEndereco.Text         =   Properties.Settings.Default.endereco;
            lblCidade.Text           =   Properties.Settings.Default.cidade;
            lblEstado.Text           =   Properties.Settings.Default.estado;
            lblUsuarios.Text         =   Properties.Settings.Default.usuarios;
        }
    }
}
