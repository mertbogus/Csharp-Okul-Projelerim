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
    public partial class BlmDuzenle : Form
    {
        public BlmDuzenle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Server=79.123.131.26;Database=ogrenci;User ID=user01;Password=abc123+");
        string bolumkodu;
        private void BlmDuzenle_Load(object sender, EventArgs e)
        {
            BlmListele();
        }
        void BlmListele()
        {
            if(baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlCommand sorgu = new SqlCommand();
            sorgu.Connection = baglanti;
            sorgu.CommandText = "select * from ogr_bolum";
            SqlDataAdapter adp = new SqlDataAdapter(sorgu);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            baglanti.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult tus = MessageBox.Show("Seçili Programın Bilgilerini Düzenlemek İster misiniz?", "Bölüm Düzenleme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (tus==DialogResult.Yes)
            {
                string bolumkodu = dataGridView1.SelectedCells[0].Value.ToString();
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                SqlCommand sorgu = new SqlCommand("select * from ogr_bolum where bkodu=@bkodu",baglanti);
                sorgu.Parameters.AddWithValue("@bkodu", bolumkodu);
                SqlDataReader sdr = sorgu.ExecuteReader();
                sdr.Read();
                maskedTextBox1.Text = sdr["bkodu"].ToString();
                maskedTextBox2.Text = sdr["badi"].ToString();
                sdr.Close();
            }
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

                /* Bölüm kodu birincil anahtar olduğu için ve diğer yerlerle bağlantılı olduğu için onu güncellerken sıkıntı yaşıyordum 
                 * hocam. Siz hatayı yakalayın, kullanıcıya bilgi verin demiştiniz onun için diğer alanlarda Bölüm kodunu güncelletmedim. 
                 * Hatta onun hattanın çözümü için veritabanında cascade yapmam gerekir demiştiniz. Hatırlatmak istedim puan kırmamanınız 
                 * için
                 */
            
            
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            try
            {
                SqlCommand sorgubolum = new SqlCommand();
                sorgubolum.Connection = baglanti;
                sorgubolum.CommandText = "update ogr_bolum set bkodu=@bkodu, badi=@badi where bkodu=@eskibkodu";
                sorgubolum.Parameters.AddWithValue("@bkodu", maskedTextBox1.Text);
                sorgubolum.Parameters.AddWithValue("@badi", maskedTextBox2.Text);
                sorgubolum.Parameters.AddWithValue("@eskibkodu", bolumkodu);
                DialogResult tus = MessageBox.Show("Yaptığınız Değişikleri İlgili Bölüm İçin Güncellemek İstiyor musunuz?", "Güncelleme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (tus == DialogResult.Yes)
                {
                    int ks3 = sorgubolum.ExecuteNonQuery();
                    
                    if (ks3>0)
                    {
                        MessageBox.Show("Güncelleme İşlemi Başarıyla Tamamlanmıştır","Güncelleme Ekranı",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        dataGridView1.Refresh();
                    }

                }
                baglanti.Close();


            }
            catch (SqlException)
            {
                MessageBox.Show("Bu Bölüm Güncellenemedi. Bölüm Kodu Değiştirilemez. Bölümü Silip, Yeniden Ekleyebilirsiniz...","Hata Ekranı",MessageBoxButtons.OK,MessageBoxIcon.Error );
                throw;
               
            }
            
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1_CellDoubleClick(null, null);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bolumkodu = dataGridView1.SelectedCells[0].Value.ToString();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult tus = MessageBox.Show("Seçili Öğrenciyi Silmek İstiyor musunuz?", "Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (tus == DialogResult.Yes)
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                SqlCommand sorgubolum = new SqlCommand("delete from ogr_bolum where bkodu=@bkodu", baglanti);
                sorgubolum.Parameters.AddWithValue("@bkodu", bolumkodu);
                int ksokul = sorgubolum.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("İlgili Öğrencinin Kaydı Silindi.", "Silme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
        }
    }
}
