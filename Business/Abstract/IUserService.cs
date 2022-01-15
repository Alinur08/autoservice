using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        DataResult<User> GetUserByEmail(string email);
        Result AddUser(User user);
        DataResult<List<OperationClaim>> GetClaimsByUser(User user);
    }
}
