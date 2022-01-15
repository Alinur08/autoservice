using Business.Abstract;
using Business.BusinessAspect.AutoFac;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        [SecuredOperation("Admin")]
        public Result AddBrand(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult();
        }
        [SecuredOperation("Admin")]
        public Result DeleteBrand(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult();
        }

        public DataResult<List<Brand>> GetBrands()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetList().ToList());
        }
        [SecuredOperation("Admin")]
        public Result UpdateBrand(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult();
        }
    }
}
