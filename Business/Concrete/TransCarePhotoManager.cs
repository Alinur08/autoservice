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
using System.Text;

namespace Business.Concrete
{
    public class TransCarePhotoManager : ITransCarePhotoService
    {
        private ITransCarePhotoDal _transCarePhotoDal;
        private IFileService _fileService;
        private IMapper _mapper;
        public TransCarePhotoManager(ITransCarePhotoDal transCarePhotoDal, IFileService fileService, IMapper mapper)
        {
            _transCarePhotoDal = transCarePhotoDal;
            _fileService = fileService;
            _mapper = mapper;
        }
        [SecuredOperation("Admin")]
        [TransactionScopeAspect()]
        public Result AddPhoto(TransCarePhotoCreationDto photo, int transCareId)
        {
            var createdPhoto = _fileService.AddPhotoForEntity(photo);
            var photoForDb = _mapper.Map<TransCarePhoto>(createdPhoto);
            _transCarePhotoDal.Add(photoForDb);
            return new SuccessResult();
        }

        public Result DeletePhoto(int photoId)
        {
            _transCarePhotoDal.Delete(new TransCarePhoto {Id=photoId });
            return new SuccessResult();
        }

        public DataResult<List<TransCarePhotoReturnDto>> GetPhotos(int transCareId)
        {
            var photos =_mapper.Map<List<TransCarePhotoReturnDto>>(_transCarePhotoDal.GetList(p => p.TransCareId == transCareId));
            return new SuccessDataResult<List<TransCarePhotoReturnDto>>(photos);
        }
    }
}
