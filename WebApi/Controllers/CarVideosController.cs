using Business.Abstract;
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
    public class CarVideosController : ControllerBase
    {
        private ICarVideoService _carVideoService;
        public CarVideosController(ICarVideoService carVideoService)
        {
            _carVideoService = carVideoService;
        }
        [HttpGet("getvideos")]
        public IActionResult GetVideos(int carId)
        {
            var result = _carVideoService.GetVideos(carId);
            if (result.Success) { 
               return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult AddVideo([FromForm]CarVideoCreationDto video,int carId)
        {
            var result = _carVideoService.AddVideo(video,carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult DeleteVideo(int videoId)
        {
            var result = _carVideoService.DeleteVideo(videoId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
