using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Configurations.CloudinaryConfiguration.Entities.Concrete
{
    public class CloudinarySettings:IEntity
    {
        public string CloudName { get; set; }
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }
    }
}
