using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using SkladisteProizvodApi.Presentation.ActionFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkladisteProizvodApi.Presentation.Controllers
{
    [Route("api/Authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AuthenticationController(IServiceManager service)
        {
            _service = service;
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        {
            var result = await _service.AuthenticationService.RegisterUser(userForRegistration);
            if (!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return StatusCode(201);
        }

        [HttpPost("login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]  
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto userForAuth)
        {
            var result = await _service.AuthenticationService.ValidateUser(userForAuth);
            if(!result)
            {
                return Unauthorized();
            }

            return Ok(new
            {
                Token = await _service.AuthenticationService.CreateToken()
            });

        }

    }
}
