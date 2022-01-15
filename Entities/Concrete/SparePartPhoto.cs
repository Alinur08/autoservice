using Core.Configurations.CloudinaryConfiguration.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class SparePartPhoto:Photo
    {
        public int SparePartId { get; set; }
        public SparePart SparePart { get; set; }
    }
}
