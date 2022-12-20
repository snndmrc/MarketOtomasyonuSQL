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
    public partial class Stokİşlemleri : Form
    {
        Form1 frm1 = (Form1)Application.OpenForms["Form1"];
        public Form2 frm2;
        public Stokİşlemleri()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(frm1.yetki.ToString() == "1")
            {
                frm2.yeniStokEkleme.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bu alana giriş için yetkiniz yoktur.");
            }
        }

        private void Stokİşlemleri_Load(object sender, EventArgs e)
        {
            frm2.stokListele();
            try
            {
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.Columns[0].HeaderText = "Ürün Adı";
                dataGridView1.Columns[1].HeaderText = "Adet";
                dataGridView1.Columns[2].HeaderText = "Birim Fiyat";
                dataGridView1.Columns[3].HeaderText = "Kdv";
                dataGridView1.Columns[4].HeaderText = "Satış Fiyatı";
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
                cevap = MessageBox.Show("Kaydı silmek istediğinizden eminmisiniz", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes && dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim() != "")
                {
                    frm2.bag.Open();
                    frm2.kmt.Connection = frm2.bag;
                    frm2.kmt.CommandText = "DELETE from Stok WHERE Urun_Adi='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
                    frm2.kmt.ExecuteNonQuery();
                    frm2.kmt.Dispose();
                    frm2.bag.Close();
                    frm2.stokListele();
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

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() != "" && textBox3.Text.Trim() != "")
            {
                int adet;

                adet = int.Parse(textBox3.Text);              
                frm2.bag.Open();
                frm2.kmt.Connection = frm2.bag;

                frm2.kmt.CommandText = "UPDATE Stok SET Adet=Adet+'" + adet + "' WHERE Urun_Adi='" + textBox2.Text + "' ";             
                frm2.kmt.ExecuteNonQuery();
                frm2.kmt.Dispose();
                frm2.bag.Close();
                frm2.stokListele();

            }
            else
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız !!!");
            }
        }
       

        private void dataGridView1_CellMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            frm2.yeniStokEkleme2.comboBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();        
            frm2.yeniStokEkleme2.textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            frm2.yeniStokEkleme2.textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            frm2.yeniStokEkleme2.textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            frm2.yeniStokEkleme2.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adtr = new SqlDataAdapter("select Urun_Adi,Adet,Birim_Fiyat,KDV,Satis_Fiyat From Stok", frm2.bag);
            string alan = "";
            if (comboBox1.Text == "Ürün Adı") alan = "Urun_Adi";
            else if (comboBox1.Text == "Adet") alan = "Adet";
            else if (comboBox1.Text == "Birim Fiyat") alan = "Birim_Fiyat";
            else if (comboBox1.Text == "Kdv") alan = "KDV";
            else if (comboBox1.Text == "Satış Fiyatı") alan = "Satis_Fiyat";

            if (comboBox1.Text == "Tümü")
            {
                frm2.bag.Open();
                frm2.tabloStok.Clear();
                frm2.kmt.Connection = frm2.bag;
                frm2.kmt.CommandText = "Select Urun_Adi,Adet,Birim_Fiyat,KDV,Satis_Fiyat from Stok";
                adtr.SelectCommand = frm2.kmt;
                adtr.Fill(frm2.tabloStok);
                frm2.bag.Close();
            }
            if (alan != "")
            {
                frm2.bag.Open();
                adtr.SelectCommand.CommandText = " Select Urun_Adi,Adet,Birim_Fiyat,KDV,Satis_Fiyat From Stok" + " where(" + alan + " like '%" + textBox1.Text + "%' )";
                frm2.tabloStok.Clear();
                adtr.Fill(frm2.tabloStok);
                frm2.bag.Close();
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }
    }
}
