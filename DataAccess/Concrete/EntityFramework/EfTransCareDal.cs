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
    public class EfTransCareDal:EfEntityRepositoryBase<TransCare,AutoServiceContext>,ITransCareDal
    {
        public new IList<TransCare> GetList(Expression<Func<TransCare, bool>> filter = null)
        {
            using (var context = new AutoServiceContext())
            {
                var data = context.TransCares.Include(c => c.TransCarePhotos);
                return filter == null ? data.ToList() : data.Where(filter).ToList();
            }
        }
    }
}
