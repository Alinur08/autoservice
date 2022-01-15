using Core.Configurations.CloudinaryConfiguration.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarPhotoForReturnDto:PhotoForReturnDto
    {
        public int CarId { get; set; }
    }
}
