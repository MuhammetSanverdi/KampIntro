using Castle.Core.Resource;
using Core.DataAccess;
using Core.Entities.Concrete;
using DataAccess.Absract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from rentals in context.Rentals
                             join cars in context.Cars
                             on rentals.CarId equals cars.Id
                             join brands in context.Brands
                             on cars.BrandId equals brands.Id
                             join colors in context.Colors
                             on cars.ColorId equals colors.Id
                             join customers in context.Customers
                             on rentals.CustomerId equals customers.UserId
                             join users in context.Users
                             on rentals.CustomerId equals users.Id
                             select new RentalDetailDto
                             {
                                 CarId = cars.Id,
                                 BrandId = brands.Id,
                                 ColorId = colors.Id,
                                 CustomerId = customers.Id,
                                 UserId = users.Id,
                                 RentalId = rentals.Id,
                                 BrandName = brands.Name,
                                 ColorName = colors.Name,
                                 CompanyName = customers.CompanyName,
                                 DailyPrice = cars.DailyPrice,
                                 Description = cars.Description,
                                 CustomerName = users.FirstName + " " + users.LastName,
                                 RentDate = rentals.RentDate,
                                 ReturnDate = rentals.RentDate
                             };

                return result.ToList();



            }
        }

        public List<RentalDetailDto> GetRentalDetailsByCarId(int carId)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                IQueryable<RentalDetailDto> result = from rentals in context.Rentals
                                                     join cars in context.Cars
                                                     on rentals.CarId equals cars.Id
                                                     join brands in context.Brands
                                                     on cars.BrandId equals brands.Id
                                                     join colors in context.Colors
                                                     on cars.ColorId equals colors.Id
                                                     join customers in context.Customers
                                                     on rentals.CustomerId equals customers.Id
                                                     join users in context.Users
                                                     on rentals.CustomerId equals users.Id
                                                     where rentals.CarId == carId
                                                     select new RentalDetailDto
                                                     {
                                                         CarId = cars.Id,
                                                         BrandId = brands.Id,
                                                         ColorId = colors.Id,
                                                         CustomerId = customers.Id,
                                                         UserId = users.Id,
                                                         RentalId = rentals.Id,
                                                         BrandName = brands.Name,
                                                         ColorName = colors.Name,
                                                         CompanyName = customers.CompanyName,
                                                         DailyPrice = cars.DailyPrice,
                                                         Description = cars.Description,
                                                         CustomerName = users.FirstName + " " + users.LastName,
                                                         RentDate = rentals.RentDate,
                                                         ReturnDate = rentals.RentDate
                                                     };
                return result.ToList();
            };

        }
    }
}

