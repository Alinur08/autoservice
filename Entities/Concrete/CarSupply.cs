using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CarSupply:IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int SupplyId { get; set; }
        public Car Car { get; set; }
        public Supply Supply { get; set; }
    }
}
