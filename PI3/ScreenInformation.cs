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

namespace PI3
{
    public partial class ScreenInformation : Form
    {
        string dir_projeto = System.AppContext.BaseDirectory; //variable that holds the database path
        public ScreenInformation()
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
