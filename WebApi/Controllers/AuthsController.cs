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
    public class AuthsController : ControllerBase
    {
        private IAuthService _authService;
        public AuthsController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody]UserForLoginDto user)
        {
            var loginResult =  _authService.Login(user);
            if (loginResult.Success)
            {
               var result=_authService.CreateToken(loginResult.Data);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest(loginResult);
        }
        [HttpPost("register")]
        public IActionResult Register([FromBody] UserForRegisterDto user)
        {
            var registerResult = _authService.Register(user);
            if (registerResult.Success)
            {
                var result = _authService.CreateToken(registerResult.Data);
                if (registerResult.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest(registerResult);
        }
    }
}
