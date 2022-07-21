using Core.DataAccess;
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
                var result = from r in context.Rentals
                             join ca in context.Cars
                             on r.CarId equals ca.CarId
                             join b in context.Brands
                             on ca.BrandId equals b.BrandId
                             join co in context.Colors
                             on ca.ColorId equals co.ColorId
                             join cu in context.Customers
                             on r.CustomerId equals cu.UserId
                             join u in context.Users
                             on r.CustomerId equals u.UserId
                             select new RentalDetailDto {
                                 RentalId = r.RentalId,BrandName =b.BrandName,ColorName=co.ColorName,CompanyName=cu.CompanyName,DailyPrice=ca.DailyPrice,
                                 Description=ca.Description,FirstName=u.FirstName,lastName=u.LastName,RentDate =r.RentDate,ReturnDate=r.RentDate};

                return result.ToList();



            }
        }
    }
}
