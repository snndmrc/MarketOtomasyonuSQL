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
    public partial class ÜrünEkranı : Form
    {
        public ÜrünEkranı()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ÜrünEkleme frm4 = new ÜrünEkleme();
            frm4.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
    }
}
