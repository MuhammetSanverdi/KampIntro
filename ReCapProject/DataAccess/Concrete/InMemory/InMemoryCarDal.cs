using DataAccess.Absract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
           {
               new Car{CarId=1, BrandId=2, ColorId=1, DailyPrice=400, ModelYear=2017, Description="Civic Benzinli Manuel Vites"},
               new Car{CarId=2, BrandId=2, ColorId=4, DailyPrice=300, ModelYear=2015, Description="Accord Benzinli Otomatik Vites"},
               new Car{CarId=3, BrandId=1, ColorId=2, DailyPrice=650, ModelYear=2020, Description="S90 Dizel Otomatik Vites"},
               new Car{CarId=4, BrandId=3, ColorId=4, DailyPrice=425, ModelYear=2022, Description="Golf Dizel Otomatik Vites"},
               new Car{CarId=5, BrandId=4, ColorId=5, DailyPrice=500, ModelYear=2018, Description="Megane Benzinli Otomatik Vites"},
           };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            var deletedCar = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(deletedCar);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetAllByCarId(int carId)
        {
            return _cars.SingleOrDefault(c => c.CarId == carId);
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetCarsByColorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            var updatedCar = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            updatedCar.CarId = car.CarId;
            updatedCar.BrandId = car.BrandId;
            updatedCar.ColorId = car.ColorId;
            updatedCar.ModelYear = car.ModelYear;
            updatedCar.Description = car.Description;
            updatedCar.DailyPrice = car.DailyPrice;

        }
    }
}
