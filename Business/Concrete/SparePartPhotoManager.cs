using AutoMapper;
using Business.Abstract;
using Business.BusinessAspect.AutoFac;
using Core.Utilities.Results;
using Core1.Aspects.Autofac.Transaction;
using Core1.Configurations;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class SparePartPhotoManager : ISparePartPhotoService
    {
        private ISparePartPhotoDal _sparePartPhotoDal;
        private IMapper _mapper;
        private IFileService _fileService;
        public SparePartPhotoManager(ISparePartPhotoDal sparePartPhotoDal, IMapper mapper, IFileService fileService)
        {
            _sparePartPhotoDal = sparePartPhotoDal;
            _fileService = fileService;
            _mapper = mapper;
        }
        [TransactionScopeAspect]
        [SecuredOperation("Admin")]
        public Result AddPhoto(SparePartPhotoForCreationDto photo, int sparePartId)
        {
            var result = _fileService.AddPhotoForEntity(photo);

            SparePartPhoto sparePartPhotoForDatabase = _mapper.Map<SparePartPhoto>(result.Data);
            sparePartPhotoForDatabase.SparePartId = sparePartId;
            _sparePartPhotoDal.Add(sparePartPhotoForDatabase);
            return new SuccessResult();
        }
        [SecuredOperation("Admin")]
        public Result Delete(int sparePartPhotoId)
        {
            _sparePartPhotoDal.Delete(new SparePartPhoto { Id=sparePartPhotoId});
            return new SuccessResult();
        }

        public DataResult<List<SparePartPhoto>> GetSparePartPhotos(int sparePartId)
        {
            return new SuccessDataResult<List<SparePartPhoto>>(_sparePartPhotoDal.GetList(p=>p.SparePartId==sparePartId).ToList());
        }
    }
}
