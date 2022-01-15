using Core.Configurations.CloudinaryConfiguration.Entities.DTOs;
using Core.Utilities.Results;
using Core1.Configurations.CloudinaryConfiguration.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core1.Configurations
{
    public interface IFileService
    {
        DataResult<PhotoForCreationDto> AddPhotoForEntity(PhotoForCreationDto photoForCreation);
        DataResult<VideoForCreationDto> AddVideoForEntity(VideoForCreationDto videoForCreation);
    }
}
