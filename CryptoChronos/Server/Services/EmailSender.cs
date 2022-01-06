using CryptoChronos.Shared.DTOs;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace CryptoChronos.Server.Services
{
    public class EmailSender
    {
        private string _apiKey;

        public EmailSender(string apiKey)
        {
            _apiKey = apiKey;
        }

        public async Task<Response> SendEmail(SendEmailModel model)
        {
            var apiKey = _apiKey;
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(model.FromEmail, model.FromName);
            var to = new EmailAddress(model.To);
            var plainTextContent = model.Body;
            var msg = MailHelper.CreateSingleEmail(from, to, model.Subject, plainTextContent, plainTextContent);
            return await client.SendEmailAsync(msg).ConfigureAwait(false);
        }
    }
}
