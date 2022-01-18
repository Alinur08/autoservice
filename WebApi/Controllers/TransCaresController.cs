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
    public class TransCaresController : ControllerBase
    {
        private ITransCareService _transCareService;
        public TransCaresController(ITransCareService transCareService)
        {
            _transCareService = transCareService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll() {
            var result = _transCareService.GetTransCares();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("Get")]
        public IActionResult GetById(int id)
        {
            var result = _transCareService.GetTransCare(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("Add")]
        public IActionResult Add([FromForm]TransCareForAddDto transCare)
        {
            var result = _transCareService.Add(transCare);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("Delete")]
        public IActionResult Delete([FromBody]TransCare transCare)
        {
            var result = _transCareService.Delete(transCare);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("Update")]
        public IActionResult Update([FromBody] TransCare transCare)
        {
            var result = _transCareService.Update(transCare);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
