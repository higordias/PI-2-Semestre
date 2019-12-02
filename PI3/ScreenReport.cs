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
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.Globalization;

namespace PI3
{
    public partial class ScreenReport : Form
    {
        string dir_projeto = System.AppContext.BaseDirectory; //variable that holds the database path
        MqttClient client;
        readonly string clientId;
        DateTime localDate = DateTime.Now;
        DateTime utcDate = DateTime.UtcNow;
        string cultureName = "pt-br";

        public ScreenReport()
        {
            InitializeComponent();

            string BrokerAddress = "broker.hivemq.com";

            client = new MqttClient(BrokerAddress);

            client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

            // use a unique id as client id, each time we start the application
            clientId = Guid.NewGuid().ToString();

            client.Connect(clientId);
            mqttSubscribe();
        }

        public void mqttSubscribe()
        {
            // whole topic
            string Topic = Properties.Settings.Default.codigoCliente + "/Casa/#";
            // subscribe to the topic with QoS 0
            client.Subscribe(new string[] { Topic }, new byte[] { 0 });
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

        private void addEntryAccess(string Data, string Tag, SqlCeConnection cn)
        {
            SqlCeCommand cmd;
            string sqlRFID = "insert into TabelaAcessos "
                            + "(Data, Tag) "
                            + "values (@Data, @Tag)";
            try
            {
                cmd = new SqlCeCommand(sqlRFID, cn);
                cmd.Parameters.AddWithValue("@Data", Data);
                cmd.Parameters.AddWithValue("@Tag", Tag);
                cmd.ExecuteNonQuery();
            }
            catch (SqlCeException sqlexception)
            {
                MessageBox.Show(sqlexception.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addEntries(string Data, string Tag)
        {
            SqlCeConnection cn = new SqlCeConnection(stringConexao());
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            try
            {
                addEntryAccess(Data, Tag, cn);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            string ReceivedMessage = Encoding.UTF8.GetString(e.Message);
            if (e.Topic == Properties.Settings.Default.codigoCliente + "/Casa/AcessoLiberado")
            {
                var culture = new CultureInfo(cultureName);
                string data = localDate.ToString(culture);
                if (ReceivedMessage == "1")
                {
                    addEntries(data, "cdf9d2e9");
                }
                if (ReceivedMessage == "2")
                {
                    addEntries(data, "e941b863");
                }
                if (ReceivedMessage == "3")
                {
                    addEntries(data, "15aee176");
                }
                if (ReceivedMessage == "4")
                {
                    addEntries(data, "56665a6f");
                }
                if (ReceivedMessage == "Liberacao Remota")
                {
                    addEntries(data, "Lib Remota");
                }
            }
        }

        /**
         * showDataBase will load the database and show it in a grid
         * @tabela: table's name
         * @grid: grid where the table will be showed
         **/
        private void showDataBase(string tabela, DataGridView grid)
        {
            SqlCeConnection cn = new SqlCeConnection(stringConexao());
            if (cn.State == ConnectionState.Closed)
            {
                try
                {
                    cn.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            try
            {
                // define o command para usar a tabela e não a consulta
                SqlCeCommand cmd = new SqlCeCommand(tabela, cn);
                cmd.CommandType = CommandType.TableDirect;
                // Pega a tabela
                SqlCeResultSet rs = cmd.ExecuteResultSet(ResultSetOptions.Scrollable);
                // carrega o resultado no grid 
                grid.DataSource = rs;
            }
            catch (SqlCeException sqlexception)
            {
                MessageBox.Show(sqlexception.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ScreenReport_Load(object sender, EventArgs e)
        {
            showDataBase("TabelaAcessos", dgvAcessos);
        }

        private void btnAtualizarTabela_Click(object sender, EventArgs e)
        {
            showDataBase("TabelaAcessos", dgvAcessos);
        }
    }
}
