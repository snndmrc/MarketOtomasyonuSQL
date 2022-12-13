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
    public partial class MüşteriBilgileri : Form
    {
        public MüşteriBilgileri()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MüşteriEkleme müşteriekleme = new MüşteriEkleme();
            müşteriekleme.ShowDialog();
        }
    }
}
