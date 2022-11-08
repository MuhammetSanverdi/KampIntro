using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetByCarId(int id);
        IDataResult<CarDetailDto> GetCarDetailByCarId(int id);
        IDataResult<List<CarDetailDto>> GetAllCarDetails();
        IDataResult<List<CarDetailDto>> GetByBrandId(int id);
        IDataResult<List<CarDetailDto>> GetByColorId(int id);
        IDataResult<List<CarDetailDto>> GetCarDetailsByBrandIdAndColorId(int brandId,int colorId);
    }
}
