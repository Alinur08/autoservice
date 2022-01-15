using Core1.Configurations.CloudinaryConfiguration.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarVideoCreationDto:VideoForCreationDto
    {
        public int CarId { get; set; }
    }
}
