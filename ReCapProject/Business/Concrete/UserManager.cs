using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Absract;
using Core.Entities.Concrete;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
                _userDal.Add(user);
                return new SuccessResult(Messages.UserAdded);            
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(),Messages.UsersListed);
        }

        public IDataResult<User> GetByEmail(string email)
        {
            var result = _userDal.Get(u=>u.Email==email);
            if (result==null)
            {
                return new ErrorDataResult<User>(result);
            }
            return new SuccessDataResult<User>(result);
        }

        public IDataResult<User> GetByUserId(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u=>u.Id == id));
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var result = _userDal.GetClaims(user);
            if (result==null)
            {
                return new ErrorDataResult<List<OperationClaim>>();
            }
            return new SuccessDataResult<List<OperationClaim>>(result);
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User user)
        {
                _userDal.Add(user);
                return new SuccessResult(Messages.UserUpdated);
           
        }
    }
}
