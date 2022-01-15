using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Microsoft.AspNetCore.Http;
namespace Core.Configurations.CloudinaryConfiguration.Entities.DTOs
{
    public class PhotoForCreationDto
    {
        public PhotoForCreationDto()
        {
            DataAdded = DateTime.Now;
        }
        public string Url { get; set; }
        public IFormFile File { get; set; }
        public string Description { get; set; }
        public DateTime DataAdded { get; set; }
        public string PublicId { get; set; }
    }
}
