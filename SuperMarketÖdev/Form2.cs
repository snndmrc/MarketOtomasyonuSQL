using SuperMarketÖdev.Market_OtomasyonuDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SuperMarketÖdev
{
    public partial class Form2 : Form
    {
        public Form1 form1;
        public ÜrünEkleme2 ÜrünEkleme2;
         public KasiyerEkleme2 kasiyerEkleme2;
         public MüşteriEkleme2 müşteriEkleme2;
         public ÜrünEkranı ürünEkranı;
         public ÜrünEkleme ürünekleme;
         public MüşteriBilgileri müşteriBilgileri;
         public MüşteriEkleme müşteriEkleme;
         public KasiyerEkleme kasiyerEkleme;
         public Kasiyerİşlemleri kasiyerİşlemleri;
         public SatisIslemleri satisIslemleri;
         public KategoriEkleme kategoriEkleme;
         public FirmaEkleme firmaEkleme;
         public Stokİşlemleri stokİşlemleri;
         public YeniStokEkleme yeniStokEkleme;
         public YeniStokEkleme2 yeniStokEkleme2;
        
        Form1 frm1 = (Form1)Application.OpenForms["Form1"];
      
       

        public  Form2()
        {
            InitializeComponent();
            
            ÜrünEkleme2 = new ÜrünEkleme2();
            yeniStokEkleme2 = new YeniStokEkleme2();
            kasiyerEkleme2= new KasiyerEkleme2();
            müşteriEkleme2 = new MüşteriEkleme2();
            ürünEkranı = new ÜrünEkranı();
            ürünekleme = new ÜrünEkleme();
            müşteriBilgileri = new MüşteriBilgileri();
            müşteriEkleme = new MüşteriEkleme();
            kasiyerEkleme = new KasiyerEkleme();
            kasiyerİşlemleri = new Kasiyerİşlemleri();
            satisIslemleri = new SatisIslemleri();
            kategoriEkleme = new KategoriEkleme();
            firmaEkleme = new FirmaEkleme();
            stokİşlemleri = new Stokİşlemleri();
            yeniStokEkleme = new YeniStokEkleme();
            
            ÜrünEkleme2.frm2 = this;
            yeniStokEkleme2.frm2 = this;
            kasiyerEkleme2.frm2 = this;
            müşteriEkleme2.frm2 = this;
            müşteriBilgileri.frm2 = this;
            kategoriEkleme.frm2 = this;
            kasiyerEkleme.frm2 = this;
            kasiyerİşlemleri.frm2 = this;
            müşteriEkleme.frm2 = this;
            satisIslemleri.frm2 = this;
            stokİşlemleri.frm2 = this;
            ürünekleme.frm2 = this;
            ürünEkranı.frm2= this;
            yeniStokEkleme.frm2 = this;
            firmaEkleme.frm2 = this;
            


        }
        public SqlConnection bag = new SqlConnection(@"Data Source=MSIBRAVO\SQLEXPRESS01;Initial Catalog=Tablo;Integrated Security=True");
       
        public DataTable tabloMusteri = new DataTable();     
        public DataTable tabloUrun = new DataTable();     
        public DataTable tabloKategori = new DataTable();  
        public DataTable tabloFirma = new DataTable(); 
        public DataTable tabloKasiyer = new DataTable();
        public DataTable tabloStok = new DataTable();
        public DataTable tabloSatis = new DataTable();
        public DataTable tabloSepet = new DataTable();
        public SqlCommand kmt = new SqlCommand();

        public bool durum;
        public void gununSatisListele()
        {
            
            tabloSatis.Clear();
            bag.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select Fatura_No,Musteri_Adi,Musteri_Soyadi,TC_Kimlik,Urun_Adi,Satis_Fiyat,Adet,Toplam_Tutar,Kasa_No,Tarih from Satis Where Tarih = '" + dateTimePicker1.Text + "'", bag);          
            adtr.Fill(tabloSatis);
            dataGridView1.DataSource = tabloSatis;
            bag.Close();
        }
        public void tcKimlikKasiyerKontrol()
        {
            durum = false;
            byte TcKimlik;
            bag.Open();
            kmt.Connection = bag;
            kmt.CommandText = "Select Count (Kasiyer_TC) from Kasiyer Where Kasiyer_TC='" + kasiyerEkleme.textBox3.Text  + "'";
            TcKimlik = byte.Parse(kmt.ExecuteScalar().ToString());
            if (TcKimlik > 0) durum = true;
            bag.Close();
        }

        public void tcKimlikKontrol()
        {
            durum = false;
            byte sayTcKimlik;
            bag.Open();
            kmt.Connection = bag;
            kmt.CommandText = "Select Count (Musteri_TC) from Musteri Where Musteri_TC='" + müşteriEkleme.textBox3.Text + "'";
            sayTcKimlik = byte.Parse(kmt.ExecuteScalar().ToString());
            if (sayTcKimlik > 0) durum = true;
            bag.Close();
        }
        public void urunKontrol()
        {
            durum = false;
            byte sayUrun;
            bag.Open();
            kmt.Connection = bag;
            kmt.CommandText = "Select Count (Urun_Adi) from Stok Where Urun_Adi='" + yeniStokEkleme.comboBox1.Text + "'";
            sayUrun = byte.Parse(kmt.ExecuteScalar().ToString());
            if (sayUrun > 0) durum = true;
            bag.Close();
        }
        public void urunKoduKontrol()
        {
            durum = false;
            byte sayUrunKodu;
            bag.Open();
            kmt.Connection = bag;
            kmt.CommandText = "Select Count (Urun_Kodu) from Urun Where Urun_Kodu='" + ürünekleme.textBox2.Text + "'";
            sayUrunKodu = byte.Parse(kmt.ExecuteScalar().ToString());
            if (sayUrunKodu > 0) durum = true;
            bag.Close();
        }
        public void musteriListele()
        {
            tabloMusteri.Clear();
            bag.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select Musteri_Adi,Musteri_Soyadi,Musteri_TC,Musteri_CepTel,Musteri_EvTel,Musteri_Adres from Musteri", bag);
            adtr.Fill(tabloMusteri);
            müşteriBilgileri.dataGridView1.DataSource = tabloMusteri;
            satisIslemleri.dataGridView1.DataSource = tabloMusteri;
            bag.Close();
        }
        public void urunListele()
        {
            tabloUrun.Clear();
            bag.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select Urun_Adi,Urun_Kodu,Firma_Adi,Alis_Fiyati,Satis_Fiyati,Kategori from Urun", bag);
            adtr.Fill(tabloUrun);
            ürünEkranı.dataGridView1.DataSource = tabloUrun;
            bag.Close();
        }
        public void kategoriListele()
        {
            tabloKategori.Clear();
            bag.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select Kategori_Adi from Kategori", bag);
            adtr.Fill(tabloKategori);
            kategoriEkleme.dataGridView1.DataSource = tabloKategori;
            bag.Close();
        }
        public void firmaListele()
        {
            tabloFirma.Clear();
            bag.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select FirmaAdi,FirmaAdresi from Firma", bag);
            adtr.Fill(tabloFirma);
            firmaEkleme.dataGridView1.DataSource = tabloFirma;
            bag.Close();
        }
        public void kasiyerListele()
        {
            tabloKasiyer.Clear();
            bag.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select Kasiyer_Adi,Kasiyer_Soyadi,Kasiyer_TC,Kasiyer_Tel,Kasiyer_evTel,Kasiyer_Adres,Kasiyer_Maas,Kasiyer_KasaNo,Kasiyer_GorevBaslangici,Kasiyer_GorevBitimi from Kasiyer", bag);
            adtr.Fill(tabloKasiyer);
            kasiyerİşlemleri.dataGridView1.DataSource = tabloKasiyer;
            bag.Close();
        }
        public void stokListele()
        {
            tabloStok.Clear();
            bag.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select Urun_Adi,Adet,Birim_Fiyat,KDV,Satis_Fiyat from Stok", bag);
            adtr.Fill(tabloStok);
            stokİşlemleri.dataGridView1.DataSource = tabloStok;
            bag.Close();
        }
        public void urunComboEkle()
        {
            yeniStokEkleme.comboBox1.Items.Clear(); 
            yeniStokEkleme2.comboBox1.Items.Clear();
            bag.Open();
            kmt.Connection = bag;
            kmt.CommandText = "Select Urun_Adi from Urun";
            
            SqlDataReader oku;
            oku = kmt.ExecuteReader();
            while (oku.Read())
            {
                if (yeniStokEkleme.comboBox1.Items.IndexOf(oku[0].ToString()) == -1 && oku[0].ToString().Trim() != "") yeniStokEkleme.comboBox1.Items.Add(oku[0].ToString());
                if (yeniStokEkleme2.comboBox1.Items.IndexOf(oku[0].ToString()) == -1 && oku[0].ToString().Trim() != "") yeniStokEkleme2.comboBox1.Items.Add(oku[0].ToString());
            }
            bag.Close();
            oku.Dispose();
        }
        public void urunSatisComboEkle()
        {
            satisIslemleri.comboBox2.Items.Clear();
            bag.Open();
            kmt.Connection = bag;
            kmt.CommandText = "Select Urun_Adi from Stok Where Adet>0";          
            SqlDataReader oku;
            oku = kmt.ExecuteReader();
            while (oku.Read())
            {
                if (satisIslemleri.comboBox2.Items.IndexOf(oku[0].ToString()) == -1 && oku[0].ToString().Trim() != "") satisIslemleri.comboBox2.Items.Add(oku[0].ToString());

            }
            bag.Close();
            oku.Dispose();
        }
        public void urunSatisFiyatTextEkle()
        {

            bag.Open();
            kmt.Connection = bag;
            kmt.CommandText = "Select Urun_Adi,Satis_Fiyat from Stok";
            SqlDataReader oku;
            oku = kmt.ExecuteReader();
            while (oku.Read())
            {
                if (satisIslemleri.comboBox2.Text == oku[0].ToString()) satisIslemleri.textBox6.Text = oku[1].ToString();

            }
            bag.Close();
            oku.Dispose();
        }
      
         public void sepetListele()
        {
            
            tabloSepet.Clear();
            bag.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("Select Urun_Adı,Satis_Fiyat,Adet,Toplam_Tutar,Kasa_No from sepet", bag);
            adtr.Fill(tabloSepet);
            satisIslemleri.dataGridView2.DataSource = tabloSepet;
            bag.Close();
            


        } 
        public void firmaComboEkle()
        {
            ürünekleme.comboBox1.Items.Clear();
            bag.Open();
            kmt.Connection = bag;
            kmt.CommandText = "Select FirmaAdi from Firma";
            SqlDataReader oku;
            oku = kmt.ExecuteReader();
            while (oku.Read())
            {
                if (ürünekleme.comboBox1.Items.IndexOf(oku[0].ToString()) == -1 && oku[0].ToString().Trim() != "") ürünekleme.comboBox1.Items.Add(oku[0].ToString());
            }
            bag.Close();
            oku.Dispose();
        }
        public void kategoriComboEkle()
        {
            ürünekleme.comboBox2.Items.Clear();
            bag.Open();
            kmt.Connection = bag;
            kmt.CommandText = "Select Kategori_Adi from Kategori";
            SqlDataReader oku;
            oku = kmt.ExecuteReader();
            while (oku.Read())
            {
                if (ürünekleme.comboBox2.Items.IndexOf(oku[0].ToString()) == -1 && oku[0].ToString().Trim() != "") ürünekleme.comboBox2.Items.Add(oku[0].ToString());
            }
            bag.Close();
            oku.Dispose();
        }
        
       
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            gununSatisListele();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if(frm1.yetki.ToString() == "1")
            {
                ürünEkranı.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bu alana giriş yetkiniz yoktur.");
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            müşteriBilgileri.ShowDialog();
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
           if(frm1.yetki.ToString() == "1" )
            {
              kasiyerİşlemleri.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bu alana giriş yetkiniz yoktur.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            satisIslemleri.ShowDialog();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            stokİşlemleri.ShowDialog();
        }
        
        private void Form2_Load(object sender, EventArgs e)
        {


            
            gununSatisListele();
            try
            {
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;                             
                dataGridView1.Columns[0].HeaderText = "Fatura No";           
                dataGridView1.Columns[1].HeaderText = "Müşteri Adı";
                dataGridView1.Columns[2].HeaderText = "Müşteri Soyadı";
                dataGridView1.Columns[3].HeaderText = "Tc Kimlik";
                dataGridView1.Columns[4].HeaderText = "Ürün Adı";
                dataGridView1.Columns[5].HeaderText = "Satış Fiyatı";
                dataGridView1.Columns[6].HeaderText = "Adet";
                dataGridView1.Columns[7].HeaderText = "Toplam Tutar";
                dataGridView1.Columns[8].HeaderText = "Kasa No";
                dataGridView1.Columns[9].HeaderText = "Tarih";
            }
            catch
            {
                ;
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
    
}
