using AutoMapper;
using Core.Configurations.CloudinaryConfiguration.Entities.DTOs;
using Core1.Configurations.CloudinaryConfiguration.Entities.DTOs;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Mappers.AutoMapper
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<PhotoForCreationDto, CarPhoto>();
            CreateMap<CarForAddDto, Car>();
            CreateMap<VideoForCreationDto, CarVideo>();
            CreateMap<CarPhoto, CarPhotoForReturnDto>();
            CreateMap<CarVideo, CarVideoReturnDto>();
            CreateMap<Car, CarForListDto>()
                .ForMember(dest => dest.MainPhoto, opt =>
                {
                    opt.MapFrom(src => src.CarPhotos.FirstOrDefault(p => p.IsMain).Url);
                })
                .ForMember(dest=>dest.BrandName,opt=> {
                    opt.MapFrom(src => src.Brand.Name);
                });

        }
    }
}
