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
    public partial class MüşteriBilgileri : Form
    {
        public Form2 frm2;
        public MüşteriBilgileri()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm2.müşteriEkleme.ShowDialog();
        }

        private void MüşteriBilgileri_Load(object sender, EventArgs e)
        {

            frm2.musteriListele();
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

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
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
                    frm2.kmt.CommandText = "DELETE from Musteri WHERE Musteri_TC='" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "'";
                    frm2.kmt.ExecuteNonQuery();
                    frm2.kmt.Dispose();
                    frm2.bag.Close();
                    frm2.musteriListele();
                }
            }
            catch
            {
                ;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adtr = new SqlDataAdapter("select Musteri_Adi,Musteri_Soyadi,Musteri_TC,Musteri_CepTel,Musteri_EvTel,Musteri_Adres From Musteri", frm2.bag);
            string alan = "";
            if (comboBox1.Text == "Müşteri Adı") alan = "Musteri_Adi";           
            else if (comboBox1.Text == "Müşteri Soyadı") alan = "Musteri_Soyadi";
            else if (comboBox1.Text == "Tc Kimlik") alan = "Musteri_TC";
            else if (comboBox1.Text == "Cep Tel") alan = "Musteri_CepTe";
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
        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MüşteriBilgileri_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            frm2.müşteriEkleme2.textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            frm2.müşteriEkleme2.textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            frm2.müşteriEkleme2.textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            frm2.müşteriEkleme2.textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            frm2.müşteriEkleme2.textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            frm2.müşteriEkleme2.textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            frm2.müşteriEkleme2.ShowDialog();
            
        }
    }
}
