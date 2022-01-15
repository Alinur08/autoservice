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
    public class CarsController : ControllerBase
    {
        private ICarService _carService;
        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetCars() {

            var result = _carService.GetCars();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("GetMains")]
        public IActionResult GetCarsByMain()
        {

            var result = _carService.GetCarsMain();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("GetCars")]
        public IActionResult GetCarsByBrand(int brandId)
        {

            var result = _carService.GetCarsByBrand(brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getcarbyid")]
        public IActionResult GetCarById(int carId)
        {
            var result = _carService.GetCarById(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Add")]
        public IActionResult AddCar([FromForm]CarForAddDto car )
        {

            var result = _carService.AddCarDto(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("Delete")]
        public IActionResult DeleteCar([FromBody] Car car)
        {

            var result = _carService.Delete(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("Update")]
        public IActionResult UpdateCar([FromBody] Car car)
        {

            var result = _carService.Update(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("ShowInHome")]
        public IActionResult ShowInHome([FromBody] Car car)
        {

            var result = _carService.MakeCarVisible(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("RemoveFromHome")]
        public IActionResult RemoveFromHome([FromBody] Car car)
        {

            var result = _carService.MakeCarInVisible(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

    }
}
