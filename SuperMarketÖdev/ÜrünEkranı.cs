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
    public partial class ÜrünEkranı : Form
    {
        public Form2 frm2;
        public ÜrünEkranı()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm2.ürünekleme.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adtr = new SqlDataAdapter("select Urun_Adi,Urun_Kodu,Firma_Adi,Alis_Fiyati,Satis_Fiyati,Kategori From Urun", frm2.bag);
            string alan = "";
            if (comboBox1.Text == "Ürün Adı") alan = "Urun_Adi";
            else if (comboBox1.Text == "Ürün Kodu") alan = "Urun_Kodu";
            else if (comboBox1.Text == "Firma Adı") alan = "Firma_Adi";
            else if (comboBox1.Text == "Alış Fiyatı") alan = "Alis_Fiyati";
            else if (comboBox1.Text == "Satış Fiyatı") alan = "Satis_Fiyati";
            else if (comboBox1.Text == "Kategori") alan = "Kategori";//http://www.gorselprogramlama.com

            if (comboBox1.Text == "Tümü")//eğer texbox boş ise
            {
                frm2.bag.Open();
                frm2.tabloUrun.Clear();
                frm2.kmt.Connection = frm2.bag;
                frm2.kmt.CommandText = "Select Urun_Adi,Urun_Kodu,Firma_Adi,Alis_Fiyati,Satis_Fiyati,Kategori From Urun";//tüm kayıtları seç
                adtr.SelectCommand = frm2.kmt;
                adtr.Fill(frm2.tabloUrun);
                frm2.bag.Close();
            }
            if (alan != "")
            {
                frm2.bag.Open();
                adtr.SelectCommand.CommandText = " " + " where(" + alan + " like '%" + textBox1.Text + "%' )";
                frm2.tabloUrun.Clear();
                adtr.Fill(frm2.tabloUrun);//http://www.gorselprogramlama.com
                frm2.bag.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ÜrünEkranı_Load(object sender, EventArgs e)
        {
            
                frm2.urunListele();
                try//http://www.gorselprogramlama.com
                {
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.Columns[0].HeaderText = "Ürün Adı";
                    dataGridView1.Columns[1].HeaderText = "Ürün Kodu";
                    dataGridView1.Columns[2].HeaderText = "Firma Adı";
                    dataGridView1.Columns[3].HeaderText = "Alış fiyatı";
                    dataGridView1.Columns[4].HeaderText = "Satış Fiyatı";
                    dataGridView1.Columns[5].HeaderText = "Kategori";
                }
                catch
                {
                    ;
                }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult cevap;
                cevap = MessageBox.Show("Kaydı silmek istediğinizden emin misiniz ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes && dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim() != "")
                {
                    frm2.bag.Open();
                    frm2.kmt.Connection = frm2.bag;//http://www.gorselprogramlama.com
                    frm2.kmt.CommandText = "DELETE from Urun WHERE Urun_Kodu='" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "'";
                    //şarta uyan kaydı silme sorgusu
                    frm2.kmt.ExecuteNonQuery();
                    frm2.kmt.Dispose();
                    frm2.bag.Close();
                    frm2.urunListele();
                }
            }
            catch
            {
                ;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            frm2.ürünekleme.textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            //form7 deki textbox1 in textine datagridview1 deki seçili satırın 0. hücresindeki değeri yaz.
            frm2.ürünekleme.textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            frm2.ürünekleme.comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            frm2.ürünekleme.textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();//http://www.gorselprogramlama.com
            frm2.ürünekleme.textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            frm2.ürünekleme.comboBox2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            frm2.ürünekleme.ShowDialog();
        }
    }
}
