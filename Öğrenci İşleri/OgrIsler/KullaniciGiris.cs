using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data;
using System.Data.SqlClient;

namespace OgrIsler
{
    public partial class KullaniciGiris : Form
    {
        public KullaniciGiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Server=79.123.131.26; User ID=user01;Password=abc123+;Database=ogrenci");
        private void button1_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            string kadi = textBox1.Text;
            string sifre = textBox2.Text;

            if ((String.IsNullOrEmpty(kadi) == true) || (String.IsNullOrEmpty(sifre) == true))
            {
                MessageBox.Show("Kullanıcı Adı ya da Şifre Boş Geçilemez.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlCommand sorgu = new SqlCommand();
                sorgu.Connection = baglanti;
                sorgu.CommandText = "select kadi,sifre from ogr_giris where kadi=@Kadi and sifre=@Sifre";
                sorgu.Parameters.AddWithValue("@Kadi", kadi);
                sorgu.Parameters.AddWithValue("@sifre", sifre);
                object sonuc = sorgu.ExecuteScalar();
                if (sonuc == null)
                {
                    MessageBox.Show("Hatalı Kullanıcı Adı ya da Şifre", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    AnaEkran ana = new AnaEkran();
                    this.Hide();
                    ana.Show();
                }
            }
            baglanti.Close();
        }
    }
}
