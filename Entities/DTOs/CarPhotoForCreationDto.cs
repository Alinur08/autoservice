using Core.Configurations.CloudinaryConfiguration.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarPhotoForCreationDto:PhotoForCreationDto
    {
        public int CarId { get; set; }
    }
}
