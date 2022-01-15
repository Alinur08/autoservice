using Business.Abstract;
using Business.BusinessAspect.AutoFac;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarSupplyManager : ICarSupplyService
    {
        private ICarSupplyDal _carSupplyDal;
        public CarSupplyManager(ICarSupplyDal carSupplyDal)
        {
            _carSupplyDal = carSupplyDal;
        }
        public Result AddSupplyToCar(CarSupply carSupply, int carId)
        {
            carSupply.CarId = carId;
            _carSupplyDal.Add(carSupply);
            return new SuccessResult();
        }

        public DataResult<List<CarSupply>> GetSuppliesByCar(int carId)
        {
            return new SuccessDataResult<List<CarSupply>>(_carSupplyDal.GetList(c => c.CarId == carId).ToList());
        }
        [SecuredOperation("Admin")]
        public Result RemoveSupplyToCar(CarSupply carSupply, int carId)
        {
            carSupply.CarId = carId;
            _carSupplyDal.Add(carSupply);
            return new SuccessResult();
        }
    }
}
