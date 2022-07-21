using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Absract;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Core.DataAccess;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand,CarRentalContext>,IBrandDal
    { 
    }
}
