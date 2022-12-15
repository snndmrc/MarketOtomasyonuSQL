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
    public partial class KasiyerEkleme : Form

    {
        public Form2 frm2;
        
        public KasiyerEkleme()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm2.tcKimlikKasiyerKontrol();
            if (frm2.durum == false)
            {
                if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "" && textBox3.Text.Trim() != "")
                //eğer textbox1,textbox2,textbox3 boş değilse
                {
                    frm2.bag.Open();//form1deki bag isimli bağlantıyı aç
                    frm2.kmt.Connection = frm2.bag;//form1deki kmt nin bağlantısı form1 deki bag dır.
                    frm2.kmt.CommandText = "INSERT INTO Kasiyer(Kasiyer_Adi,Kasiyer_Soyadi,Kasiyer_TC,Kasiyer_Tel,Kasiyer_evTel,Kasiyer_Adres,Kasiyer_Maas,Kasiyer_KasaNo,Kasiyer_GorevBaslangici,Kasiyer_GorevBitimi) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "') ";
                    //kayıt ekleme sorgusu
                    frm2.kmt.ExecuteNonQuery();//sorguyu çalıştır                                                      
                    frm2.kmt.Dispose();//Komut kullanımını kapatıyoruz
                    frm2.bag.Close(); //veritabanımızı kapatıyoruz
                    frm2.kasiyerListele();//http://www.gorselprogramlama.com
                    MessageBox.Show("Kayıt işlemi tamamlandı ! ");
                    for (int i = 0; i < this.Controls.Count; i++)
                    {
                        if (this.Controls[i] is TextBox) this.Controls[i].Text = "";// formdaki tüm textboxların içini boşalt.
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Ad-Soyad-Tckimlik alanlarını boş bırakmayınız !!!");
                }
            }
            else MessageBox.Show("Girmiş olduğunuz Tc Kimlik mevcut !");
        }
    }
}
