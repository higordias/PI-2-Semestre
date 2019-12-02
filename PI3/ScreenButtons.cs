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
    public partial class ScreenButtons : Form
    {
        bool estadoLampada = false; // false --> lampada apagada, true --> lampada acesa
        bool janelaAutomatica = false; // false --> janela manual, true --> janela automatica
        string dir_projeto = System.AppContext.BaseDirectory;
        MqttClient client;
        readonly string clientId;

        public ScreenButtons()
        {
            InitializeComponent();

            btnLigarLampada.BackgroundImage = Image.FromFile(dir_projeto + "images\\StatusLoading.png");
            btnLigarLampada.BackgroundImageLayout = ImageLayout.Center;

            btnAutoManual.BackgroundImage = Image.FromFile(dir_projeto + "images\\StatusLoading.png");
            btnAutoManual.BackgroundImageLayout = ImageLayout.Center;

            string BrokerAddress = "broker.hivemq.com";

            client = new MqttClient(BrokerAddress);

            client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

            // use a unique id as client id, each time we start the application
            clientId = Guid.NewGuid().ToString();

            client.Connect(clientId);
            mqttSubscribe();

            string requestStatusTopic = Properties.Settings.Default.codigoCliente + "/Casa/Status";
            client.Publish(requestStatusTopic, Encoding.UTF8.GetBytes("1"), MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE, false);
        }

        private void setButtonLampada()
        {
            if (!estadoLampada)
            {
                btnLigarLampada.BackgroundImage = Image.FromFile(dir_projeto + "images\\lampadaOff.png");
                btnLigarLampada.BackgroundImageLayout = ImageLayout.Center;
            }
            else
            {
                btnLigarLampada.BackgroundImage = Image.FromFile(dir_projeto + "images\\lampadaOn.png");
                btnLigarLampada.BackgroundImageLayout = ImageLayout.Center;
            }
        }

        private void setButtonAutoManual()
        {
            if (!janelaAutomatica)
            {
                btnAutoManual.BackgroundImage = Image.FromFile(dir_projeto + "images\\Manual.png");
                btnAutoManual.BackgroundImageLayout = ImageLayout.Center;
                janelaAutomatica = true;
            }
            else
            {
                btnAutoManual.BackgroundImage = Image.FromFile(dir_projeto + "images\\Automatico.png");
                btnAutoManual.BackgroundImageLayout = ImageLayout.Center;
                janelaAutomatica = false;
            }
        }

        public void mqttSubscribe()
        {
            // whole topic
            string Topic = Properties.Settings.Default.codigoCliente + "/Casa/#";
            // subscribe to the topic with QoS 0
            client.Subscribe(new string[] { Topic }, new byte[] { 0 });
        }

        private void BtnLigarLampada_Click(object sender, EventArgs e)
        {

            string lampadaTopic = Properties.Settings.Default.codigoCliente + "/Casa/Light";
            if (!estadoLampada)
            {
                btnLigarLampada.BackgroundImage = Image.FromFile(dir_projeto + "images\\lampadaOn.png");
                client.Publish(lampadaTopic, Encoding.UTF8.GetBytes("1"), MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE, false);
                btnLigarLampada.BackgroundImageLayout = ImageLayout.Center;
                estadoLampada = true;
            }
            else
            {
                btnLigarLampada.BackgroundImage = Image.FromFile(dir_projeto + "images\\lampadaOff.png");
                client.Publish(lampadaTopic, Encoding.UTF8.GetBytes("0"), MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE, false);
                btnLigarLampada.BackgroundImageLayout = ImageLayout.Center;
                estadoLampada = false;
            }
        }

        private void btnAutoManual_Click(object sender, EventArgs e)
        {
            string autoManualTopic = Properties.Settings.Default.codigoCliente + "/Casa/autoManual";
            client.Publish(autoManualTopic, Encoding.UTF8.GetBytes("1"), MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE, false);

            if (!janelaAutomatica)
            {
                btnAutoManual.BackgroundImage = Image.FromFile(dir_projeto + "images\\Manual.png");
                btnAutoManual.BackgroundImageLayout = ImageLayout.Center;
                btnFecharJanela.Enabled = true;
                btnAbrirJanela.Enabled = true;
                janelaAutomatica = true;
            }
            else
            {
                btnAutoManual.BackgroundImage = Image.FromFile(dir_projeto + "images\\Automatico.png");
                btnAutoManual.BackgroundImageLayout = ImageLayout.Center;
                btnFecharJanela.Enabled = false;
                btnAbrirJanela.Enabled = false;
                janelaAutomatica = false;
            }
        }

        void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            string ReceivedMessage = Encoding.UTF8.GetString(e.Message);
            if (e.Topic == Properties.Settings.Default.codigoCliente + "/Casa/LampadaStatus")
            {
                if (ReceivedMessage == "1")
                {
                    estadoLampada = true;
                }
                else if (ReceivedMessage == "0")
                {
                    estadoLampada = false;
                }
                setButtonLampada();
            }
            if (e.Topic == Properties.Settings.Default.codigoCliente + "/Casa/JanelaAutomaticaStatus")
            {
                if (ReceivedMessage == "1")
                {
                    janelaAutomatica = true;
                }
                else if (ReceivedMessage == "0")
                {
                    janelaAutomatica = false;
                }
                setButtonAutoManual();
            }
            if (e.Topic == Properties.Settings.Default.codigoCliente + "/Casa/LampadaResposta")
            {
                if (ReceivedMessage == "1")
                {
                    estadoLampada = false;
                }
                else if (ReceivedMessage == "0")
                {
                    estadoLampada = true;
                }
                setButtonLampada();
            }
            if(e.Topic == Properties.Settings.Default.codigoCliente + "/Casa/JanelaResposta")
            {
                if (ReceivedMessage == "1")
                {
                    janelaAutomatica = true;
                }
                else if (ReceivedMessage == "0")
                {
                    janelaAutomatica = false;
                }
                setButtonAutoManual();
            }
        }

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

        private void btnUnlockDoor_Click(object sender, EventArgs e)
        {
            string unlockDoorTopic = Properties.Settings.Default.codigoCliente + "/Casa/DoorUnlock";
            client.Publish(unlockDoorTopic, Encoding.UTF8.GetBytes("1"), MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE, false);
        }

        private void btnFecharJanela_Click(object sender, EventArgs e)
        {
            string closeWindowTopic = Properties.Settings.Default.codigoCliente + "/Casa/closeWindow";
            client.Publish(closeWindowTopic, Encoding.UTF8.GetBytes("1"), MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE, false);
        }

        private void btnAbrirJanela_Click(object sender, EventArgs e)
        {
            string openWindowTopic = Properties.Settings.Default.codigoCliente + "/Casa/openWindow";
            client.Publish(openWindowTopic, Encoding.UTF8.GetBytes("1"), MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE, false);
        }
    }
}
