using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace klavyeden10sayi
{
    class Program
    {
        static void Main(string[] args)

        {
            
            ArrayList sayilar = new ArrayList();
            int i, sira = 1, deger = 0, pos = -1;
            for (i = 0; i < 10; i++)
            {
                do
                {
                    Console.Write(sira + ". Sayıyı Giriniz:");
                    sira++;
                    deger = Convert.ToInt32(Console.ReadLine());
                    pos = sayilar.IndexOf(deger);
                    if (pos > -1)
                    {
                        Console.WriteLine("Bu Sayı Dizide Yer Almaktadır.");
                        sira--;
                    }
                } while (pos > -1);
                sayilar.Add(deger);
               
               

            }
            Console.Clear();
            Console.WriteLine("Büyükten Küçüğe Sıralama");
            foreach (var yazdir in Buyuktenkucuge(sayilar))
            {
                
                Console.WriteLine(yazdir);
            }
            Console.WriteLine();
            Console.WriteLine("Küçükten Büyüğe Sıralama");
            foreach (var yazdir in Kucuktenbuyuge(sayilar))
            {
                Console.WriteLine(yazdir);
            }



            Console.ReadKey();
            
            
            ArrayList Buyuktenkucuge(ArrayList sayilar)
            {
                int temp;

                for (int i = 0; i < sayilar.Count - 1; i++)
                {
                    
                    for (int j = i + 1; j < sayilar.Count; j++)
                    {
                        
                        if (Convert.ToInt32(sayilar[i]) < Convert.ToInt32(sayilar[j]))
                        {

                            temp = Convert.ToInt32(sayilar[i]);
                            sayilar[i] = sayilar[j];
                            sayilar[j] = temp;
                        }
                    }
                }
                return sayilar;
            }
            ArrayList Kucuktenbuyuge(ArrayList sayilar)
            {
                int temp;

                for (int i = 0; i < sayilar.Count - 1; i++)
                {

                    for (int j = i + 1; j < sayilar.Count; j++)
                    {

                        if (Convert.ToInt32(sayilar[i]) > Convert.ToInt32(sayilar[j]))
                        {

                            temp = Convert.ToInt32(sayilar[i]);
                            sayilar[i] = sayilar[j];
                            sayilar[j] = temp;
                        }
                    }
                }
                return sayilar;
            }


        }
    }
}


