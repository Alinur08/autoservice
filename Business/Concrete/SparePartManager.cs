using AutoMapper;
using Business.Abstract;
using Business.BusinessAspect.AutoFac;
using Core.Utilities.Results;
using Core1.Aspects.Autofac.Transaction;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
        private ISparePartPhotoService _sparePartPhotoService;
        private IMapper _mapper;
        public SparePartManager(IMapper mapper,ISparePartDal sparePartDal, ISparePartPhotoService sparePartPhotoService)
        {
            _sparePartDal = sparePartDal;
            _mapper = mapper;
            _sparePartPhotoService = sparePartPhotoService;
        }
        
        [TransactionScopeAspect()]
        public Result Add(SparePartCreationDto sparePart)
        {
            var sparePartForDb = new SparePart { BrandId= sparePart.BrandId,Detail=sparePart.Detail,ModelId=sparePart.ModelId,Year=sparePart.Year};
            _sparePartDal.Add(sparePartForDb);

            foreach (var photo in sparePart.Photos)
            {
                _sparePartPhotoService.AddPhoto(new SparePartPhotoForCreationDto {File=photo }, sparePartForDb.Id);
            }

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
