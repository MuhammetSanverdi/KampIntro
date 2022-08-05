using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string CarUpdated = "Araba güncellendi";
        public static string CarDeleted = "Araba silindi";
        public static string CarsListed = "Arabalar Listelendi";
        public static string CarDetailsListed = "Araba Detayları listelendi";
        public static string CarInvalid = "Arabanın model yılı " + DateTime.Now.Year + " 'den daha yeni olamaz ve açıklama 2 karakterden fazla olmalıdır ve Fiyatı 0 veya daha fazla olmalıdır";

        public static string BrandAdded = "Marka eklendi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandInvalid = "Marka ismi en az iki karakter olmalıdır";
        public static string BrandListed = "Marka listelendi";
        public static string BrandsListed = "Markalar Listelendi";

        public static string ColorAdded = "Renk eklendi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorsListed = "Renkler Listelendi";
        public static string ColorInvalid = "Renk ismi en az iki karakter olmalıdır";

        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UsersListed = "Kullanıcılar Listelendi";
        public static string UserInvalid = "Kullanıcı ismi ve soyismi iki karakterden fazla olmalıdır ve email doğru yazılmalıdır";

        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerUpdated = "Müşteri güncellendi";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string CustomersListed = "Müşteriler Listelendi";
        public static string CustomerInvalid = "Müşteri ismi en az iki karakter olmalıdır";

        public static string RentalAdded = "Araç kiralama bilgileri eklendi";
        public static string RentalUpdated = "Araç kiralama bilgileri güncellendi";
        public static string RentalDeleted = "Araç kiralama bilgileri silindi";
        public static string RentalsListed = "Tüm araç kiralama bilgileri Listelendi";
        public static string RentalInvalid = "Araç kiralama bilgileri yanlış";
        public static string CarImageNotFound = "Bu aracın herhangi bir fotoğrafı olmadığı için varsayılan fotoğraf gösterildi";
    }
}
