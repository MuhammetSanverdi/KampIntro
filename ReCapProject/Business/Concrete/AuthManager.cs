using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        ITokenHelper _tokenHelper;
        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accesstoken = _tokenHelper.CreateToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(accesstoken);       
        }

        public IDataResult<User> UserExists(string email)
        {
            var user = _userService.GetByEmail(email);
            if (user.Data==null)
            {
                return new ErrorDataResult<User>();
            }
            return new SuccessDataResult<User>(user.Data);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var user = UserExists(userForLoginDto.Email);
            if (!user.Success)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }             
           
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, user.Data.PasswordSalt, user.Data.PasswordHash ))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }
            return new SuccessDataResult<User>(user.Data);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            var userExits = UserExists(userForRegisterDto.Email);
            if (userExits.Success)
            {
                return new ErrorDataResult<User>(Messages.UserExits);
            }            
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password,out passwordSalt,out passwordHash);
            User user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }
    }
}
