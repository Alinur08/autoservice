using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ITransCareService
    {
        Result Add(TransCareForAddDto transCare);
        Result Delete(TransCare transCare);
        Result Update(TransCare transCare);
        DataResult<List<TransCare>> GetTransCares();
        DataResult<TransCare> GetTransCare(int transCareId);
    }
}
