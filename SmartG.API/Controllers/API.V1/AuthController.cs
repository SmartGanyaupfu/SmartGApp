using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartG.API.ActionFilters;
using SmartG.Service.Contracts;
using SmartG.Shared.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartG.API.Controllers.API.V1
{
    [Route("api/authentication")]
    public class AuthController : ControllerBase
    {
        private readonly IServiceManager _service;
        //private readonly IEmailSenderService _emailSenderService;

        public AuthController(IServiceManager service)
        {
            _service = service;
            //_emailSenderService = emailSenderService;
        }
        [HttpPost("register")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        {
            var result = await _service.AuthenticationService.RegisterUser(userForRegistration);
            if (!result.Succeeded)
            { foreach (var error in result.Errors) { ModelState.TryAddModelError(error.Code, error.Description); } return BadRequest(ModelState); }
            return StatusCode(201);

        }

        [HttpPost("login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthDto user)
        {
           
            if (!await _service.AuthenticationService.CheckEmailConfirmedAsync(user))
                return Unauthorized("Email is not cofirmed");
            if (!await _service.AuthenticationService.ValidateUser(user))
                return Unauthorized();

            var tokenDto = await _service.AuthenticationService.CreateToken(populateExp: true);

            return Ok(tokenDto);
        }

        [HttpGet("EmailConfirmation")]
        public async Task<IActionResult> EmailConfirmation([FromQuery] ConfirmEmailDto confirmEmailDto)
        {
            if (!await _service.AuthenticationService.EmailCofirmationAsync(confirmEmailDto))
                return BadRequest("Invalid Email Confirmation request");

            return Ok();
        }

        [HttpGet("get-all-users")]
        public async Task<IActionResult> GetUsers()
        {

            var usersToReturn = await _service.AuthenticationService.GetUsersAsync();
            return Ok(usersToReturn);

        }

        [HttpPost("forgotpassword")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto forgotPasswordDto)
        {
            if (!await _service.AuthenticationService.ForgotPassworddAsync(forgotPasswordDto))
                return BadRequest(" This email could not be found.");

            return Ok();
        }

        [HttpPut("{Id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Update([FromBody] UserForUpdateDto userForUpdate, string Id)
        {
            var result = await _service.AuthenticationService.UpdateUserAsync(userForUpdate, Id);
            if (!result)
                return BadRequest($" User with this ID: {Id} does not exist");
            //_userManager.Res
            // _userManager.remove
            return NoContent();
        }

        [HttpPost("ResetPassword")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto resetPasswordDto)
        {

            if (!await _service.AuthenticationService.ResetPasswordAsync(resetPasswordDto))
                return BadRequest("Invalid Request");
            return Ok();
        }

        [HttpDelete("delete-user/{Id}")]
        public async Task<IActionResult> DeleteUser(string Id)
        {
            if (!await _service.AuthenticationService.DeleteUserAsync(Id))
                return BadRequest("User with ID: {ID} does not exist");
            return NoContent();
        }
        [HttpGet("get-user/{Id}")]
        public async Task<IActionResult> GetUserById(string Id)
        {
            var userToReturn = await _service.AuthenticationService.GetUserAsync(Id);
            if (userToReturn is null)
                return BadRequest($"User with id: {Id} does not exist");
            return Ok(userToReturn);
        }

    }
}

