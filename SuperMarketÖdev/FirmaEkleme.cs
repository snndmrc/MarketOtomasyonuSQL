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
    public partial class FirmaEkleme : Form
    {
        public Form2 frm2;
        public FirmaEkleme()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FirmaEkleme_Load(object sender, EventArgs e)
        {
            frm2.firmaListele();
            try
            {
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.Columns[0].HeaderText = "Firma Adı";
                dataGridView1.Columns[1].HeaderText = "Firma Adresi";
            }
            catch
            {//http://www.gorselprogramlama.com
                ;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "")
            {
                frm2.bag.Open();
                frm2.kmt.Connection = frm2.bag;
                frm2.kmt.CommandText = "INSERT INTO Firma(FirmaAdi,FirmaAdresi) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "') ";
                //kayıt ekleme sorgu metni
                frm2.kmt.ExecuteNonQuery();//sorguyu çalıştır                                                      
                frm2.kmt.Dispose();//Komut kullanımını kapatıyoruz
                frm2.bag.Close(); //veritabanımızı kapatıyoruz
                frm2.firmaListele();
                frm2.firmaComboEkle();
                MessageBox.Show("Kayıt işlemi tamamlandı ! ");
                textBox1.Text = "";//http://www.gorselprogramlama.com
                textBox2.Text = "";
            }
            else
            {
                MessageBox.Show("Lütfen Firma Adı alanını boş bırakmayınız !!!");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
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
                    frm2.kmt.Connection = frm2.bag;//http://www.gorselprogramlama.com
                    frm2.kmt.CommandText = "DELETE from Firma WHERE FirmaAdi='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "' ";
                    frm2.kmt.ExecuteNonQuery();
                    frm2.kmt.Dispose();
                    frm2.bag.Close();
                    frm2.firmaListele();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }//http://www.gorselprogramlama.com
    }
    
}
