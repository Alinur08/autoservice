using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core1.Configurations.CloudinaryConfiguration.Entities.DTOs
{
    public class VideoForCreationDto:IDto
    {
        public VideoForCreationDto()
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
