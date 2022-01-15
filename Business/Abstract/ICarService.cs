using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        DataResult<List<CarForListDto>> GetCars();
        DataResult<List<CarForListDto>> GetCarsMain();
        DataResult<List<CarForListDto>> GetCarsByBrand(int brandId);
        DataResult<Car> GetCarById(int carId);
        


        Result Add(Car car);
        Result AddCarDto(CarForAddDto car);
        Result Delete(Car car);
        Result Update(Car car);
        Result MakeCarVisible(Car car);
        Result MakeCarInVisible(Car car);
    }
}
