using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarVideoService
    {
        Result AddVideo(CarVideoCreationDto carVideo, int carId);
        Result DeleteVideo(int videoId);
        DataResult<List<CarVideoReturnDto>> GetVideos(int carId);
    }
}
