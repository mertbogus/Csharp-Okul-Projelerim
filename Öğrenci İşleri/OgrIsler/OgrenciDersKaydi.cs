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
    public partial class OgrenciDersKaydi : Form
    {
        public OgrenciDersKaydi()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Server=79.123.131.26;Database=ogrenci;User ID=user01; Password=abc123+");
        private void OgrenciDersKaydi_Load(object sender, EventArgs e)
        {
            BolumListe();
        }
        void BolumListe()
        {

            try
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

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata Meydana Geldi.\nHata:" + ex.Message);

            }
            finally
            {
                baglanti.Close();

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
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
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata Meydana Geldi.\nHata:" + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                SqlCommand sorgu = new SqlCommand();
                sorgu.Connection = baglanti;
                sorgu.CommandText = "select ogr_okul.ogrno,ogr_bilgi.adi+' '+ogr_bilgi.soyadi as 'adisoyadi',ogr_okul.sinif,ogr_ogrenim.ogr_tur_adi,ogr_danisman.dadi from ogr_bilgi,ogr_okul,ogr_ogrenim,ogr_danisman where ogr_bilgi.ogrno=ogr_okul.ogrno and ogr_okul.ogr_tur=ogr_ogrenim.ogr_tur and ogr_okul.dkodu=ogr_danisman.dkodu and ogr_okul.pkodu=@pkodu";
                sorgu.Parameters.AddWithValue("@pkodu", comboBox2.SelectedValue);
                SqlDataAdapter adp = new SqlDataAdapter(sorgu);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
                groupBox3.Visible = false;
                ogrencino = "";
            }
            catch (Exception ex)
            {

                MessageBox.Show("Bir Hata Meydana Geldi. Lütfen İşlemlerinizi Kontrol Edin.\nHata:" + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }
        string ogrencino = "";
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ogrencino = dataGridView1.SelectedCells[0].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(ogrencino) == false)
            {
                groupBox3.Visible = true;
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                SqlCommand sorgu = new SqlCommand("select ogr_dersler.derskodu,ogr_dersler.dersadi,ogr_dersler.akts,ogr_danisman.dadi from ogr_dersler,ogr_danisman where ogr_dersler.dkodu=ogr_danisman.dkodu", baglanti);
                SqlDataAdapter adp = new SqlDataAdapter(sorgu);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dataGridView2.DataSource = dt;
                dataGridView2.Refresh();
                baglanti.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult tus = MessageBox.Show("Seçili Olan Dersleri, İlgili Öğrenci İçin Kaydetmek İstiyor musunuz?", "Ders Kayıt İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (tus == DialogResult.Yes)
                {
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(dataGridView2.Rows[i].Cells[0].Value) == true)
                        {
                            if (baglanti.State == ConnectionState.Closed)
                            {
                                baglanti.Open();
                            }
                            SqlCommand sorgu = new SqlCommand("Insert Into ogr_AlinanDersler(ogrno,derskodu) values(@ogrno,@derskodu)", baglanti);
                            sorgu.Parameters.AddWithValue("@ogrno", ogrencino);
                            sorgu.Parameters.AddWithValue("@derskodu", dataGridView2.Rows[i].Cells[1].Value);
                            sorgu.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);

            }
            finally
            {
                baglanti.Close();
            }
        }
    }
}
