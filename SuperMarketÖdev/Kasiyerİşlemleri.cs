using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMarketÖdev
{
    public partial class Kasiyerİşlemleri : Form
    {
        public Kasiyerİşlemleri()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KasiyerEkleme kasiyerEkleme = new KasiyerEkleme();
            kasiyerEkleme.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
