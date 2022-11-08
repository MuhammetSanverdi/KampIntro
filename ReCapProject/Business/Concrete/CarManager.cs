using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Absract;
using Entities.Concrete;
using Entities.DTOs;
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
        ICarImageService _carImageService;
        public CarManager(ICarDal carDal, ICarImageService carImageService)
        {
            _carDal = carDal;
            _carImageService = carImageService;
        }

        [SecuredOperation("admin,cars.add")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);

        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<List<CarDetailDto>> GetByBrandId(int id)
        {
            var result = _carDal.GetCarsByBrandId(id);
            return new SuccessDataResult<List<CarDetailDto>>(result);
        }
        public IDataResult<List<CarDetailDto>> GetByColorId(int id)
        {
            var result = _carDal.GetCarsByColorId(id);
            return new SuccessDataResult<List<CarDetailDto>>(result);
        }

        public IDataResult<Car> GetByCarId(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));
        }

        public IDataResult<List<CarDetailDto>> GetAllCarDetails()
        {
            var carDetails = _carDal.GetAllCarDetails();
            var result = CheckEmptyImagePath(carDetails);
            return new SuccessDataResult<List<CarDetailDto>>(result, Messages.CarDetailsListed);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IDataResult<CarDetailDto> GetCarDetailByCarId(int id)
        {
            var carDetail = _carDal.GetCarDetailByCarId(id);
            var result = CheckEmptyImagePath(carDetail);
            return new SuccessDataResult<CarDetailDto>(result);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandIdAndColorId(int brandId, int colorId)
        {
            List<CarDetailDto> carDetail;

            if (brandId>0)
            {
                if (colorId>0)
                {
                     carDetail= _carDal.GetCarDetailsByBrandIdAndColorId(brandId, colorId);
                }
                else
                {
                    carDetail = _carDal.GetCarsByBrandId(brandId);
                }
            }
            else if (colorId > 0)
            {
                carDetail = _carDal.GetCarsByColorId(colorId);                
            }
            else
            {
                carDetail = _carDal.GetAllCarDetails();
            }
            
            var result = CheckEmptyImagePath(carDetail);
            return new SuccessDataResult<List<CarDetailDto>> (result);
        }

        private List<CarDetailDto> CheckEmptyImagePath(List<CarDetailDto> carDetails)
        {
            foreach (var car in carDetails)
            {
                if (car.ImagePath is null)
                {
                    car.ImagePath = new List<string> { PathConstans.DefaultImageName };
                }
            }
            return carDetails;
        }
        private CarDetailDto CheckEmptyImagePath(CarDetailDto carDetail)
        {
            if (carDetail.ImagePath is null)
            {
                carDetail.ImagePath = new List<string> { PathConstans.DefaultImageName};
            }
            return carDetail;
        }

        
    }
}
