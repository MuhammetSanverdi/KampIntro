﻿using Business.Concrete;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using Core.Utilities.Helpers;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Added();
            //CarsListed();
            //AddCar();
            //UserAdd();
            //AddTestDemo();


            //Ornek ornek = new Ornek();
            //new Ornek();
            var ids = new List<Ornek> { new Ornek { Id = 2 }, new Ornek { Id= 3 }, new Ornek{Id = 4}};
            var ornek = new Ornek();
            ornek.Id = 1;

            var intCollection = typeof(Ornek).GetProperty("Id",System.Reflection.BindingFlags.Public|System.Reflection.BindingFlags.Instance);
            var sayilar = intCollection.GetValue(new Ornek()) as dynamic;
            foreach (var sayi in sayilar)
            {
                Console.WriteLine(sayi);
            }
        }

        class Ornek
        {
            public int Id { get; set; }
            string[] Isimler = new string[10];
            public string this[int i]
            {
                get
                {
                    return Isimler[i];
                }
                set
                {
                    Isimler[i] = value;
                }
            }
        }

        private static void AddTestDemo()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(new Rental
            {
                CarId = 3,
                CustomerId = 1,
                RentDate = new DateTime(2022, 03, 22, 11, 10, 47),
                ReturnDate = DateTime.Now
            });
            Console.WriteLine(result.Message);
        }

        private static void UserAdd()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var addedUser = userManager.Add(new User
            {
                FirstName = "Muhammet",
                LastName = "Şanverdi",
                Email = "muhammets@xxxxx.com",
            });
            Console.WriteLine(addedUser.Message);
        }

        private static IResult AddCar()
        {
            CarManager carManager = new CarManager(new EfCarDal(),new CarImageManager(new EfCarImageDal(),new FileHelper()));

            var car = new Car
            {
                BrandId = 5,
                ColorId = 4,
                DailyPrice = 2500,
                Description = "sdfsdfsd",
                ModelYear = 2025
            };
            var result = carManager.Add(car);
            return result;
        }

        private static void CarsListed()
        {
            CarManager carManager = new CarManager(new EfCarDal(), new CarImageManager(new EfCarImageDal(), new FileHelper()));
            var result = carManager.GetAll();
            foreach (var car in result.Data)
            {
                Console.WriteLine(car.Description);
            }
        }

        private static void Added()
        {
            CarManager carManager = new CarManager(new EfCarDal(), new CarImageManager(new EfCarImageDal(), new FileHelper()));
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            CarAddDemo();
            List<Brand> brands = new List<Brand>
            {
                new Brand{Name = "Volvo"},
                new Brand{Name = "Honda"},
                new Brand{Name = "Volkswagen"},
                new Brand{Name = "Renault"}
            };
            List<Color> colors = new List<Color>
            {
                new Color{Name="Siyah"},
                new Color{Name="Beyaz"},
                new Color{Name="Kırmızı"},
                new Color{Name="Gümüş Gri"},
                new Color{Name="Mavi"}
            };
            foreach (var brand in brands)
            {
                brandManager.Add(brand);
            }
            foreach (var color in colors)
            {
                colorManager.Add(color);
            }
        }

        private static void CarAddDemo()
        {
            List<Car> cars = new List<Car>
           {
               new Car{BrandId=2, ColorId=4, DailyPrice=300, ModelYear=2015, Description="Accord Benzinli Otomatik Vites"},
               new Car{BrandId=1, ColorId=2, DailyPrice=650, ModelYear=2020, Description="S90 Dizel Otomatik Vites"},
               new Car{BrandId=3, ColorId=4, DailyPrice=425, ModelYear=2022, Description="Golf Dizel Otomatik Vites"},
               new Car{BrandId=4, ColorId=5, DailyPrice=500, ModelYear=2018, Description="Megane Benzinli Otomatik Vites"},
           };
            CarManager carManager = new CarManager(new EfCarDal(), new CarImageManager(new EfCarImageDal(), new FileHelper()));

            foreach (var car in cars)
            {
                carManager.Add(car);
            }
        }
    }
}
