using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using SuperMarketÖdev.Market_OtomasyonuDataSetTableAdapters;

namespace SuperMarketÖdev
{
    public partial class Form1 : Form
    {
        
       
        SqlConnection con;
        SqlDataReader dr;
        SqlCommand com;



        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string password = textBox2.Text;
            con = new SqlConnection("Data Source=MSIBRAVO\\SQLEXPRESS01;Initial Catalog=Tablo;Integrated Security=True");
            com = new SqlCommand();
            con.Open();
            com.Connection= con;
            com.CommandText = "Select *From giris where Kullanici_Adi='" + textBox1.Text 
                + "'And Sifre ='" + textBox2.Text + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
             
                Form2 frm2 = new Form2();
                this.Hide();
                frm2.ShowDialog();
               
                
               
            }
            
            else
            {
                MessageBox.Show("Hatalı kullanıcı veya şifre");
                
            }
            
            
            con.Close();
          
            
        }
        
       
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
         this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.CheckState == CheckState.Checked) 
            {
                textBox2.UseSystemPasswordChar= true;
                checkBox1.Text = "Gizle";
            }
            else if(checkBox1.CheckState == CheckState.Unchecked)
            {
                textBox2.UseSystemPasswordChar= false;
                checkBox1.Text = "Göster";
            }
           
        }
    }
}
