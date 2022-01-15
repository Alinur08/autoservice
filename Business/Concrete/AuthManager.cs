using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        public AuthManager(IUserService userService,ITokenHelper tokenHelper)
        {
            _tokenHelper = tokenHelper;
            _userService = userService;
        }
        public DataResult<AccessToken> CreateToken(User user)
        {
            var operationClaims = _userService.GetClaimsByUser(user).Data;
            var token = _tokenHelper.CreateToken(user, operationClaims);
            return new SuccessDataResult<AccessToken>(token);
        }

        public bool IsUserExist(string email)
        {
            var result =_userService.GetUserByEmail(email);
            if (result.Data != null)
            {
                return true;
            }
            return false;
        }

        public DataResult<User> Login(UserForLoginDto user)
        {
            if (!IsUserExist(user.Email))
            {
                return new ErrorDataResult<User>("Bele istifadeci yoxdu");
            }
            var userFromDb = _userService.GetUserByEmail(user.Email).Data;
            if (HashingHelper.Verify(user.Password, userFromDb.PasswordHash, userFromDb.PasswordSalt)) {
                return new SuccessDataResult<User>(userFromDb);
            };
            return new ErrorDataResult<User>();
        }

        public DataResult<User> Register(UserForRegisterDto user)
        {
            if (IsUserExist(user.Email))
            {
                return new ErrorDataResult<User>("Bele istifadeci onsuz var");
            }
            byte[] passwordSalt, passwordHash;
            HashingHelper.CreatePasswordHash(user.Password, out passwordHash, out passwordSalt);
            var userToAdd = new User { Email = user.Email, FirstName = user.FirstName, LastName = user.LastName, PasswordHash = passwordHash, PasswordSalt = passwordSalt, Status = true };
            _userService.AddUser(userToAdd);
            return new SuccessDataResult<User>(userToAdd);
        }
    }
}
