using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPhotosController : ControllerBase
    {
        private ICarPhotoService _carPhotoService;
        public CarPhotosController(ICarPhotoService carPhotoService)
        {
            _carPhotoService = carPhotoService;
        }

        [HttpPost("/addmainphoto")]
        public IActionResult AddMainPhoto([FromForm]CarPhotoForCreationDto carPhoto,int carId)
        {
            var result = _carPhotoService.AddMainPhoto(carPhoto,carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("/addphoto")]
        public IActionResult AddPhoto([FromForm] CarPhotoForCreationDto carPhoto, int carId)
        {
            var result = _carPhotoService.AddPhoto(carPhoto, carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("/getphotos")]
        public IActionResult GetPhotos(int carId)
        {
            var result = _carPhotoService.GetPhotos(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
