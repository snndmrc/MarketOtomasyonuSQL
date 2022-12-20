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
    public partial class Kasiyerİşlemleri : Form
    {
        public Form2 frm2;
        Form1 frm1 = (Form1)Application.OpenForms["Form1"];
        public Kasiyerİşlemleri()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm2.kasiyerEkleme.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adtr = new SqlDataAdapter("select Kasiyer_Adi,Kasiyer_Soyadi,Kasiyer_TC,Kasiyer_Tel,Kasiyer_EvTel,Kasiyer_Adres,Kasiyer_Maas,Kasiyer_KasaNo,Kasiyer_GorevBaslangici,Kasiyer_GorevBitimi From Kasiyer", frm2.bag);
            string alan = "";
            if (comboBox1.Text == "Adı") alan = "Kasiyer_Adi";           
            else if (comboBox1.Text == "Soyadı") alan = "Kasiyer_Soyadi";
            else if (comboBox1.Text == "Tc Kimlik") alan = "Kasiyer_TC";
            else if (comboBox1.Text == "Cep Tel") alan = "Kasiyer_Tel";
            else if (comboBox1.Text == "Ev Tel") alan = "Kasiyer_EvTel";
            else if (comboBox1.Text == "Adres") alan = "Kasiyer_Adres";
            else if (comboBox1.Text == "Maaş") alan = "Kasiyer_Maas";
            else if (comboBox1.Text == "Görevli old. Kasa") alan = "Kasiyer_KasaNo";
            else if (comboBox1.Text == "Görev Başlangıcı") alan = "Kasiyer_GorevBaslangici";
            else if (comboBox1.Text == "Görev Bitimi") alan = "Kasiyer_GorevBitimi";

            if (comboBox1.Text == "Tümü")
            {
                frm2.bag.Open();
                frm2.tabloKasiyer.Clear();
                frm2.kmt.Connection = frm2.bag;
                frm2.kmt.CommandText = "Select  Kasiyer_Adi,Kasiyer_Soyadi,Kasiyer_TC,Kasiyer_Tel,Kasiyer_EvTel,Kasiyer_Adres,Kasiyer_Maas,Kasiyer_KasaNo,Kasiyer_GorevBaslangici,Kasiyer_GorevBitimi from Kasiyer";
                adtr.SelectCommand = frm2.kmt;
                adtr.Fill(frm2.tabloKasiyer);
                frm2.bag.Close();
            }
            if (alan != "")
            {
                frm2.bag.Open();
                adtr.SelectCommand.CommandText = " Select  Kasiyer_Adi,Kasiyer_Soyadi,Kasiyer_TC,Kasiyer_Tel,Kasiyer_EvTel,Kasiyer_Adres,Kasiyer_Maas,Kasiyer_KasaNo,Kasiyer_GorevBaslangici,Kasiyer_GorevBitimi from Kasiyer" + " where(" + alan + " like '%" + textBox1.Text + "%' )";
               
                frm2.tabloKasiyer.Clear();
                adtr.Fill(frm2.tabloKasiyer);
                frm2.bag.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void Kasiyerİşlemleri_Load(object sender, EventArgs e)
        {
            

            
            frm2.kasiyerListele();
            try
            {
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.Columns[0].HeaderText = "Adı";
                dataGridView1.Columns[1].HeaderText = "Soyadı";
                dataGridView1.Columns[2].HeaderText = "Tc Kimlik";
                dataGridView1.Columns[3].HeaderText = "Cep Tel";
                dataGridView1.Columns[4].HeaderText = "Ev Tel";
                dataGridView1.Columns[5].HeaderText = "Adres";
                dataGridView1.Columns[6].HeaderText = "Maaş";
                dataGridView1.Columns[7].HeaderText = "Görevli Old. Kasa";
                dataGridView1.Columns[8].HeaderText = "Görev Başlangıcı";
                dataGridView1.Columns[9].HeaderText = "Görev Bitimi";
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
                cevap = MessageBox.Show("Kaydı silmek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes && dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim() != "")
                {
                    frm2.bag.Open();
                    frm2.kmt.Connection = frm2.bag;
                    frm2.kmt.CommandText = "DELETE from Kasiyer WHERE Kasiyer_TC='" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "'";
                    frm2.kmt.ExecuteNonQuery();
                    frm2.kmt.Dispose();
                    frm2.bag.Close();
                    frm2.kasiyerListele();
                }
            }
            catch
            {
                ;
            }
        }
        

        private void dataGridView1_CellMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            frm2.kasiyerEkleme2.textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            frm2.kasiyerEkleme2.textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            frm2.kasiyerEkleme2.textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            frm2.kasiyerEkleme2.textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            frm2.kasiyerEkleme2.textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            frm2.kasiyerEkleme2.textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            frm2.kasiyerEkleme2.textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            frm2.kasiyerEkleme2.textBox8.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            frm2.kasiyerEkleme2.dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            frm2.kasiyerEkleme2.dateTimePicker2.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            frm2.kasiyerEkleme2.ShowDialog();
        }
    }
}
