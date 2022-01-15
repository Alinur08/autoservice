using Core.Entities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Car:IEntity
    {
        public Car()
        {
            CarPhotos = new List<CarPhoto>();
        }
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public int BrandId { get; set; }
        public string Model { get; set; }
        public string GraduationDate { get; set; }
        public string BanName { get; set; }
        public string ColorName { get; set; }
        public string Motor { get; set; }
        public string MotorPower { get; set; }
        public string FuelType { get; set; }
        public string GearBox { get; set; }
        public string Transmitter { get; set; }
        public bool IsNew { get; set; }
        public string Price { get; set; }
        public string Detail { get; set; }
        public bool IsVisible { get; set; }
        public Brand Brand { get; set; }
        public List<CarPhoto> CarPhotos { get; set; }
        public List<CarSupply> CarSupplies { get; set; }
    }
}
