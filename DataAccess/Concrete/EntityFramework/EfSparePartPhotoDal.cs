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
    public class EfSparePartPhotoDal:EfEntityRepositoryBase<SparePartPhoto,AutoServiceContext>,ISparePartPhotoDal
    {
        public new IList<SparePartPhoto> GetList(Expression<Func<SparePartPhoto, bool>> filter = null)
        {
            using (var context = new AutoServiceContext())
            {
                var data = context.SparePartPhotos.Include(c => c.SparePart);
                return filter == null ? data.ToList() : data.Where(filter).ToList();
            }
        }
    }
}
