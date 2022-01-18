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
    public class EfSparePartDal:EfEntityRepositoryBase<SparePart,AutoServiceContext>,ISparePartDal
    {
        public new IList<SparePart> GetList(Expression<Func<SparePart, bool>> filter = null)
        {
            using (var context = new AutoServiceContext())
            {
                var data = context.SpareParts.Include(c => c.Model).Include(c=>c.Brand).Include(c=>c.SparePartPhotos);
                return filter == null ? data.ToList() : data.Where(filter).ToList();
            }
        }
    }
}
