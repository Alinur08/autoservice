using AutoMapper;
using Business.Abstract;
using Business.BusinessAspect.AutoFac;
using Core.Utilities.Results;
using Core1.Aspects.Autofac.Transaction;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class TransCareManager : ITransCareService
    {
        private ITransCareDal _transCareDal;
        private IMapper _mapper;
        private ITransCarePhotoService _transCarePhotoService;
        public TransCareManager(ITransCareDal transCareDal, IMapper mapper, ITransCarePhotoService transCarePhotoService)
        {
            _transCareDal = transCareDal;
            _mapper = mapper;
        }
        [SecuredOperation("Admin")]
        [TransactionScopeAspect]
        public Result Add(TransCareForAddDto transCare)
        {
            var transCareDb = _mapper.Map<TransCare>(transCare);
            _transCareDal.Add(transCareDb);
            foreach (var photo in transCare.TransCarePhotos)
            {
                _transCarePhotoService.AddPhoto(new TransCarePhotoCreationDto {File=photo }, transCareDb.Id);
            }
            return new SuccessResult();
        }
        [SecuredOperation("Admin")]
        public Result Delete(TransCare transCare)
        {
            _transCareDal.Delete(transCare);
            return new SuccessResult();
        }

        public DataResult<TransCare> GetTransCare(int transCareId)
        {
            return new SuccessDataResult<TransCare>(_transCareDal.Get(t=>t.Id==transCareId));
        }

        public DataResult<List<TransCare>> GetTransCares()
        {
            return new SuccessDataResult<List<TransCare>>(_transCareDal.GetList().ToList());
        }
        [SecuredOperation("Admin")]
        public Result Update(TransCare transCare)
        {
            _transCareDal.Update(transCare);
            return new SuccessResult();
        }
    }
}
