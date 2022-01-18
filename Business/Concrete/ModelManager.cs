using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ModelManager : IModelService
    {
        private IModelDal _modelDal;
        public ModelManager(IModelDal modelDal)
        {
            _modelDal = modelDal;
        }
        public Result AddModel(Model model)
        {
            _modelDal.Add(model);
            return new SuccessResult();
        }

        public Result DeleteModel(Model model)
        {
            _modelDal.Delete(model);
            return new SuccessResult();
        }

        public DataResult<List<Model>> GetModelsByBrand(int brandId)
        {
            return new SuccessDataResult<List<Model>>(_modelDal.GetList(m=>m.BrandId==brandId).ToList());
        }

        public Result UpdateModel(Model model)
        {
            _modelDal.Update(model);
            return new SuccessResult();
        }
    }
}
