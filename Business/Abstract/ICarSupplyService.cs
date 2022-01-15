using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarSupplyService
    {
        Result AddSupplyToCar(CarSupply carSupply,int carId);
        Result RemoveSupplyToCar(CarSupply carSupply,int carId);
        DataResult<List<CarSupply>> GetSuppliesByCar(int carId);
    }
}
