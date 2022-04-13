using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matematik
{
    class DortIslem
    {
        
        public void Topla(int number1, int number2)
        {
            int toplam = number1 + number2;
            Console.WriteLine("Toplama sonucunuz: "+ toplam);
        }
        public void Cikar (int number1, int number2)
        {
            int cikarma  = number1 - number2;
            Console.WriteLine("Çıkarma sonuccunuz: "+ Math.Abs(cikarma));
        }
    }
}
