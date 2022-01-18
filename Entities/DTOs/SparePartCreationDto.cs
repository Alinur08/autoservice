using Core.Entities;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class SparePartCreationDto:IDto
    {
        public SparePartCreationDto()
        {
            Photos = new List<IFormFile>();
        }
        public int Id { get; set; }
        public int Year { get; set; }
        public int ModelId { get; set; }
        public int BrandId { get; set; }
        public string Detail { get; set; }
        public List<IFormFile> Photos { get; set; }
    }
}
