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
    public class EfBrandDal:EfEntityRepositoryBase<Brand,AutoServiceContext>,IBrandDal
    {
        public new IList<Brand> GetList(Expression<Func<Brand, bool>> filter = null)
        {
            using (var context = new AutoServiceContext())
            {
                var data = context.Brands.Include(c => c.Cars);
                return filter == null ? data.ToList() : data.Where(filter).ToList();
            }
        }
    }
}
