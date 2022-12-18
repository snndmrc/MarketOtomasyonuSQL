using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMarketÖdev
{
    public partial class SatisIslemleri : Form
    {
        public Form2 frm2;
        public SatisIslemleri()
        {
            InitializeComponent();
        }

        bool durum = false;

        void stokUrunAdetKontrol()
        {

            frm2.bag.Open();
            frm2.kmt.Connection = frm2.bag;
            frm2.kmt.CommandText = "Select Adet from Stok Where Urun_Adi='" + comboBox2.Text + "'";
            SqlDataReader oku;
            oku = frm2.kmt.ExecuteReader();
            while (oku.Read())
            {
                if (int.Parse(textBox7.Text) <= int.Parse(oku[0].ToString())) durum = true;
            }
            frm2.kmt.Dispose();
            frm2.bag.Close();
        }
        private void SatisIslemleri_Load(object sender, EventArgs e)
        {
            frm2.musteriListele();
            frm2.urunSatisComboEkle();
            try
            {
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.Columns[0].HeaderText = "Müşteri Adı";
                dataGridView1.Columns[1].HeaderText = "Müşteri Soyadı";
                dataGridView1.Columns[2].HeaderText = "Tc Kimlik";
                dataGridView1.Columns[3].HeaderText = "Cep Tel";
                dataGridView1.Columns[4].HeaderText = "Ev Tel";
                dataGridView1.Columns[5].HeaderText = "Adres";
            }
            catch
            {
                ;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            { 
                SqlDataAdapter adtr = new SqlDataAdapter("select Musteri_Adi,Musteri_Soyadi,Musteri_TC,Musteri_CepTel,Musteri_EvTel,Musteri_Adres From Musteri", frm2.bag);
                string alan = "";
                if (comboBox1.Text == "Müşteri Adı") alan = "Musteri_Adi";
                else if (comboBox1.Text == "Müşteri Soyadı") alan = "Musteri_Soyadi";
                else if (comboBox1.Text == "Tc Kimlik") alan = "Musteri_TC";
                else if (comboBox1.Text == "Cep Tel") alan = "Musteri_CepTel";
                else if (comboBox1.Text == "Ev Tel") alan = "Musteri_EvTel";
                else if (comboBox1.Text == "Adres") alan = "Musteri_Adres";

                if (comboBox1.Text == "Tümü")
                {
                    frm2.bag.Open();
                    frm2.tabloMusteri.Clear();
                    frm2.kmt.Connection = frm2.bag;
                    frm2.kmt.CommandText = "Select Musteri_Adi,Musteri_Soyadi,Musteri_TC,Musteri_CepTel,Musteri_EvTel,Musteri_Adres from Musteri";
                    adtr.SelectCommand = frm2.kmt;
                    adtr.Fill(frm2.tabloMusteri);
                    frm2.bag.Close();
                }
                if (alan != "")
                {
                    frm2.bag.Open();
                    adtr.SelectCommand.CommandText = " Select Musteri_Adi,Musteri_Soyadi,Musteri_TC,Musteri_CepTel,Musteri_EvTel,Musteri_Adres From Musteri" + " where(" + alan + " like '%" + textBox1.Text + "%' )";
                    frm2.tabloMusteri.Clear();
                    adtr.Fill(frm2.tabloMusteri);
                    frm2.bag.Close();
                }
            }
        }
      
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() != "" && textBox3.Text.Trim() != "" && textBox4.Text.Trim() != "" && textBox7.Text.Trim() != "" && textBox6.Text.Trim() != "")
            {
                stokUrunAdetKontrol();
                if (durum == true)
                {
                    int adet;
                    adet = int.Parse(textBox7.Text);
                    frm2.bag.Open();
                    frm2.kmt.Connection = frm2.bag;
                    frm2.kmt.CommandText = "INSERT INTO Satis(Fatura_No,Musteri_Adi,Musteri_Soyadi,TC_Kimlik,Urun_Adi,Satis_Fiyat,Adet,Toplam_Tutar,Kasa_No,Tarih) VALUES ('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + comboBox2.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + dateTimePicker1.Text + "') ";         
                    frm2.kmt.ExecuteNonQuery();                  
                    frm2.kmt.CommandText = "UPDATE Stok SET Adet=Adet-'" + adet + "' WHERE Urun_Adi='" + comboBox2.Text + "' ";
                    frm2.kmt.ExecuteNonQuery();
                    frm2.kmt.Dispose();
                    frm2.bag.Close();  
                    frm2.gununSatisListele();
                    frm2.urunSatisComboEkle();
                    MessageBox.Show("Kayıt işlemi tamamlandı ! ");
                    for (int i = 0; i < this.Controls.Count; i++)
                    {
                        if (this.Controls[i] is TextBox) this.Controls[i].Text = "";
                    }
                    comboBox2.Text = "";
                }
                else MessageBox.Show("Stokta yeterli sayıda ürün yok !!!");
            }
            else
            {
                MessageBox.Show("Lütfen gerekli alanları doldurunuz !!!");
            }
        }
       

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBox8.Text = (double.Parse(textBox6.Text) * double.Parse(textBox7.Text)).ToString();
            }
            catch
            {
                ;   
            }
        }
        
        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            frm2.urunSatisFiyatTextEkle();
        }
       
            private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
