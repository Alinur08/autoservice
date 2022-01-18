using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IModelService
    {
        Result AddModel(Model model);
        Result DeleteModel(Model model);
        Result UpdateModel(Model model);
        DataResult<List<Model>> GetModelsByBrand(int brandId);
    }
}
