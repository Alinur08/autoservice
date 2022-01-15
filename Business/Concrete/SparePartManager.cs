using Business.Abstract;
using Business.BusinessAspect.AutoFac;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class SparePartManager : ISparePartService
    {
        private ISparePartDal _sparePartDal;
        public SparePartManager(ISparePartDal sparePartDal)
        {
            _sparePartDal = sparePartDal;
        }
        [SecuredOperation("Admin")]
        public Result Add(SparePart sparePart)
        {
            _sparePartDal.Add(sparePart);
            return new SuccessResult();
        }
        [SecuredOperation("Admin")]
        public Result Delete(SparePart sparePart)
        {
            _sparePartDal.Delete(sparePart);
            return new SuccessResult();
        }

        public DataResult<List<SparePart>> GetSpareParts()
        {
            return new SuccessDataResult<List<SparePart>>(_sparePartDal.GetList().ToList());
        }

        public DataResult<List<SparePart>> GetSparePartsByModel(int modelId)
        {
            return new SuccessDataResult<List<SparePart>>(_sparePartDal.GetList(s => s.ModelId == modelId).ToList());
        }

        public DataResult<List<SparePart>> GetSparePartsByBrand(int brandId)
        {
            return new SuccessDataResult<List<SparePart>>(_sparePartDal.GetList(s => s.BrandId == brandId).ToList());
        }
        [SecuredOperation("Admin")]
        public Result Update(SparePart sparePart)
        {
            _sparePartDal.Update(sparePart);
            return new SuccessResult();
        }

        public DataResult<SparePart> GetSparePart(int sparePartId)
        {
            return new SuccessDataResult<SparePart>(_sparePartDal.Get(s => s.Id == sparePartId));
        }

        public DataResult<List<SparePart>> GetSparePartsByYear(int year)
        {
            return new SuccessDataResult<List<SparePart>>(_sparePartDal.GetList(s => s.Year == year).ToList());
        }
    }
}
