using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP3
{
     class BasvuruManager
    {
        //Method Injection
        public void BasvuruYap(IKrediManager krediManager ,List<ILoggerService> loggerServices)
        {
            //Başvuran bilgileri değerlendirme
            //
            krediManager.Hesapla();
            foreach (var item in loggerServices)
            {
                item.Log();
            }
            
        }

        public void KrediOnBilgilendirmesiYap(List<IKrediManager> krediler)
        {
            foreach (var kredi in krediler)
            {
                kredi.Hesapla();
            }
        }
    }
}
