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
    public partial class Stokİşlemleri : Form
    {
        public Stokİşlemleri()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            YeniStokEkleme yeniStokEkleme = new YeniStokEkleme();
            yeniStokEkleme.ShowDialog();
        }
    }
}
