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
    public class SparePartPhotosController : ControllerBase
    {
        private ISparePartPhotoService _sparePartPhotoService;
        public SparePartPhotosController(ISparePartPhotoService sparePartPhotoService)
        {
            _sparePartPhotoService = sparePartPhotoService;
        }
        [HttpPost("Add")]
        public IActionResult Add([FromForm]SparePartPhotoForCreationDto sparePartPhoto,int sparePartId) {
            var result = _sparePartPhotoService.AddPhoto(sparePartPhoto, sparePartId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetPhotos")]
        public IActionResult GetaLL(int sparePartId)
        {
            var result = _sparePartPhotoService.GetSparePartPhotos(sparePartId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Delete")]
        public IActionResult Delete(int sparePartPhotoId)
        {
            var result = _sparePartPhotoService.Delete(sparePartPhotoId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
