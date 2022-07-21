using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Absract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            if (user.FirstName.Length>2 && user.LastName.Length>2 && user.Email.Contains("@") && user.Email.Contains("."))
            {
                _userDal.Add(user);
                return new SuccessResult(Messages.UserAdded); 
            }
            return new ErrorResult(Messages.UserInvalid);
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

        public IDataResult<User> GetByUserId(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u=>u.UserId == id));
        }

        public IResult Update(User user)
        {
            if (user.FirstName.Length > 2 && user.LastName.Length > 2 && user.Email.Contains("@|."))
            {
                _userDal.Add(user);
                return new SuccessResult(Messages.UserUpdated);
            }
            return new ErrorResult(Messages.UserInvalid);
        }
    }
}
