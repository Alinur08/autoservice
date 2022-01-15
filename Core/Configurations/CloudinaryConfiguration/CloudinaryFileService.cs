using System;
using System.Collections.Generic;
using System.Text;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Core.Configurations.CloudinaryConfiguration.Entities.Concrete;
using Core.Configurations.CloudinaryConfiguration.Entities.DTOs;
using Core.Entities;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core1.Configurations;
using Core1.Configurations.CloudinaryConfiguration.Entities.DTOs;
using Microsoft.Extensions.Options;

namespace Core1.Business.CloudinaryConfiguration
{
    public class CloudinaryFileService:IFileService
    {
        private IOptions<CloudinarySettings> _options;
        private Cloudinary _cloudinary;
        private Account account;
        public CloudinaryFileService(IOptions<CloudinarySettings> options)
        {
            _options = options;
            account = new Account(_options.Value.CloudName, _options.Value.ApiKey, _options.Value.ApiSecret);
            _cloudinary = new Cloudinary(account);
        }
        public DataResult<PhotoForCreationDto> AddPhotoForEntity(PhotoForCreationDto photoForCreation)
        {
         
            var file = photoForCreation.File;
            var imageUploadResult = new ImageUploadResult();
            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParam = new ImageUploadParams { File = new FileDescription(file.Name, stream) };
                    imageUploadResult = _cloudinary.Upload(uploadParam);
             
                }

            }
            photoForCreation.Url = imageUploadResult.Url.ToString();
            photoForCreation.PublicId = imageUploadResult.PublicId;
           
            return new SuccessDataResult<PhotoForCreationDto>(photoForCreation);
        }

        public DataResult<VideoForCreationDto> AddVideoForEntity(VideoForCreationDto videoForCreation)
        {
            var file = videoForCreation.File;
            var videoUploadResult = new VideoUploadResult();
            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParam = new VideoUploadParams { File = new FileDescription(file.Name, stream) };
                    videoUploadResult = _cloudinary.Upload(uploadParam);

                }

            }
            videoForCreation.Url = videoUploadResult.Url.ToString();
            videoForCreation.PublicId = videoUploadResult.PublicId;

            return new SuccessDataResult<VideoForCreationDto>(videoForCreation);
        }
    }
}
