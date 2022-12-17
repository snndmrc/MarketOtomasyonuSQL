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
    public partial class KategoriEkleme : Form
    {
        public Form2 frm2;
        public KategoriEkleme()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
           
        }

        private void KategoriEkleme_Load(object sender, EventArgs e)
        {
            frm2.kategoriListele();
            try
            {
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.Columns[0].HeaderText = "Kategori Adı";
            }
            catch
            {
                ;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "")
            {
                frm2.bag.Open();
                frm2.kmt.Connection = frm2.bag;
                frm2.kmt.CommandText = "INSERT INTO Kategori(Kategori_Adi) VALUES ('" + textBox1.Text + "') ";
                
                frm2.kmt.ExecuteNonQuery();                                                  
                frm2.kmt.Dispose();
                frm2.bag.Close(); 
                frm2.kategoriListele();
                frm2.kategoriComboEkle();
                MessageBox.Show("Kayıt işlemi tamamlandı ! ");
                textBox1.Text = "";
            }
            else
            {
                MessageBox.Show("Lütfen Kategori Adı alanını boş bırakmayınız !!!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult cevap;

                cevap = MessageBox.Show("Kaydı silmek istediğinizden eminmisiniz", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes && dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim() != "")
                {
                    frm2.bag.Open();
                    frm2.kmt.Connection = frm2.bag;
                    frm2.kmt.CommandText = "DELETE from Kategori WHERE Kategori_Adi='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "' ";
                    frm2.kmt.ExecuteNonQuery();
                    frm2.kmt.Dispose();
                    frm2.bag.Close();
                    frm2.kategoriListele();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }
    }
}
