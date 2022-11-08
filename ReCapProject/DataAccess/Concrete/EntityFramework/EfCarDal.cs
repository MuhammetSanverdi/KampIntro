using Core.DataAccess;
using DataAccess.Absract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<CarDetailDto> GetAllCarDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                IQueryable<CarDetailDto> result = from cars in context.Cars
                                                  join colors in context.Colors
                                                  on cars.ColorId equals colors.Id
                                                  join brands in context.Brands
                                                  on cars.BrandId equals brands.Id
                                                  select new CarDetailDto
                                                  {
                                                      CarId = cars.Id,
                                                      BrandId = brands.Id,
                                                      ColorId = colors.Id,
                                                      BrandName = brands.Name,
                                                      ColorName = colors.Name,
                                                      CarName = cars.Description,
                                                      DailyPrice = cars.DailyPrice,
                                                      ImagePath = (from i in context.CarImages where i.CarId == cars.Id select i.ImagePath).ToList()
                                                  };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarsByBrandId(int id)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                IQueryable<CarDetailDto> result = from cars in context.Cars
                                                  join brands in context.Brands
                                                  on cars.BrandId equals brands.Id
                                                  join colors in context.Colors
                                                  on cars.ColorId equals colors.Id
                                                  where brands.Id == id

                                                  select new CarDetailDto
                                                  {
                                                      CarId = cars.Id,
                                                      BrandId = brands.Id,
                                                      ColorId = colors.Id,
                                                      BrandName = brands.Name,
                                                      ColorName = colors.Name,
                                                      CarName = cars.Description,
                                                      DailyPrice = cars.DailyPrice,
                                                      ImagePath = (from i in context.CarImages where i.CarId == cars.Id select i.ImagePath).ToList()
                                                  };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarsByColorId(int id)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                IQueryable<CarDetailDto> result = from cars in context.Cars
                                                  join brands in context.Brands
                                                  on cars.BrandId equals brands.Id
                                                  join colors in context.Colors
                                                  on cars.ColorId equals colors.Id
                                                  where colors.Id == id

                                                  select new CarDetailDto
                                                  {
                                                      CarId = cars.Id,
                                                      BrandId = brands.Id,
                                                      ColorId = colors.Id,
                                                      BrandName = brands.Name,
                                                      ColorName = colors.Name,
                                                      CarName = cars.Description,
                                                      DailyPrice = cars.DailyPrice,
                                                      ImagePath = (from i in context.CarImages where i.CarId == cars.Id select i.ImagePath).ToList()
                                                  };
                return result.ToList();
            }
        }


        public CarDetailDto GetCarDetailByCarId(int id)
        {
            using (CarRentalContext context = new CarRentalContext())
            {

                IQueryable<CarDetailDto> result = from cars in context.Cars
                                                  join brands in context.Brands
                                                  on cars.BrandId equals brands.Id
                                                  join colors in context.Colors
                                                  on cars.ColorId equals colors.Id
                                                  where cars.Id == id
                                                  select new CarDetailDto
                                                  {
                                                      CarId = cars.Id,
                                                      BrandId = brands.Id,
                                                      ColorId = colors.Id,
                                                      BrandName = brands.Name,
                                                      ColorName = colors.Name,
                                                      CarName = cars.Description,
                                                      DailyPrice = cars.DailyPrice,
                                                      ImagePath = (from i in context.CarImages where i.CarId == cars.Id select i.ImagePath).ToList()
                                                  };
                return result.First();
            }
        }

        public List<CarDetailDto> GetCarDetailsByBrandIdAndColorId(int brandId, int colorId)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                IQueryable<CarDetailDto> result = from cars in context.Cars
                                                  join brands in context.Brands
                                                  on cars.BrandId equals brands.Id
                                                  join colors in context.Colors
                                                  on cars.ColorId equals colors.Id
                                                  where colors.Id == colorId
                                                  where brands.Id == brandId
                                                  select new CarDetailDto
                                                  {
                                                      CarId = cars.Id,
                                                      BrandId = brands.Id,
                                                      ColorId = colors.Id,
                                                      BrandName = brands.Name,
                                                      ColorName = colors.Name,
                                                      CarName = cars.Description,
                                                      DailyPrice = cars.DailyPrice,
                                                      ImagePath = (from i in context.CarImages where i.CarId == cars.Id select i.ImagePath).ToList()
                                                  };

                return result.ToList();
            }

        }
    }
}
