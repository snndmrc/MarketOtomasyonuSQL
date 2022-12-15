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
    public partial class YeniStokEkleme2 : Form
    {
        public Form2 frm2;
        public YeniStokEkleme2()
        {
            InitializeComponent();
        }

        private void YeniStokEkleme2_Load(object sender, EventArgs e)
        {
            frm2.urunComboEkle();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm2.urunKontrol();
            if (textBox1.Text.Trim() != "")
            {
                double sfiyat;//http://www.gorselprogramlama.com
                sfiyat = double.Parse(textBox2.Text) + double.Parse(textBox2.Text) * (double.Parse(textBox3.Text) / 100);
                frm2.bag.Open();
                frm2.kmt.Connection = frm2.bag;
                frm2.kmt.CommandText = "UPDATE Stok SET Urun_Adi='" + comboBox1.Text + "',Adet='" + textBox1.Text + "',Birim_Fiyat='" + textBox2.Text + "',KDV='" + textBox3.Text + "',Satis_Fiyat='" + sfiyat + "' WHERE urunAdi='" + frm2.stokİşlemleri.dataGridView1.CurrentRow.Cells[0].Value.ToString() + "' ";
                frm2.kmt.ExecuteNonQuery();
                frm2.kmt.Dispose();
                frm2.bag.Close();
                frm2.stokListele();
                this.Close();//http://www.gorselprogramlama.com
            }
            else
            {
                MessageBox.Show("Lütfen Ürün Adı alanını boş bırakmayınız !!!");
            }
        }
        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true; //combo1 de klavye tuşlarını kilitle.
        }
    }
}
