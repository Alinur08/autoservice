using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal:EfEntityRepositoryBase<Car, AutoServiceContext>,ICarDal
    {
        public new IList<Car> GetList(Expression<Func<Car, bool>> filter = null)
        {
            using (var context = new AutoServiceContext())
            {
                var data = context.Cars.Include(c => c.Brand).Include(c=>c.CarPhotos).Include(c=>c.CarSupplies);
                return filter == null ? data.ToList() : data.Where(filter).ToList();
            }
        }
    }
}
