using Core.Configurations.CloudinaryConfiguration.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class SparePartPhotoForCreationDto:PhotoForCreationDto
    {
        public int SparePartId { get; set; }
    }
}
