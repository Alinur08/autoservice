using Core.Entities;
using Core1.Configurations.CloudinaryConfiguration.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CarVideo:Video
    {
        public int CarId { get; set; }
        public Car Car { get; set; }

    }
}
