using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class TransCare:IEntity
    {
        public TransCare()
        {
            TransCarePhotos = new List<TransCarePhoto>();
        }
        public int Id { get; set; }
        public string Detail { get; set; }
        public List<TransCarePhoto> TransCarePhotos { get; set; }
    }
}
