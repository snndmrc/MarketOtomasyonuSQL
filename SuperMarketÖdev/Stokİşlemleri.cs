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
    public partial class Stokİşlemleri : Form
    {
        public Form2 frm2;
        public Stokİşlemleri()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm2.yeniStokEkleme.ShowDialog();
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
            try//http://www.gorselprogramlama.com
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
                //adet değişkenine textbox3 deki değeri ata.
                frm2.bag.Open();
                frm2.kmt.Connection = frm2.bag;

                frm2.kmt.CommandText = "UPDATE Stok SET Adet=Adet+'" + adet + "' WHERE Urun_Adi='" + textBox2.Text + "' ";
                //urunAdi textbox2 texti olan kaydın adet alan değerini adet değişkeni kadar artır.
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
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //http://www.gorselprogramlama.com
            frm2.yeniStokEkleme2.comboBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            //form15 deki combo1 in textine datagridview1 deki seçili satırın 0. hücresindeki değeri yaz.
            frm2.yeniStokEkleme2.textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            frm2.yeniStokEkleme2.textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            frm2.yeniStokEkleme2.textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            frm2.yeniStokEkleme2.ShowDialog();

        }
    }
}
