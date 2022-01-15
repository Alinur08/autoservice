using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAuthService
    {
        DataResult<AccessToken> CreateToken(User user);
        DataResult<User> Login(UserForLoginDto user);
        DataResult<User> Register(UserForRegisterDto user);
        bool IsUserExist(string email);
    }
}
