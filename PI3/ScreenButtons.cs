﻿using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace PI3
{
    public partial class ScreenButtons : Form
    {
        bool estadoLampada = false;     // false --> lampada apagada, true --> lampada acesa
        bool janelaAutomatica = false;  // false --> janela manual, true --> janela automatica
        string dir_projeto = System.AppContext.BaseDirectory;   // pasta bin/Debug
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

        /*
         * Function to set the image of the button used to turn the light on/off
         * if the light is turned off, the image of a off light is shown, otherwise a light on image is shown
         */
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

        /*
         * Function to set the image of the button used to turn the window opening/closing
         * automatic or manual. if windows is not automatic, a manual image will be shown,
         * otherwise an auto image is shown
         */
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

        /*
         * Fucntion tha subscribes to the topic ClientCode + "/Casa/#"
         */
        public void mqttSubscribe()
        {
            // whole topic
            string Topic = Properties.Settings.Default.codigoCliente + "/Casa/#";
            // subscribe to the topic with QoS 0
            client.Subscribe(new string[] { Topic }, new byte[] { 0 });
        }

        /*
         * Button btnLigarLampada action
         */
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

        /*
         * Button btnAutoManual action
         */
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

        /*
         * Fuction that treats all mqtt received messages
         */
        void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            string ReceivedMessage = Encoding.UTF8.GetString(e.Message);
            if (e.Topic == Properties.Settings.Default.codigoCliente + "/Casa/LampadaStatus")
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

        /*
         * Fuction to connect to the DataBase
         */
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

        /*
         * Button btnUnlockDoor action
         */
        private void btnUnlockDoor_Click(object sender, EventArgs e)
        {
            string unlockDoorTopic = Properties.Settings.Default.codigoCliente + "/Casa/DoorUnlock";
            client.Publish(unlockDoorTopic, Encoding.UTF8.GetBytes("1"), MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE, false);
        }

        /*
         * Button btnFecharJanela action
         */
        private void btnFecharJanela_Click(object sender, EventArgs e)
        {
            string closeWindowTopic = Properties.Settings.Default.codigoCliente + "/Casa/closeWindow";
            client.Publish(closeWindowTopic, Encoding.UTF8.GetBytes("1"), MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE, false);
        }

        /*
         * Button btnAbrirJanela action
         */
        private void btnAbrirJanela_Click(object sender, EventArgs e)
        {
            string openWindowTopic = Properties.Settings.Default.codigoCliente + "/Casa/openWindow";
            client.Publish(openWindowTopic, Encoding.UTF8.GetBytes("1"), MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE, false);
        }
    }
}
