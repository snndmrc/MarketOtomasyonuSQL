using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SuperMarketÖdev
{
    public partial class KasiyerEkleme2 : Form
    {
        public Form2 frm2;
        public KasiyerEkleme2()
        {
            InitializeComponent();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "" && textBox3.Text.Trim() != "")
            {
                frm2.bag.Open();
                frm2.kmt.Connection = frm2.bag;
                frm2.kmt.CommandText = "UPDATE Kasiyer SET Kasiyer_Adi='" + textBox1.Text + "',Kasiyer_Soyadi='" + textBox2.Text + "',Kasiyer_TC='" + textBox3.Text + "',Kasiyer_Tel='" + textBox4.Text + "',Kasiyer_evTel='" + textBox5.Text + "',Kasiyer_Adress='" + textBox6.Text + "',Kasiyer_Maas='" + textBox7.Text + "',Kasiyer_KasaNo='" + textBox8.Text + "',Kasiyer_GorevBaslangici='" + dateTimePicker1.Text + "',Kasiyer_GorevBitimi='" + dateTimePicker2.Text + "' WHERE Kasiyer_TC='" + frm2.kasiyerİşlemleri.dataGridView1.CurrentRow.Cells[2].Value.ToString() + "' AND Kasiyer_Adi='" + frm2.kasiyerİşlemleri.dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
                //güncelleme sorgusu
                frm2.kmt.ExecuteNonQuery();
                frm2.kmt.Dispose();
                frm2.bag.Close();
                frm2.kasiyerListele();
                this.Close();
            }
            else//http://www.gorselprogramlama.com
            {
                MessageBox.Show("Lütfen Ad-Soyad-Tckimlik alanlarını boş bırakmayınız !!!");
            }

        }
    }
}
