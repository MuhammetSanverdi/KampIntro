using System;

namespace KampIntro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //değer tutucu , alias
            string kategoriEtiketi = "Kategoriler";
            int ogrenciSayisi = 32000;
            double faizOrani = 1.45;
            bool sistemeGirisYapmisMi = true;
            double dolarınDun = 7.55;
            double dolarBugun = 7.55;

            if (dolarınDun > dolarBugun)
            {
                Console.WriteLine("Azalış Butonu");
            }
            else if (dolarınDun < dolarBugun)
            {
                Console.WriteLine("Artış Butonu");
            }
            else
            {
                Console.WriteLine("Değişmedi Butonu");
            }


            if (sistemeGirisYapmisMi == true)
            {
                Console.WriteLine("Kullanıcı ayarları butonu");
            }
            else
            {
                Console.WriteLine("Giriş yap butonu");
            }

            ////Do not repeat yourself - Kendini tekrar etme

            //Console.WriteLine("Kategori");

            //Console.WriteLine("Kategori");

            //Console.WriteLine("Kategori");

            //Console.WriteLine("Kategori");

            //Console.WriteLine("Kategori");

        }
    }
}
