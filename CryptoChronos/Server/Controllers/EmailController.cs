using CryptoChronos.Server.Services;
using CryptoChronos.Shared.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CryptoChronos.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private EmailSender _emailSender;

        public EmailController(EmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(SendEmailModel model)
        {
            var result = await _emailSender.SendEmail(model);
            return result.IsSuccessStatusCode ? Ok() : BadRequest(result.Body);
        }
    }
}