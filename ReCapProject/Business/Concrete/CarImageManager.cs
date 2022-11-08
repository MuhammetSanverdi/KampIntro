using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Absract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;
        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfCarImageLimit(carImage.CarId));

            if (result != null)
            {
                return result;
            }
            carImage.Date = DateTime.Now;

            carImage.ImagePath = _fileHelper.Upload(file, PathConstans.ImagesPath);
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete( CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            _fileHelper.Delete(carImage.ImagePath, PathConstans.ImagesPath);
            return new SuccessResult();
        }
        public IResult Update(IFormFile file, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfCarImageLimit(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            var temporaryCarImage = _carImageDal.Get(c => c.Id == carImage.Id);
            carImage.Date = DateTime.Now;
            carImage.ImagePath = _fileHelper.Update(file, temporaryCarImage.ImagePath, PathConstans.ImagesPath);

            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetCarImagesByCarId(int id)
        {            
            var rules = CheckIfCarImage(id);
            if (!rules.Success)
            {
                var carImage = new List<CarImage> { new CarImage {CarId=id , Date=DateTime.Now , ImagePath=PathConstans.DefaultImageName } };
                return new ErrorDataResult<List<CarImage>>(carImage,Messages.CarImageNotFound);
            }
            
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == id));
        }

        public IDataResult<CarImage> GetDefaultCarImageByCarId(int carId)
        {
            var carImages = GetCarImagesByCarId(carId);
            var carImage = carImages.Data.FirstOrDefault();
            return new SuccessDataResult<CarImage>(carImage);
        }

        public IDataResult<CarImage> GetByCarImageId(int id)
        {
                        
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == id));
        }
        

        private IResult CheckIfCarImageLimit(int carId)
        {
            var cars = _carImageDal.GetAll(c => c.CarId == carId);
            if (cars.Count > 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        private IResult CheckIfCarImage(int carId)
        {
            var cars = _carImageDal.GetAll(c => c.CarId == carId);
            if (cars.Count > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
        
        

    }

}
