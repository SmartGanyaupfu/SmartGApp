using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartG.Service.Contracts;
using SmartG.Shared.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartG.API.Controllers.API.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {

        private readonly IServiceManager _serviceManager;

        public TokenController(
           IServiceManager serviceManager)
        {

            _serviceManager = serviceManager;
        }

        // POST api/values
        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshJWT([FromBody] TokenDto tokenDto)
        {
            var tokenDtoToReturn = await _serviceManager.AuthenticationService.RefreshToken(tokenDto);

            return Ok(tokenDtoToReturn);
        }


    }
}

