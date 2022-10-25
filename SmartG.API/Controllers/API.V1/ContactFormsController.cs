using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartG.Contracts;
using SmartG.Shared.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartG.API.Controllers.API.V1
{
    [Route("api/contact-forms")]
    public class ContactFormsController : Controller
    {
        
        private readonly IEmailSender _emailSenderService;

        public ContactFormsController(IEmailSender emailSenderService)
        {
            _emailSenderService = emailSenderService;
        }
        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ContactFormDto contact)
        {
            var myEmail = "dev@smartganyaupfu.com";
            var message = new EmailMessageDto(new string[] {  myEmail}, "Web Form ", "From "+contact.Email +" <br>  Name "+contact.Name + "<br>  Message  "+contact.Message );
            await _emailSenderService.SendEmailAsync(message);

            return Ok();
        }

    }
}

