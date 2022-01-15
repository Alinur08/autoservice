using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarSupplyDal:EfEntityRepositoryBase<CarSupply,AutoServiceContext>,ICarSupplyDal
    {
        public new IList<CarSupply> GetList(Expression<Func<CarSupply,bool>> filter=null)
        {
            using (var context = new AutoServiceContext())
            {
                var data = context.CarSupplies.Include(c => c.Car).Include(c => c.Supply);
                return filter == null ? data.ToList() : data.Where(filter).ToList();
            }
        }
    }
}
