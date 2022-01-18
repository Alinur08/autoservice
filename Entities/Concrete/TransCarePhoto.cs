using Core.Configurations.CloudinaryConfiguration.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class TransCarePhoto:Photo
    {
        public int TransCareId { get; set; }
        public TransCare TransCare { get; set; }
    }
}
