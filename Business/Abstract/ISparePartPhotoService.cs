using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ISparePartPhotoService
    {
        Result AddPhoto(SparePartPhotoForCreationDto photo,int sparePartId);
        Result Delete(int sparePartPhotoId);
        DataResult<List<SparePartPhoto>> GetSparePartPhotos(int sparePartId);
    }
}
