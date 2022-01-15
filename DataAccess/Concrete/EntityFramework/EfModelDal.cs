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
    public class EfModelDal:EfEntityRepositoryBase<Model, AutoServiceContext>,IModelDal
    {
        public new IList<Model> GetList(Expression<Func<Model, bool>> filter = null)
        {
            using (var context = new AutoServiceContext())
            {
                var data = context.Models.Include(c => c.Brand);
                return filter == null ? data.ToList() : data.Where(filter).ToList();
            }
        }
    }
}
