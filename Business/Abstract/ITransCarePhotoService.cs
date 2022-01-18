using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ITransCarePhotoService
    {
        Result AddPhoto(TransCarePhotoCreationDto photo,int transCareId);
        Result DeletePhoto(int photoId);
        DataResult<List<TransCarePhotoReturnDto>> GetPhotos(int transCareId);
    }
}
