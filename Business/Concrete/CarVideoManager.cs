using AutoMapper;
using Business.Abstract;
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
    public class CarVideoManager : ICarVideoService
    {
        private ICarVideoDal _carVideoDal;
        private IMapper _mapper;
        private IFileService _fileService;
        public CarVideoManager(ICarVideoDal carVideoDal, IMapper mapper, IFileService fileService)
        {
            _carVideoDal = carVideoDal;
            _fileService = fileService;
            _mapper = mapper;
        }
        [TransactionScopeAspect]
        public Result AddVideo(CarVideoCreationDto carVideo, int carId)
        {
            VideoForCreationDto video = _fileService.AddVideoForEntity(carVideo).Data;
            CarVideo carVideoForDB = _mapper.Map<CarVideo>(video);
            carVideoForDB.CarId = carId;
            _carVideoDal.Add(carVideoForDB);
            return new SuccessResult();
        }

        public Result DeleteVideo(int videoId)
        {
            _carVideoDal.Delete(new CarVideo {Id=videoId });
            return new ErrorResult();
        }

        public DataResult<List<CarVideoReturnDto>> GetVideos(int carId)
        {
            var data = _mapper.Map<List<CarVideoReturnDto>>(_carVideoDal.GetList(v => v.CarId == carId));
            return new SuccessDataResult<List<CarVideoReturnDto>>(data);
        }
    }
}
