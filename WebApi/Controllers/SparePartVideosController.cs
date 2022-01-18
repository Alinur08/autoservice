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
    public class SparePartVideosController : ControllerBase
    {
        private ISparePartVideoService _sparePartVideoService;
        public SparePartVideosController(ISparePartVideoService sparePartVideoService)
        {
            _sparePartVideoService = sparePartVideoService;
        }
        [HttpGet("getvideos")]
        public IActionResult GetVideos()
        {
            var result = _sparePartVideoService.GetVideos();
            if (result.Success) { 
               return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult AddVideo([FromForm]SparePartVideoCreationDto video)
        {
            var result = _sparePartVideoService.AddVideo(video);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult DeleteVideo(int videoId)
        {
            var result = _sparePartVideoService.DeleteVideo(videoId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
