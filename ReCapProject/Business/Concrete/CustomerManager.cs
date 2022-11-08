using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            
            if (customer.CompanyName.Length>2)
            {
                _customerDal.Add(customer);
                return new SuccessResult(Messages.CustomerAdded);
            }
            return new ErrorResult();
            
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(),Messages.CustomersListed);
        }

        public IDataResult<Customer> GetByCustomerId(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c=>c.Id == id));
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
        {
            var result = _customerDal.GetCustomerDetails();
            return new SuccessDataResult<List<CustomerDetailDto>>(result);
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }
    }
}
