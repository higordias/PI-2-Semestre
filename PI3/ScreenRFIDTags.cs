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
    public partial class ScreenRFIDTags : Form
    {

        public ScreenRFIDTags()
        {
            InitializeComponent();
        }

        private void ScreenRFIDTags_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.cartao1 == "") { lblCartao1.Text = "-----"; }
            else { lblCartao1.Text = Properties.Settings.Default.cartao1; }

            if (Properties.Settings.Default.cartao2 == "") { lblCartao2.Text = "-----"; }
            else { lblCartao2.Text = Properties.Settings.Default.cartao2; }

            if (Properties.Settings.Default.cartao3 == "") { lblCartao3.Text = "-----"; }
            else { lblCartao3.Text = Properties.Settings.Default.cartao3; }

            if (Properties.Settings.Default.cartao4 == "") { lblCartao4.Text = "-----"; }
            else { lblCartao4.Text = Properties.Settings.Default.cartao4; }

            if (Properties.Settings.Default.cartao5 == "") { lblCartao5.Text = "-----"; }
            else { lblCartao5.Text = Properties.Settings.Default.cartao5; }

            if (Properties.Settings.Default.cartao6 == "") { lblCartao6.Text = "-----"; }
            else { lblCartao6.Text = Properties.Settings.Default.cartao6; }

            if (Properties.Settings.Default.cartao7 == "") { lblCartao7.Text = "-----"; }
            else { lblCartao7.Text = Properties.Settings.Default.cartao7; }

            if (Properties.Settings.Default.cartao8 == "") { lblCartao8.Text = "-----"; }
            else { lblCartao8.Text = Properties.Settings.Default.cartao8; }

            if (Properties.Settings.Default.cartao9 == "") { lblCartao9.Text = "-----"; }
            else { lblCartao9.Text = Properties.Settings.Default.cartao9; }

            if (Properties.Settings.Default.cartao10 == "") { lblCartao10.Text = "-----"; }
            else { lblCartao10.Text = Properties.Settings.Default.cartao10; }
        }
    }
}
