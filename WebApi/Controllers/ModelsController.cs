using Business.Abstract;
using Entities.Concrete;
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
    public class ModelsController : ControllerBase
    {
        private IModelService _modelService;
        public ModelsController(IModelService modelService)
        {
            _modelService = modelService;
        }
        [HttpGet("GetModelsbybrand")]
        public IActionResult GetModels(int brandId)
        {
            var result = _modelService.GetModelsByBrand(brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Add")]
        public IActionResult AddModel([FromBody] Model model)
        {
            var result = _modelService.AddModel(model);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Delete")]
        public IActionResult DeleteModel([FromBody] Model model)
        {
            var result = _modelService.DeleteModel(model);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
