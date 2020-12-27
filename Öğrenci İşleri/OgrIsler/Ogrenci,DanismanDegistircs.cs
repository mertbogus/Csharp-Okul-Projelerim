using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OgrIsler
{
    public partial class Ogrenci_DanismanDegistircs : Form
    {
        public Ogrenci_DanismanDegistircs()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Server=79.123.131.26;User ID=user01;Password=abc123+;Database=ogrenci");
        SqlConnection baglantii = new SqlConnection("Server=79.123.131.26;User ID=user01;Password=abc123+;Database=ogrenci");

        string ogrencino;
        
        private void Ogrenci_DanismanDegistircs_Load(object sender, EventArgs e)
        {
            BolumListele();

        }
        void BolumListele()
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlCommand sorgu = new SqlCommand("Select * from ogr_bolum order by badi asc", baglanti);
            SqlDataAdapter adp = new SqlDataAdapter(sorgu);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            comboBox1.DisplayMember = "badi";
            comboBox1.ValueMember = "bkodu";
            comboBox1.DataSource = dt;
            comboBox1.Refresh();
            baglanti.Close();
        }
        void DanismanListele()
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlCommand sorgu = new SqlCommand("select * from ogr_danisman where bkodu=@bolumkodu ", baglanti);
            sorgu.Parameters.AddWithValue("@bolumkodu", comboBox1.SelectedValue);
            SqlDataAdapter adp = new SqlDataAdapter(sorgu);

            DataTable dt = new DataTable();
            adp.Fill(dt);
            listBox1.DisplayMember = "dadi";
            listBox1.ValueMember = "dkodu";
            listBox1.DataSource = dt;
            listBox1.Refresh();
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlCommand sorgu = new SqlCommand();
            sorgu.Connection = baglanti;
            sorgu.CommandText = "select ogr_okul.ogrno,ogr_bilgi.adi+' '+ogr_bilgi.soyadi as 'adisoyadi',ogr_bolum.badi,ogr_program.padi,ogr_danisman.dadi from ogr_okul,ogr_bilgi,ogr_bolum,ogr_program,ogr_danisman where ogr_bilgi.ogrno=ogr_okul.ogrno and ogr_danisman.dkodu=ogr_okul.dkodu and ogr_program.bkodu=ogr_bolum.bkodu and ogr_danisman.bkodu=ogr_bolum.bkodu and ogr_program.pkodu=@pkodu";
            sorgu.Parameters.AddWithValue("@pkodu", comboBox2.SelectedValue);
            SqlDataAdapter adp = new SqlDataAdapter(sorgu);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            ogrencino = "";
            baglanti.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlCommand sorgu = new SqlCommand();
            sorgu.Connection = baglanti;
            sorgu.CommandText = "select * from ogr_program where bkodu=@bkodu";
            sorgu.Parameters.AddWithValue("@bkodu", comboBox1.SelectedValue);
            SqlDataAdapter adp = new SqlDataAdapter(sorgu);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            comboBox2.DisplayMember = "padi";
            comboBox2.ValueMember = "pkodu";
            comboBox2.DataSource = dt;
            comboBox2.Refresh();
            DanismanListele();
            baglanti.Close();

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            DialogResult tus = MessageBox.Show("Seçili Öğrencinin Danışman Bilgilerini Güncellemek İstiyor musunuz?", "Güncelleme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tus == DialogResult.Yes)
            {

                if (baglantii.State == ConnectionState.Closed)
                {
                    baglantii.Open();
                }
                SqlCommand sorgubilgi = new SqlCommand("select * from ogr_bilgi where ogrno=@ogrno", baglantii);
                sorgubilgi.Parameters.AddWithValue("@ogrno", ogrencino);
                SqlDataReader sdrbilgi = sorgubilgi.ExecuteReader();
                sdrbilgi.Read();
                label8.Text = sdrbilgi["ogrno"].ToString();
                label9.Text = sdrbilgi["adi"].ToString();
                label10.Text = sdrbilgi["soyadi"].ToString();
                DanismanListele();
                sdrbilgi.Close();
                baglantii.Close();

                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                SqlCommand sorguokul = new SqlCommand("select * from ogr_okul where ogrno=@ogrno", baglanti);
                sorguokul.Parameters.AddWithValue("@ogrno", ogrencino);
                SqlDataReader sdrokul = sorguokul.ExecuteReader();
                sdrokul.Read();
                label12.Text = sdrokul["pkodu"].ToString();
                string dkodu = sdrokul["dkodu"].ToString();
                listBox1.SelectedValue = dkodu;
                sdrokul.Close();
                baglanti.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ogrencino = dataGridView1.SelectedCells[0].Value.ToString();
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1_CellDoubleClick(null, null);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlCommand sorgu = new SqlCommand("select bkodu from ogr_program where pkodu=@pkodu", baglanti);
            sorgu.Parameters.AddWithValue("@pkodu", comboBox2.SelectedValue);
            SqlDataAdapter adp = new SqlDataAdapter(sorgu);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            string bkodu = Convert.ToString(sorgu.ExecuteScalar());
            comboBox1.SelectedValue = bkodu;
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlCommand sorgubilgi = new SqlCommand();
            sorgubilgi.Connection = baglanti;
            sorgubilgi.CommandText = "Update ogr_okul set dkodu=@dkodu where ogrno=@eskiogrno";
            sorgubilgi.Parameters.AddWithValue("@dkodu", listBox1.SelectedValue);
            sorgubilgi.Parameters.AddWithValue("@eskiogrno", ogrencino);
            DialogResult tus = MessageBox.Show("Yaptığınız Değişikleri İlgili Öğrenci İçin Güncellemek İstiyor musunuz?", "Güncelleme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (tus == DialogResult.Yes)
            {
                int ksbilgi = sorgubilgi.ExecuteNonQuery();
                if (ksbilgi>0)
                {
                    MessageBox.Show("Öğrencinin Danışmanı Başarılı Bir Şekilde Değiştirildi.");
                }
            }
        }
    }
}
