using Business.Abstract;
using Business.BusinessAspect.AutoFac;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        [SecuredOperation("Admin")]
        public Result AddUser(User user)
        {
            _userDal.Add(user);
            return new SuccessResult();
        }

        public DataResult<List<OperationClaim>> GetClaimsByUser(User user)
        {
             return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public DataResult<User> GetUserByEmail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u=>u.Email==email));
        }
    }
}
