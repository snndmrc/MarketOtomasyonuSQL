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
    public partial class YeniStokEkleme : Form
    {
        public Form2 frm2;
        public YeniStokEkleme()
        {
            InitializeComponent();
        }

        private void YeniStokEkleme_Load(object sender, EventArgs e)
        {
            frm2.urunComboEkle();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm2.urunKontrol();//form1 deki urunKontrol prosedürünü git ve çalıştır.
            if (frm2.durum == false) //form1 deki durum değişkeni false ise 
            {
                double sfiyat;
                sfiyat = double.Parse(textBox2.Text) + double.Parse(textBox2.Text) * (double.Parse(textBox3.Text) / 100);
                if (comboBox1.Text.Trim() != "")
                {
                    frm2.bag.Open();
                    frm2.kmt.Connection = frm2.bag;
                    frm2.kmt.CommandText = "INSERT INTO Stok(UrunAdi,Adet,Birim_Fiyat,KDV,Satis_Fiyat VALUES ('" + comboBox1.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + sfiyat.ToString() + "') ";
                    //kayıt ekleme sorgu metni
                    frm2.kmt.ExecuteNonQuery();//sorguyu çalıştır                                                      
                    frm2.kmt.Dispose();//Komut kullanımını kapatıyoruz
                    frm2.bag.Close(); //veritabanımızı kapatıyoruz
                    frm2.stokListele();
                    MessageBox.Show("Kayıt işlemi tamamlandı ! ");
                    for (int i = 0; i < this.Controls.Count; i++)
                    {//http://www.gorselprogramlama.com
                        if (this.Controls[i] is TextBox) this.Controls[i].Text = "";
                        if (this.Controls[i] is CheckBox) this.Controls[i].Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Ürün Adı alanını boş bırakmayınız !!!");
                }
            }
            else MessageBox.Show("Girmiş olduğunuz Ürün mevcut !");
        }
    }
}
