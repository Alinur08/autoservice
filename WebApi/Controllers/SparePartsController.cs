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
    public class SparePartsController : ControllerBase
    {
        private ISparePartService _sparePartService;
        public SparePartsController(ISparePartService sparePartService)
        {
            _sparePartService = sparePartService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll(int year)
        {
            var result =_sparePartService.GetSparePartsByYear(year);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getAllbybrand")]
        public IActionResult GetAllByBrand(int brandId)
        {
            var result = _sparePartService.GetSparePartsByBrand(brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getAllByModel")]
        public IActionResult GetAllByModel(int modelId)
        {
            var result = _sparePartService.GetSparePartsByModel(modelId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getAllByModel")]
        public IActionResult GetAllByYear(int year)
        {
            var result = _sparePartService.GetSparePartsByYear(year);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("get")]
        public IActionResult GetById(int id)
        {
            var result = _sparePartService.GetSparePart(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(SparePart sparePart)
        {
            var result = _sparePartService.Add(sparePart);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(SparePart sparePart)
        {
            var result = _sparePartService.Delete(sparePart);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(SparePart sparePart)
        {
            var result = _sparePartService.Update(sparePart);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
