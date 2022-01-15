using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        Result AddBrand(Brand brand);
        Result DeleteBrand(Brand brand);
        Result UpdateBrand(Brand brand);
        DataResult<List<Brand>> GetBrands();
    }
}
