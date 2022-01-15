using Core1.Configurations.CloudinaryConfiguration.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarVideoReturnDto:VideoForReturnDto
    {
        public int CarId { get; set; }
    }
}
