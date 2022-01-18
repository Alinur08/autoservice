using AutoMapper;
using Business.Abstract;
using Business.BusinessAspect.AutoFac;
using Core.Utilities.Results;
using Core1.Aspects.Autofac.Transaction;
using Core1.Configurations;
using Core1.Configurations.CloudinaryConfiguration.Entities.DTOs;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class SparePartVideoManager : ISparePartVideoService
    {
        private ISparePartVideoDal _sparePartVideoDal;
        private IMapper _mapper;
        private IFileService _fileService;
        public SparePartVideoManager(ISparePartVideoDal sparePartVideoDal, IMapper mapper, IFileService fileService)
        {
            _sparePartVideoDal = sparePartVideoDal;
            _fileService = fileService;
            _mapper = mapper;
        }
        [TransactionScopeAspect]
        [SecuredOperation("Admin")]
        public Result AddVideo(SparePartVideoCreationDto sparePartVideo)
        {
            VideoForCreationDto video = _fileService.AddVideoForEntity(sparePartVideo).Data;
            SparePartVideo sparePartVideoForDB = _mapper.Map<SparePartVideo>(video);
            _sparePartVideoDal.Add(sparePartVideoForDB);
            return new SuccessResult();
        }
        [SecuredOperation("Admin")]
        public Result DeleteVideo(int videoId)
        {
            _sparePartVideoDal.Delete(new SparePartVideo {Id=videoId });
            return new ErrorResult();
        }

        public DataResult<List<SparePartVideoReturnDto>> GetVideos()
        {
            var data = _mapper.Map<List<SparePartVideoReturnDto>>(_sparePartVideoDal.GetList());
            return new SuccessDataResult<List<SparePartVideoReturnDto>>(data);
        }
    }
}
