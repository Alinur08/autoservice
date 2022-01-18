using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class TransCareForAddDto:IDto
    {
        public TransCareForAddDto()
        {
            TransCarePhotos = new List<IFormFile>();
        }
        public int Id { get; set; }
        public string Detail { get; set; }
        public List<IFormFile> TransCarePhotos { get; set; }
    }
}
