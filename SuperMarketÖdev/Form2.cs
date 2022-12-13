using SuperMarketÖdev.Market_OtomasyonuDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMarketÖdev
{
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ÜrünEkranı ürünEkranı = new ÜrünEkranı();
            ürünEkranı.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MüşteriBilgileri müşteriBilgileri = new MüşteriBilgileri();
            müşteriBilgileri.ShowDialog();
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Kasiyerİşlemleri kasiyerİşlemleri = new Kasiyerİşlemleri();
            kasiyerİşlemleri.ShowDialog();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SatisIslemleri satisIslemleri = new SatisIslemleri();
            satisIslemleri.ShowDialog(); 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Stokİşlemleri stokİşlemleri = new Stokİşlemleri();
            stokİşlemleri.ShowDialog();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            

        }
    }
    
}
