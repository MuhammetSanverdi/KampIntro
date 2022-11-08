﻿using Core.DataAccess;
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
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, CarRentalContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (CarRentalContext context = new CarRentalContext()) 
            {
                var result = from c in context.Customers
                             join u in context.Users
                             on c.UserId equals u.Id
                             select new CustomerDetailDto 
                             {
                                 CompanyName=c.CompanyName,
                                 Email=u.Email,
                                 FirstName=u.FirstName,
                                 LastName=u.LastName,
                             };
                return result.ToList();
                             
            }
        }
    }
}
