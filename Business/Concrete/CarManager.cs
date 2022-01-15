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
    public class CarManager : ICarService
    {
        private ICarDal _carDal;
        private ICarPhotoService _carPhotoService;
        private IMapper _mapper;
        private ICarSupplyService _carSupplyService;
        
        public CarManager(ICarSupplyService carSupplyService,IMapper mapper,ICarDal carDal,ICarPhotoService carPhotoService)
        {
            _carDal = carDal;
            _carSupplyService = carSupplyService;
            _carPhotoService = carPhotoService;
            _mapper = mapper;
        }
        [TransactionScopeAspect]
        [SecuredOperation("Admin")]
        public Result Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult();
        }
        [TransactionScopeAspect]
        public Result AddCarDto(CarForAddDto car)
        {
            Car carForDB = _mapper.Map<Car>(car);
            _carDal.Add(carForDB);
            foreach (var carPhoto in car.Photos)
            {
                _carPhotoService.AddPhoto(new CarPhotoForCreationDto {File=carPhoto }, carForDB.Id);
            }
            _carPhotoService.AddMainPhoto(new CarPhotoForCreationDto { File=car.MainPhoto},carForDB.Id);
            foreach (var carSupply in car.CarSupplies)
            {
                _carSupplyService.AddSupplyToCar(carSupply, car.Id);
            }
            return new SuccessResult();
        }
        [SecuredOperation("Admin")]
        public Result Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }

        public DataResult<Car> GetCarById(int carId)
        {
             return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == carId));
        }

        public DataResult<List<CarForListDto>> GetCars()
        {
            //var cars = _mapper.Map<List<CarForListDto>>(_carDal.GetList().ToList());
            //return new SuccessDataResult<List<CarForListDto>>(cars);
            return new SuccessDataResult<List<CarForListDto>>("Sccess",new List<CarForListDto>());
        }

        public DataResult<List<CarForListDto>> GetCarsByBrand(int brandId)
        {
            var cars = _mapper.Map<List<CarForListDto>>(_carDal.GetList(c => c.BrandId == brandId).ToList());
            return new SuccessDataResult<List<CarForListDto>>(cars);
        }

        public DataResult<List<CarForListDto>> GetCarsMain()
        {
            var cars = _mapper.Map<List<CarForListDto>>(_carDal.GetList(c => c.IsVisible).ToList());
            return new SuccessDataResult<List<CarForListDto>>(cars);
        }
        [SecuredOperation("Admin")]
        public Result MakeCarVisible(Car car)
        {
            car.IsVisible = true;
            _carDal.Update(car);
            return new SuccessResult();
        }
        [SecuredOperation("Admin")]
        public Result MakeCarInVisible(Car car)
        {
            car.IsVisible = false;
            _carDal.Update(car);
            return new SuccessResult();
        }

        [SecuredOperation("Admin")]
        public Result Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();
        }
    }
}
