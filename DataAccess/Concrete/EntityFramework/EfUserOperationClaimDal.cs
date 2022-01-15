using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Context;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserOperationClaimDal:EfEntityRepositoryBase<UserOperationClaim,AutoServiceContext>,IUserOperationClaimDal
    {
    }
}
