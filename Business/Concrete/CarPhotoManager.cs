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
    public class CarPhotoManager : ICarPhotoService
    {
        private ICarPhotoDal _carPhotoDal;
        private IFileService _fileService;
        private IMapper _mapper;
        public CarPhotoManager(IMapper mapper,IFileService fileService,ICarPhotoDal carPhotoDal)
        {
            _carPhotoDal = carPhotoDal;
            _fileService = fileService;
            _mapper = mapper;
        }
        [TransactionScopeAspect]
        [SecuredOperation("Admin")]
        public Result AddPhoto(CarPhotoForCreationDto carPhoto,int carId)
        {
            var result = _fileService.AddPhotoForEntity(carPhoto);
            
            CarPhoto carPhotoForDatabase = _mapper.Map<CarPhoto>(result.Data);
            carPhotoForDatabase.CarId = carId;
            _carPhotoDal.Add(carPhotoForDatabase);
            return new SuccessResult();
        }
        [SecuredOperation("Admin")]
        public Result AddMainPhoto(CarPhotoForCreationDto carPhoto, int carId)
        {
            var result = _fileService.AddPhotoForEntity(carPhoto);

            CarPhoto carPhotoForDatabase = _mapper.Map<CarPhoto>(result.Data);
            carPhotoForDatabase.CarId = carId;
            carPhotoForDatabase.IsMain = true;
            _carPhotoDal.Add(carPhotoForDatabase);
            return new SuccessResult();
        }
        [SecuredOperation("Admin")]
        public Result DeletePhoto(CarPhoto carPhoto)
        {
            _carPhotoDal.Delete(carPhoto);
            return new SuccessResult();
        }
        [SecuredOperation("Admin")]
        public Result UpdatePhoto(CarPhoto carPhoto)
        {
            _carPhotoDal.Update(carPhoto);
            return new SuccessResult();
        }

        public DataResult<List<CarPhotoForReturnDto>> GetPhotos(int carId)
        {
            var data=_carPhotoDal.GetList(p => p.CarId == carId);
            var carPhotos = _mapper.Map<List<CarPhotoForReturnDto>>(data);
            return new SuccessDataResult<List<CarPhotoForReturnDto>>(carPhotos);
        }
        public DataResult<CarPhotoForReturnDto> GetPhoto(int photoId)
        {
            var data = _carPhotoDal.Get(p=>p.Id==photoId);
            var carPhoto = _mapper.Map<CarPhotoForReturnDto>(data);
            return new SuccessDataResult<CarPhotoForReturnDto>(carPhoto);
        }
    }
}
