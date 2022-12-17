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
    public partial class ÜrünEkleme2 : Form
    {
        public Form2 frm2;
        public ÜrünEkleme2()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "")
            {
                frm2.bag.Open();
                frm2.kmt.Connection = frm2.bag;
                frm2.kmt.CommandText = "UPDATE Urun SET Urun_Adi='" + textBox1.Text + "',Urun_Kodu='" + textBox2.Text + "',Firma_Adi='" + comboBox1.Text + "',Alis_Fiyati='" + textBox3.Text + "',Satis_Fiyati='" + textBox4.Text + "',Kategori='" + comboBox2.Text + "' WHERE Urun_Kodu='" + frm2.ürünEkranı.dataGridView1.CurrentRow.Cells[1].Value.ToString() + "' AND Urun_Adi='" + frm2.ürünEkranı.dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
                frm2.kmt.ExecuteNonQuery();
                frm2.kmt.Dispose();
                frm2.bag.Close();
                frm2.urunListele();
                this.Close();
            }
            else
            {
                MessageBox.Show("Lütfen Ürün Adı - Ürün Kodu alanlarını boş bırakmayınız !!!");
            }
        }
    }
}
