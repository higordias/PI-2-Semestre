using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PI3
{
    public partial class ScreenInicio : Form
    {
        bool estadoLampada = false; // false --> lampada apagada, true --> lampada acesa
        bool estadoJanela = false; // false --> janela manual, true --> janela automatica
        string dir_projeto = System.AppContext.BaseDirectory;

        public ScreenInicio()
        {
            InitializeComponent();
            if (!estadoLampada)
            {
                btnLigarLampada.BackgroundImage = Image.FromFile(dir_projeto + "images\\lampadaOff.png");
                btnLigarLampada.BackgroundImageLayout = ImageLayout.Center;
                estadoLampada = true;
            }
            else
            {
                btnLigarLampada.BackgroundImage = Image.FromFile(dir_projeto + "images\\lampadaOn.png");
                btnLigarLampada.BackgroundImageLayout = ImageLayout.Center;
                estadoLampada = false;
            }

            if (!estadoJanela)
            {
                btnAutoManual.BackgroundImage = Image.FromFile(dir_projeto + "images\\Manual.png");
                btnAutoManual.BackgroundImageLayout = ImageLayout.Center;
                estadoJanela = true;
            }
            else
            {
                btnAutoManual.BackgroundImage = Image.FromFile(dir_projeto + "images\\Automatico.png");
                btnAutoManual.BackgroundImageLayout = ImageLayout.Center;
                estadoJanela = false;
            }
        }

        private void BtnLigarLampada_Click(object sender, EventArgs e)
        {
            if (!estadoLampada)
            {
                btnLigarLampada.BackgroundImage = Image.FromFile(dir_projeto + "images\\lampadaOff.png");
                btnLigarLampada.BackgroundImageLayout = ImageLayout.Center;
                estadoLampada = true;
            }
            else
            {
                btnLigarLampada.BackgroundImage = Image.FromFile(dir_projeto + "images\\lampadaOn.png");
                btnLigarLampada.BackgroundImageLayout = ImageLayout.Center;
                estadoLampada = false;
            }
        }

        private void btnAutoManual_Click(object sender, EventArgs e)
        {
            if (!estadoJanela)
            {
                btnAutoManual.BackgroundImage = Image.FromFile(dir_projeto + "images\\Manual.png");
                btnAutoManual.BackgroundImageLayout = ImageLayout.Center;
                btnFecharJanela.Enabled = true;
                btnAbrirJanela.Enabled = true;
                estadoJanela = true;
            }
            else
            {
                btnAutoManual.BackgroundImage = Image.FromFile(dir_projeto + "images\\Automatico.png");
                btnAutoManual.BackgroundImageLayout = ImageLayout.Center;
                btnFecharJanela.Enabled = false;
                btnAbrirJanela.Enabled = false;
                estadoJanela = false;
            }
        }
    }
}
