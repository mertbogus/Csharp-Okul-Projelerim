using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Ödev
{
    /*Hocam ödevi yaparken yabancı videolara göz attım hayatımda bu kadar araştırma yapmadım kodlar hakkında. Elimden gelen bu oldu umarım beğenirsiniz. 
      Bazı farklı kodları da murat yücedağ, sende kod yaz gibi kişileri izlediğim için biliyordum.  satırları okutmada 
      ıf yerine switch kullandım çünkü birden çok durum vardı. Switch seçenegi ile degiskenin durumuna göre bir çok durum içersinden 
      bir tanesi gerçeklestiriyor.İfkullanmayada çalıştım.*/




    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tckimlik = mskdTcTxtBox.Text;
            string adi = mskdAdTxtBox.Text;
            string soyadi = mskdSoyAdTxtBox.Text;
            string dyeri = cmbDogumYer.Text;
            string dtarih = mskdDgmTarihTxtBox.Text;
            
           string ogrencino = mskdOgrnciNoTxtBox.Text;
            string bolum = cmbBolum.Text;
            string program = cmbProgram.Text;
            string adres = txtAdress.Text;
            string telefon = mskdTelTxtBox.Text;
            string ogrenimt;
            string dadi = "";
            if (ChcBirinciOgrtm.Checked==true)
            {
                ogrenimt = "Birinci Ögretim";
            }
            else
            {
                ogrenimt = "İkinci Ögretim";
            }
           
            string sinif;
            if (radBirinciSinif.Checked==true)
            {
                sinif = "1.Sınıf";

            }
            else
            {
                sinif = "2.Sınıf";
            }

            string cinsiyet;
            if (radCinsErkek.Checked==true)
            {
                cinsiyet = "Erkek";
            }
            else
            {
                cinsiyet = "kız";
            
            }


            if (mskdAdTxtBox.Text == "")
            {
                MessageBox.Show("Lütfen Adınızı Giriniz");
            }
            else if (mskdTcTxtBox.Text == "")
            {
                MessageBox.Show("Lütfen TC Kimlik Numaranızı Giriniz");
            }
            else if (cmbDogumYer.SelectedItem == null)
            {
                MessageBox.Show("Lütfen Doğum Yerinizi Giriniz");
            }
            else if (radBirinciSinif.Checked == false && radIkinciSinif.Checked == false)
            {
                MessageBox.Show("Lütfen Sınıf Seçiniz");
            }
            else if (listDanisman.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen Danışman Seçiniz");
            }
            else if (radCinsErkek.Checked == false && radCinsKadin.Checked == false)
            {
                MessageBox.Show("Lütfen Cinsiyet Seçiniz");
            }
            else if (mskdDgmTarihTxtBox.Text == "")
            {
                MessageBox.Show("Lütfen Doğum Tarihini Giriniz");
            }
            else if (txtAdress.Text == "")
            {
                MessageBox.Show("Lütfen Adres Bilgilerinizi Giriniz");
            }
            else if (mskdTelTxtBox.Text == "") 
            {

                MessageBox.Show("Lütfen Telefon Bilgilerinizi Giriniz");
            }
            else if (mskdOgrnciNoTxtBox.Text=="")
            {
                MessageBox.Show("Lütfen Öğrenci Numaranızı Giriniz");
            }
            else if (cmbBolum.SelectedIndex==-1)
            {
                MessageBox.Show("Lütfen Bölümünü Seçiniz");
            }
            else if (cmbProgram.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen Program Seçiniz");
            }
            {
                dadi = listDanisman.SelectedItem.ToString();
                listBox2.Items.Add(tckimlik);
                listBox2.Items.Add(adi);
                listBox2.Items.Add(soyadi);
                listBox2.Items.Add(dyeri);
                listBox2.Items.Add(dtarih);
                listBox2.Items.Add(cinsiyet);
                listBox2.Items.Add(adres);
                listBox2.Items.Add(telefon);
                listBox2.Items.Add(ogrencino);
                listBox2.Items.Add(bolum);
                listBox2.Items.Add(program);
                listBox2.Items.Add(sinif);
                listBox2.Items.Add(ogrenimt);
                listBox2.Items.Add(dadi);
                MessageBox.Show("Başarıyla kaydedildi!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            mskdTcTxtBox.Text = "";
            mskdAdTxtBox.Text = "";
            mskdSoyAdTxtBox.Text = "";
            cmbDogumYer.SelectedIndex = -1;
            mskdDgmTarihTxtBox.Text = "";
            

            mskdOgrnciNoTxtBox.Text = "";
            cmbBolum.SelectedIndex = -1;
            cmbProgram.SelectedIndex = -1;
            txtAdress.Text = "";
            mskdTelTxtBox.Text = "";
            radCinsKadin.Checked = false;
            radCinsErkek.Checked = false;
            radBirinciSinif.Checked = false;
           radIkinciSinif.Checked = false;
            ChcBirinciOgrtm.Checked = false;
            ChcIkinciOgrtm.Checked = false;
            listDanisman.SelectedIndex = -1;

            listBox2.Items.Clear();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                if(listBox2.Items.Count != 0)
                using(StreamWriter sw = new StreamWriter(Application.StartupPath + @"\"+textBox2.Text+".txt"))
                {
                    foreach (var item in listBox2.Items) 
                    {
                        sw.WriteLine(item.ToString());
                    }
                    MessageBox.Show("Kayıt Başarılı");
                }
                else
                {
                    MessageBox.Show("Kaydedilecek bilgi bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
           catch (Exception hata)
            {

               
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                int pozisyon = 0;
                using(StreamReader sr = new StreamReader(Application.StartupPath + @"\" + textBox3.Text + ".txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        string mert = sr.ReadLine(); // line diye bir değişken oluşturdum sr.readline okuma komutunu atadım 
                        switch (pozisyon)// switch kullandım izlediğim videolardan bunu kullanmayı doğru buldum. 
                        {
                            case 0:
                                mskdTcTxtBox.Text = mert; 
                                break;
                            case 1:
                                mskdAdTxtBox.Text = mert;
                                break;
                            case 2:
                                mskdSoyAdTxtBox.Text = mert;
                                break;
                            case 3:
                                foreach (var cmb in cmbDogumYer.Items)
                                {
                                    if (cmb.ToString() == mert)
                                    {
                                        cmbDogumYer.SelectedItem = cmb;
                                        break;
                                    }
                                }                            
                                break;
                            case 4:
                                mskdDgmTarihTxtBox.Text = mert;
                                break;
                            case 5:
                                if(mert == "Erkek")
                                {
                                    radCinsErkek.Checked = true;
                                }
                                else if(mert == "Kadın")
                                {
                                    radCinsKadin.Checked = true;
                                }
                                break;
                            case 6:
                                txtAdress.Text = mert;
                                break;
                            case 7:
                                mskdTelTxtBox.Text = mert;
                                break;
                            case 8:
                                mskdOgrnciNoTxtBox.Text = mert;
                                break;
                            case 9:
                                foreach (var cmb in cmbBolum.Items)
                                {
                                    if (cmb.ToString() == mert)
                                    {
                                        cmbBolum.SelectedItem = cmb;
                                        break;
                                    }
                                }
                                break;
                            case 10:
                                foreach (var cmb in cmbProgram.Items)
                                {
                                    if (cmb.ToString() == mert)
                                    {
                                        cmbProgram.SelectedItem = cmb;
                                        break;
                                    }
                                }
                                break;
                            case 11:
                                if (mert == "1.Sınıf")
                                    radBirinciSinif.Checked = true;
                                else if(mert == "2.Sınıf")
                                {
                                    radIkinciSinif.Checked = true;
                                }
                                break;
                            case 12:
                                if (mert == "Birinci Ögretim")
                                {
                                    ChcBirinciOgrtm.Checked = true;
                                }
                                else if(mert == "İkinci Ögretim")
                                {
                                    ChcIkinciOgrtm.Checked = true;
                                }

                                break;
                            case 13:
                                foreach(var danisman in listDanisman.Items)
                                {
                                    if (danisman.ToString() == mert) 
                                    {
                                        listDanisman.SelectedItem = danisman;
                                        break;
                                    }
                                }
                                break;
                        }
                        pozisyon++;
                        
                    }
                    MessageBox.Show("Dosya Geri Yüklenmiştir");
                }
            }
            catch (Exception hata)
            {
                
            }
        }

        private void MskdTcTxtBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
           
        }
    }
}
