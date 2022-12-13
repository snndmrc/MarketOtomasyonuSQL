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
    public partial class KategoriEkleme : Form
    {
        public KategoriEkleme()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            KategoriEkleme geri = new KategoriEkleme();
            this.Close();
           
        }
    }
}
