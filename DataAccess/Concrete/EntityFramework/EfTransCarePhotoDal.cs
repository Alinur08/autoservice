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
    public class EfTransCarePhotoDal:EfEntityRepositoryBase<TransCarePhoto,AutoServiceContext>,ITransCarePhotoDal
    {
        public new IList<TransCarePhoto> GetList(Expression<Func<TransCarePhoto, bool>> filter = null)
        {
            using (var context = new AutoServiceContext())
            {
                var data = context.TransCarePhotos.Include(c => c.TransCare);
                return filter == null ? data.ToList() : data.Where(filter).ToList();
            }
        }
    }
}
