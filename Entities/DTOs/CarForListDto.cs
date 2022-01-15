using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarForListDto:IDto
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string GraduationDate { get; set; }
        public string BrandName { get; set; }
        public string MainPhoto { get; set; }
    }
}
