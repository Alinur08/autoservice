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
    public class EfCarPhotoDal:EfEntityRepositoryBase<CarPhoto,AutoServiceContext>,ICarPhotoDal
    {
        public new IList<CarPhoto> GetList(Expression<Func<CarPhoto,bool>> filter=null)
        {
            using (var context = new AutoServiceContext())
            {
                var data = context.CarPhotos.Include(c => c.Car);
                return filter == null ? data.ToList() : data.Where(filter).ToList();
            }
        }
    }
}
