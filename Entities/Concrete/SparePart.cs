using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class SparePart:IEntity
    {
        public SparePart()
        {
            SparePartPhotos = new List<SparePartPhoto>();
        }
        public int Id { get; set; }
        public int Year { get; set; }
        public int ModelId { get; set; }
        public int BrandId { get; set; }
        public Model Model { get; set; }
        public Brand Brand { get; set; }
        public string Detail { get; set; }
        public List<SparePartPhoto> SparePartPhotos { get; set; }
        
    }
}
