using Business.Abstract;
using Business.Constants;
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
    public class RentalManager:IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            rental.RentDate = DateTime.Now;
            var result = _rentalDal.Get(r => r.CarId == rental.CarId);
            if (result == null || result.ReturnDate == null || result.ReturnDate<DateTime.Now)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }
            return new ErrorResult(Messages.RentalInvalid);

        }
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
        }

        public IDataResult<Rental> GetByRentalId(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r=>r.Id == id));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            var result = _rentalDal.GetRentalDetails();
            return new SuccessDataResult<List<RentalDetailDto>>(result);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetailsByCarId(int carId)
        {
            var result = _rentalDal.GetRentalDetailsByCarId(carId);
            return new SuccessDataResult<List<RentalDetailDto>>(result);
        }

       
    }
}
