using Business.Abstract;
using DataAccess.Absract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.ModelYear<= DateTime.Now.Year && car.CarId == null)
            {
                    _carDal.Add(car);
            }
            else
            {
                Console.WriteLine("Araç Kaydedilemedi");
            }
            
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car GetByCarId(int id)
        {
            return _carDal.GetAllByCarId(id);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
