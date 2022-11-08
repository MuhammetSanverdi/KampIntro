using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Absract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarsByBrandId(int id);
        List<CarDetailDto> GetCarsByColorId (int id);
        List<CarDetailDto> GetAllCarDetails();
        CarDetailDto GetCarDetailByCarId(int id);
        List<CarDetailDto> GetCarDetailsByBrandIdAndColorId(int brandId,int colorId);
    }
}
