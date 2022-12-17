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
    public partial class MüşteriEkleme2 : Form
    {
        public Form2 frm2;
        public MüşteriEkleme2()
        {
            InitializeComponent();
        }

        private void MüşteriEkleme2_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "" && textBox3.Text.Trim() != "")
            {
                frm2.bag.Open();
                frm2.kmt.Connection = frm2.bag;
                frm2.kmt.CommandText = "UPDATE Musteri SET Musteri_Adi='" + textBox1.Text + "',Musteri_Soyadi='" + textBox2.Text + "',Musteri_TC='" + textBox3.Text + "',Musteri_CepTel='" + textBox6.Text + "',Musteri_EvTel='" + textBox5.Text + "',Musteri_Adres='" + textBox4.Text + "' WHERE Musteri_TC='" + frm2.müşteriBilgileri.dataGridView1.CurrentRow.Cells[2].Value.ToString() + "' AND Musteri_Adi='" + frm2.müşteriBilgileri.dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";               
                frm2.kmt.ExecuteNonQuery();
                frm2.kmt.Dispose();
                frm2.musteriListele();
                this.Close();
            }
            else
            {
                MessageBox.Show("Lütfen Ad-Soyad-Tckimlik alanlarını boş bırakmayınız !!!");
            }
        }
    }
}
