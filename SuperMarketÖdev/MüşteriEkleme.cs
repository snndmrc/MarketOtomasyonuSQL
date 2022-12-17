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
    public partial class MüşteriEkleme : Form
    {
        public Form2 frm2;
        public MüşteriEkleme()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm2.tcKimlikKontrol();
            if (frm2.durum == false)
            {
                if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "" && textBox3.Text.Trim() != "")
                
                {
                    frm2.bag.Open();
                    frm2.kmt.Connection = frm2.bag;
                    frm2.kmt.CommandText = "INSERT INTO Musteri(Musteri_Adi,Musteri_Soyadi,Musteri_TC,Musteri_CepTel,Musteri_EvTel,Musteri_Adres) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox6.Text + "','" + textBox5.Text + "','" + textBox4.Text + "') ";
                    
                    frm2.kmt.ExecuteNonQuery();                                                   
                    frm2.kmt.Dispose();
                    frm2.bag.Close(); 
                    frm2.musteriListele();
                    MessageBox.Show("Kayıt işlemi tamamlandı ! ");
                    for (int i = 0; i < this.Controls.Count; i++)
                    {
                        if (this.Controls[i] is TextBox) this.Controls[i].Text = "";
                    }
                }
                else 
                {
                    MessageBox.Show("Lütfen Ad-Soyad-Tckimlik alanlarını boş bırakmayınız !!!");
                }
            }
            else MessageBox.Show("Girmiş olduğunuz Tc Kimlik mevcut !");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void MüşteriEkleme_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
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
