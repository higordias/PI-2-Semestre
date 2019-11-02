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
        int estado = 0; // 0 --> lampada apagada, 1 --> lampada acesa
        string dir_projeto = System.AppContext.BaseDirectory;

        public ScreenInicio()
        {
            InitializeComponent();
            if (estado == 0)
            {
                btnLigarLampada.BackgroundImage = Image.FromFile(dir_projeto + "images\\lampadaOff.png");
                btnLigarLampada.BackgroundImageLayout = ImageLayout.Center;
                estado = 1;
            }
            else
            {
                btnLigarLampada.BackgroundImage = Image.FromFile(dir_projeto + "images\\lampadaOn.png");
                btnLigarLampada.BackgroundImageLayout = ImageLayout.Center;
                estado = 0;
            }
        }

        private void BtnLigarLampada_Click(object sender, EventArgs e)
        {
            if (estado == 0)
            {
                btnLigarLampada.BackgroundImage = Image.FromFile(dir_projeto + "images\\lampadaOff.png");
                btnLigarLampada.BackgroundImageLayout = ImageLayout.Center;
                estado = 1;
            }
            else
            {
                btnLigarLampada.BackgroundImage = Image.FromFile(dir_projeto + "images\\lampadaOn.png");
                btnLigarLampada.BackgroundImageLayout = ImageLayout.Center;
                estado = 0;
            }
        }
    }
}
