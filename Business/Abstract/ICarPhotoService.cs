using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarPhotoService
    {
        Result AddPhoto(CarPhotoForCreationDto carPhoto, int carId);
        Result AddMainPhoto(CarPhotoForCreationDto carPhoto, int carId);
        Result DeletePhoto(CarPhoto carPhoto);
        DataResult<List<CarPhotoForReturnDto>> GetPhotos(int carId); 
    }
}
