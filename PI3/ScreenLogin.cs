﻿using System;
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
    public partial class ScreenLogin : Form
    {
        string dir_projeto = System.AppContext.BaseDirectory; //variable that holds the database path

        public ScreenLogin()
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

        private string getUsers(string dado, string tabela, string coluna, string campo, SqlCeConnection cn)
        {
            string info = "";
            SqlCeCommand command = new SqlCeCommand("SELECT " + dado + " FROM " + tabela + " WHERE " + coluna + "='" + campo + "'", cn);
            SqlCeDataAdapter da = new SqlCeDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                info += dr[dado].ToString() + Environment.NewLine;
            }
            return info;
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            SqlCeConnection cn = new SqlCeConnection(stringConexao());
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }

            if ((tbLogin.Text == "") || (tbSenha.Text == ""))
            {
                MessageBox.Show("Digite o login e a senha para logar no sistema!", "Campo Vazio", MessageBoxButtons.OK);
                if (tbSenha.Text == "")
                {
                    tbSenha.Focus();
                }
                if (tbLogin.Text == "")
                {
                    tbLogin.Focus();
                }
            }
            else
            {
                string senhaHex;
                senhaHex = getInfo("Senha", "TabelaLogin", "Login", tbLogin.Text, cn);
                if (senhaHex != "")
                {
                    string senha = "";
                    for (int i = 0; i < senhaHex.Length / 2; i++)
                    {
                        senha += Char.ConvertFromUtf32(Convert.ToInt32(senhaHex.Substring(i * 2, 2), 16));
                    }
                    if (tbSenha.Text == senha)
                    {
                        Properties.Settings.Default.nomeUsuario = getInfo("Nome", "TabelaLogin", "Login", tbLogin.Text, cn);
                        Properties.Settings.Default.codigoInstalacao = getInfo("ModuloInstalado", "TabelaClientes", "Nome", Properties.Settings.Default.nomeUsuario, cn);
                        Properties.Settings.Default.componente1 = getInfo("Componente1", "TabelaKits", "CodigoKit", Properties.Settings.Default.codigoInstalacao, cn);
                        Properties.Settings.Default.componente2 = getInfo("Componente2", "TabelaKits", "CodigoKit", Properties.Settings.Default.codigoInstalacao, cn);
                        Properties.Settings.Default.componente3 = getInfo("Componente3", "TabelaKits", "CodigoKit", Properties.Settings.Default.codigoInstalacao, cn);
                        Properties.Settings.Default.usuarios = getUsers("Login", "TabelaLogin", "Nome", Properties.Settings.Default.nomeUsuario, cn);
                        Properties.Settings.Default.telefone = getInfo("Telefone", "TabelaClientes", "Nome", Properties.Settings.Default.nomeUsuario, cn);
                        Properties.Settings.Default.celular = getInfo("Celular", "TabelaClientes", "Nome", Properties.Settings.Default.nomeUsuario, cn);
                        Properties.Settings.Default.email = getInfo("Email", "TabelaClientes", "Nome", Properties.Settings.Default.nomeUsuario, cn);
                        Properties.Settings.Default.endereco = getInfo("Endereco", "TabelaClientes", "Nome", Properties.Settings.Default.nomeUsuario, cn);
                        Properties.Settings.Default.cidade = getInfo("Cidade", "TabelaClientes", "Nome", Properties.Settings.Default.nomeUsuario, cn);
                        Properties.Settings.Default.estado = getInfo("Estado", "TabelaClientes", "Nome", Properties.Settings.Default.nomeUsuario, cn);
                        Properties.Settings.Default.privilegio = getInfo("Privilegio", tabela:"TabelaLogin", "Nome", Properties.Settings.Default.nomeUsuario, cn);

                        this.Hide();
                        var screenHome = new ScreenHome(); 
                        screenHome.Show();
                    }
                    else
                    {
                        MessageBox.Show("Senha ou usuario invalido!", "Dados Invalidos",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ScreenLogin_Load(object sender, EventArgs e)
        {
            tbSenha.PasswordChar = '*';
        }

        private void lblCliqueAqui_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            var screenSupport = new ScreenSupportLogin();
            screenSupport.Show();
        }

        private void lblEsqueciSenha_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            var screenForgotPassword = new ScreenForgotPassword();
            screenForgotPassword.Show();
        }
    }
}
