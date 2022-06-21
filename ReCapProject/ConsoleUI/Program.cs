using Business.Concrete;
using DataAccess.Absract;
using DataAccess.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car { BrandId = 6, ColorId = 3,Description = "fsdgvsdfgsdf",DailyPrice = 500, ModelYear = 2011 };
            Car car2 = new Car { CarId = 1,BrandId = 6, ColorId = 3, Description = "fsdgvsdfgsdf", DailyPrice = 500, ModelYear = 2011 };
            ICarDal carDal = new InMemoryCarDal();
            CarManager carManager = new CarManager(carDal);
            carManager.Update(car2);
            carManager.Add(car1);

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

        }
    }
}
