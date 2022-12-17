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
    public partial class ÜrünEkleme : Form
    {
        public Form2 frm2;
        public ÜrünEkleme()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm2.kategoriEkleme.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm2.firmaEkleme.ShowDialog();
        }

        private void ÜrünEkleme_Load(object sender, EventArgs e)
        {
            frm2.firmaComboEkle();
            frm2.kategoriComboEkle();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm2.urunKoduKontrol();
            if (frm2.durum == false)
            {
                if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "")
                {
                    frm2.bag.Open();
                    frm2.kmt.Connection = frm2.bag;
                    frm2.kmt.CommandText = "INSERT INTO Urun(Urun_Adi,Urun_Kodu,Firma_Adi,Alis_Fiyati,Satis_Fiyati,Kategori) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox2.Text + "') ";
                    
                    frm2.kmt.ExecuteNonQuery();                                                    
                    frm2.kmt.Dispose();
                    frm2.bag.Close(); 
                    frm2.urunListele();
                    MessageBox.Show("Kayıt işlemi tamamlandı ! ");
                    for (int i = 0; i < this.Controls.Count; i++)
                    {
                        if (this.Controls[i] is TextBox) this.Controls[i].Text = "";
                        if (this.Controls[i] is ComboBox) this.Controls[i].Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Ürün Adı - Ürün Kodu alanlarını boş bırakmayınız !!!");
                }
            }
            else MessageBox.Show("Girmiş olduğunuz Ürün Kodu mevcut !");
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
