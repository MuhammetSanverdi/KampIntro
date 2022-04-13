﻿using System;

namespace Metotlar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Urun urun1 = new Urun();
            urun1.Adi = "Elma";
            urun1.Fiyati = 15;
            urun1.Aciklama = "Amasya elması";

            Urun urun2 = new Urun();
            urun2.Adi = "Karpuz";
            urun2.Fiyati = 80;
            urun2.Aciklama = "Diyarbakır karpuzu";

            Urun[] urunler = new Urun[] {urun1,urun2 };

            //type safe -- tip güvenli
            foreach (Urun urun in urunler)
            {
                Console.WriteLine(urun.Adi);
                Console.WriteLine(urun.Fiyati);
                Console.WriteLine(urun.Aciklama);
                Console.WriteLine("------------------------");
            }

            Console.WriteLine("---------------------Metotlar---------------------------");

            //instance - örnek
            //encapsulation
            SepetManager sepetManager = new SepetManager();
            sepetManager.Ekle(urun1);
            sepetManager.Ekle(urun2);
            sepetManager.Ekle2("Armut","yeşil armut", 12, 10);
            sepetManager.Ekle2("Elma", "yeşil elma", 12, 9);
            sepetManager.Ekle2("Karpuz", "Diyarbakır Karpuzu", 12, 8);

        }
    }
}


//Don't repeat yourself - DRY - Clean Code - Best Practice
