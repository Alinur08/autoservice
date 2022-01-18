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
    public class TransCarePhotosController : ControllerBase
    {
        private ITransCarePhotoService _transCarePhotoService;
        public TransCarePhotosController(ITransCarePhotoService transCarePhotoService)
        {
            _transCarePhotoService = transCarePhotoService;
        }
        [HttpPost("Add")]
        public IActionResult Add([FromForm]TransCarePhotoCreationDto photo,int transCareId)
        {
            var result = _transCarePhotoService.AddPhoto(photo, transCareId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Delete")]
        public IActionResult Delete([FromBody] TransCarePhoto photo)
        {
            var result = _transCarePhotoService.DeletePhoto(photo.Id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
