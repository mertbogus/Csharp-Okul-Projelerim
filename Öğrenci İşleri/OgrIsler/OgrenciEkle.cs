using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace OgrIsler
{
    public partial class OgrenciEkle : Form
    {

        SqlConnection baglanti = new SqlConnection("Server=79.123.131.26;User ID=user01;Password=abc123+;Database=ogrenci");
        public OgrenciEkle()
        {
            InitializeComponent();
        }

        private void OgrenciEkle_Load(object sender, EventArgs e)
        {
            BolumListe();
            OgrenimListe();
        }

        private void OgrenimListe()
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlCommand sorgu = new SqlCommand("select * from ogr_ogrenim", baglanti);
            SqlDataAdapter adp = new SqlDataAdapter(sorgu);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            comboBox3.DisplayMember = "ogr_tur_adi";
            comboBox3.ValueMember = "ogr_tur";
            comboBox3.DataSource = dt;
            comboBox3.Refresh();
            baglanti.Close();
        }

        private void BolumListe()
        {
            if (baglanti.State==ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlCommand sorgu = new SqlCommand("select * from ogr_bolum", baglanti);
            SqlDataAdapter adp = new SqlDataAdapter(sorgu);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            comboBox1.DisplayMember = "badi";
            comboBox1.ValueMember = "bkodu";
            comboBox1.DataSource = dt;
            comboBox1.Refresh();
            baglanti.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProgramListe();
            DanismanListe();
        }
        void ProgramListe()
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlCommand sorgu = new SqlCommand("select * from ogr_program where bkodu=@bolumkodu", baglanti);
            sorgu.Parameters.AddWithValue("@bolumkodu", comboBox1.SelectedValue);
            SqlDataAdapter adp = new SqlDataAdapter(sorgu);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            comboBox2.DisplayMember = "padi";
            comboBox2.ValueMember = "pkodu";
            comboBox2.DataSource = dt;
            comboBox2.Refresh();
            baglanti.Close();
        }
        void DanismanListe()
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlCommand sorgu = new SqlCommand("select * from ogr_danisman where bkodu=@bolumkodu", baglanti);
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
            if (baglanti.State==ConnectionState.Closed)
            {
                baglanti.Open();
            }

            SqlCommand sorgubilgi = new SqlCommand();
            sorgubilgi.Connection = baglanti;
            sorgubilgi.CommandText="insert into ogr_bilgi values(@ogrno,@tckimlik,@adi,@soyadi,@cinsiyet,@dtarih)";
            sorgubilgi.Parameters.AddWithValue("@ogrno", maskedTextBox1.Text);
            sorgubilgi.Parameters.AddWithValue("@adi", maskedTextBox2.Text);
            sorgubilgi.Parameters.AddWithValue("@soyadi", maskedTextBox3.Text);
            sorgubilgi.Parameters.AddWithValue("@tckimlik", maskedTextBox4.Text);
            if (radioButton1.Checked==true)
            {
                sorgubilgi.Parameters.AddWithValue("@cinsiyet","E");
            }
            else
            {
                sorgubilgi.Parameters.AddWithValue("@cinsiyet", "K");
            }
            sorgubilgi.Parameters.AddWithValue("@dtarih", dateTimePicker1.Value.Date);

            SqlCommand sorguokul = new SqlCommand();
            sorguokul.Connection = baglanti;
            sorguokul.CommandText = "insert into ogr_okul(ogrno,pkodu,sinif,ogr_tur,dkodu) values(@ogrno,@pkodu,@sinif,@ogr_tur,@dkodu)";
            sorguokul.Parameters.AddWithValue("@ogrno", maskedTextBox1.Text);
            sorguokul.Parameters.AddWithValue("@pkodu", comboBox2.SelectedValue);
            sorguokul.Parameters.AddWithValue("@sinif", maskedTextBox5.Text);
            sorguokul.Parameters.AddWithValue("@ogr_tur", comboBox3.SelectedValue);
            sorguokul.Parameters.AddWithValue("@dkodu", listBox1.SelectedValue);

            DialogResult tus = MessageBox.Show("Girmiş Olduğunuz Bilgiler Doğrultusunda Kayıt İşlemi Yapılacaktır. Devam Etmek İstiyor musunuz?", "Kayıt İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (tus==DialogResult.Yes)
            {
                int ks1 = sorgubilgi.ExecuteNonQuery();
                int ks2 = sorguokul.ExecuteNonQuery();
                if ((ks1==ks2) &&(ks1!=0))
                {
                    MessageBox.Show("Öğrenci Kaydı Başarıyla Gerçekleşti..", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            baglanti.Close();
        }
    }
}
