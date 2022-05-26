using System;

namespace OOP2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Engin Demiroğ
            GercekMusteri musteri1 = new GercekMusteri();
            musteri1.CustomerNumber = "12345";
            musteri1.FirstName = "Engin";
            musteri1.LastName = "Demiroğ";
            musteri1.TcNo = "12345678910";
            musteri1.Id = 1;


            //Kodlama.io
            TuzelMusteri musteri2= new TuzelMusteri();
            musteri2.Id = 2; 
            musteri2.CustomerNumber = "54321";
            musteri2.SirketAdi = "Kodlama.io";
            musteri2.VergiNo = "1234567890";


            Musteri musteri3 = new GercekMusteri();
            Musteri musteri4 = new TuzelMusteri();
        }
    }
}