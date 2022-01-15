using Core.Configurations.CloudinaryConfiguration.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CarPhoto:Photo
    {
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
