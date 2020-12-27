using System;
using System.Data.SqlTypes;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace TakimMenüsü
{
    class Program
    {
        static void Main(string[] args)
        {
            anamenü();
  
        }

            static void oyuncuekle()
            {
                StreamWriter sw = File.AppendText("C:\\Users\\Mert Böğüş\\Desktop\\TakimMenüsü\\TakimMenüsü\\oyuncular.txt");
                Console.Title = "Dosyalar Kayıt";
                Console.Write("Oyuncu Numarasını Giriniz......:");
                string numara = Console.ReadLine().ToUpper(); ;
                Console.Write("Oyuncu Adı Soyadını Girin...:");
                string adsoyad = Console.ReadLine().ToUpper();
                Console.Write("Oyuncunun Takımını Girin.....:");
                string takim = Console.ReadLine().ToUpper();
                Console.Write("Oyuncunun Oynadığı Pozisyonu Giriniz:");
                string pozisyon = Console.ReadLine().ToUpper();
                sw.WriteLine(numara);
                sw.WriteLine(adsoyad);
                sw.WriteLine(takim);
                sw.WriteLine(pozisyon);
                sw.Close();
                Console.WriteLine("Kayıt Başarıyla Eklendi.");
                Console.WriteLine();
                Console.Write("Ana Menüye Dönmek İster Misiniz?(E/H):");
                char secimm = Convert.ToChar(Console.ReadLine().ToUpper());
                if (secimm == 'E')
                {
                Console.Clear();
                anamenü();
                }

                Console.ReadLine();
            }
            static void TakimListele()
            {
                string takimadi;
                StreamReader sr = new StreamReader("C:\\Users\\Mert Böğüş\\Desktop\\TakimMenüsü\\TakimMenüsü\\oyuncular.txt");
                Console.WriteLine("Oyuncunun Numarasıt\tAdı Soyadı\t\tOynadığı Takım\t\tMevki\n");
                Console.Write("Takım Adı Giriniz:");
                takimadi = Convert.ToString(Console.ReadLine().ToUpper());
                int sayac = 0;
                string satir;
                Console.Clear();
                while ((satir = sr.ReadLine()) != null)
                {
                    string oyuncuno = satir;
                    string adisoyadi = sr.ReadLine();
                    string takimi = sr.ReadLine();
                    string mevkisi = sr.ReadLine();
                    if (takimi == takimadi)
                    {
                        Console.WriteLine(oyuncuno + "\t" + adisoyadi + "\t" + takimi + "\t\t" + mevkisi);

                    }


                }
                sr.Close();
            Console.WriteLine();
            Console.Write("Ana Menüye Dönmek İster Misiniz?(E/H):");
            char secimm = Convert.ToChar(Console.ReadLine().ToUpper());
            if (secimm == 'E')
            {
                Console.Clear();
                anamenü();
            }
            Console.ReadLine();
            }
            static void TakimdakiOyunculariSil()
            {
                string takimadi;
                StreamReader sr = new StreamReader("C:\\Users\\Mert Böğüş\\Desktop\\TakimMenüsü\\TakimMenüsü\\oyuncular.txt");
                Console.WriteLine("Oyuncunun Numarasıt\tAdı Soyadı\t\tOynadığı Takım\t\tMevki\n");
                Console.Write("Takım Adı Giriniz:");
                takimadi = Convert.ToString(Console.ReadLine().ToUpper());
                int sayac = 0;
                string satir;
                Console.Clear();
                while ((satir = sr.ReadLine()) != null)
                {
                    string oyuncuno = satir;
                    string adisoyadi = sr.ReadLine();
                    string takimi = sr.ReadLine();
                    string mevkisi = sr.ReadLine();
                    if (takimi == takimadi)
                    {
                        Console.WriteLine(oyuncuno + "\t" + adisoyadi + "\t" + takimi + "\t\t" + mevkisi);

                    }


                }
                sr.Close();
                Console.Write("\n Takım Silinsin mi?(E/H):");
                char secim = Convert.ToChar(Console.ReadLine().ToUpper());
                Console.Clear();
                if (secim == 'E')
                {
                    StreamWriter sw = new StreamWriter("C:\\Users\\Mert Böğüş\\Desktop\\TakimMenüsü\\TakimMenüsü\\gecici.txt");
                    StreamReader gsr = new StreamReader("C:\\Users\\Mert Böğüş\\Desktop\\TakimMenüsü\\TakimMenüsü\\oyuncular.txt");
                    string gsatir;
                    while ((gsatir = gsr.ReadLine()) != null)
                    {
                        string oyuncuno = gsatir;
                        string adisoyadi = gsr.ReadLine();
                        string takimi = gsr.ReadLine();
                        string mevkisi = gsr.ReadLine();
                        if ( takimi!= takimadi)
                        {
                            sw.WriteLine(oyuncuno);
                            sw.WriteLine(adisoyadi);
                            sw.WriteLine(takimi);
                            sw.WriteLine(mevkisi);
                        }
                    }
                    sw.Close();
                    gsr.Close();
                    File.Delete("C:\\Users\\Mert Böğüş\\Desktop\\TakimMenüsü\\TakimMenüsü\\oyuncular.txt");
                    File.Move("C:\\Users\\Mert Böğüş\\Desktop\\TakimMenüsü\\TakimMenüsü\\gecici.txt", "C:\\Users\\Mert Böğüş\\Desktop\\TakimMenüsü\\TakimMenüsü\\oyuncular.txt");
                    Console.WriteLine("Kayıt Başarıyla Silindi..");
                   Console.Write("Ana Menüye Dönmek İster Misiniz?(E/H):");
                   char secimm = Convert.ToChar(Console.ReadLine().ToUpper());
                    if (secimm == 'E')
                    {
                    Console.Clear();
                     anamenü();
                    }


            }
        }
            static void AdSoyadaGoreArama()
            {
                
                Console.Write("Oyuncunun Adını Soyadını Giriniz...:");
                string aranan = Console.ReadLine().ToUpper();
                Console.Clear();
                StreamReader sr = new StreamReader("C:\\Users\\Mert Böğüş\\Desktop\\TakimMenüsü\\TakimMenüsü\\oyuncular.txt");
                string satir;
                while ((satir = sr.ReadLine()) != null)
                {
                    string oyuncunumarasi = satir;
                    string adisoyadi = sr.ReadLine();
                    string takimi = sr.ReadLine();
                    string mevkisi = sr.ReadLine();
                    if (aranan == adisoyadi)
                    {
                        Console.WriteLine();
                        Console.WriteLine(oyuncunumarasi + "\t" + adisoyadi + "\t" + takimi + "\t\t" + mevkisi);
                    }
                }
            Console.WriteLine();
            Console.Write("Ana Menüye Dönmek İster Misiniz?(E/H):");
            char secimm = Convert.ToChar(Console.ReadLine().ToUpper());
            if (secimm == 'E')
            {
                Console.Clear();
                anamenü();
            }

            sr.Close();
                Console.Read();
            }
            static void OynadigiMevkiyeGoreArama()
            {
                Console.Write("Mevki Giriniz (FORVET VB)...:");
                string mevki = Console.ReadLine().ToUpper();
                Console.Clear();
                StreamReader sr = new StreamReader("C:\\Users\\Mert Böğüş\\Desktop\\TakimMenüsü\\TakimMenüsü\\oyuncular.txt");
                string satir;
                while ((satir = sr.ReadLine()) != null)
                {
                    string oyuncunumarasi = satir;
                    string adisoyadi = sr.ReadLine();
                    string takimi = sr.ReadLine();
                    string mevkisi = sr.ReadLine();
                    if (mevki == mevkisi)
                    {
                        Console.WriteLine(oyuncunumarasi + "\t" + adisoyadi + "\t" + takimi + "\t\t" + mevkisi);
   
                    }
                }
            Console.WriteLine();
            Console.Write("Ana Menüye Dönmek İster Misiniz?(E/H):");
            char secimm = Convert.ToChar(Console.ReadLine().ToUpper());
            if (secimm == 'E')
            {
                Console.Clear();
                anamenü();
            }

            sr.Close();
                Console.Read();
            }
            static void  anamenü()
            {
            int islem;
            Console.WriteLine("Seçim Menüsü");
            Console.WriteLine();
            Console.WriteLine("************* MENÜ *****************\n");
            Console.WriteLine("1-Oyuncu Ekle");
            Console.WriteLine("2-Takım Listele");
            Console.WriteLine("3-Oyuncu Ara");
            Console.WriteLine("4-Takımı Sil");
            Console.WriteLine("5-Çıkış");
            Console.Write("**********************************************\n");
            Console.Write("Yaptırmak İstediğiniz İşlemin Numarasını Giriniz: ");
            islem = Convert.ToInt16(Console.ReadLine());
            if (islem == 1)
            {
                oyuncuekle();
            }
            else if (islem == 2)
            {
                TakimListele();
            }
            else if (islem == 3)
            {
                int islemm;
                Console.WriteLine("1- Ad Soyada Göre Arama");
                Console.WriteLine("2- Oynadığı Mevkiye Göre Arama");
                Console.WriteLine();
                Console.Write("Yapmak İstediğiniz İşlem Numarasını Giriniz: ");
                islemm = Convert.ToInt16(Console.ReadLine());
                if (islemm == 1)
                {
                    AdSoyadaGoreArama();
                    Console.Write("\nÖğrenci Silinsin mi?(Evet/Hayır):");
                    string secimm = Convert.ToString(Console.ReadLine());
                    if (secimm=="Evet")
                    {
                        anamenü();
                    }
                    

                }
                else
                {
                    OynadigiMevkiyeGoreArama();
                }


            }
            else if (islem == 4)
            {
                TakimdakiOyunculariSil();
            }
            else if(islem==5)
            {
                Console.WriteLine("Program Kapanıyor...");
                Thread.Sleep(2000);
            }
            else
            {
                Console.WriteLine("Girmiş Olduğunuz İşlem Numarası Yanlış. Lütfen Kontrol Edin.");
            }
            Console.ReadLine();
            }

        }
    }

