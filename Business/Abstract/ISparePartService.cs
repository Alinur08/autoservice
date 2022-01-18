using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ISparePartService
    {
        Result Add(SparePartCreationDto sparePart);
        Result Delete(SparePart sparePart);
        Result Update(SparePart sparePart);
        DataResult<List<SparePart>> GetSpareParts();
        DataResult<SparePart> GetSparePart(int sparePartId);
        DataResult<List<SparePart>> GetSparePartsByModel(int modelId);
        DataResult<List<SparePart>> GetSparePartsByBrand(int brandId);
        DataResult<List<SparePart>> GetSparePartsByYear(int year);
    }
}
