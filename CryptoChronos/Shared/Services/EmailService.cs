using CryptoChronos.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CryptoChronos.Shared.Services
{
    public class EmailService
    {
        private HttpClient _httpClient;

        public EmailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task SendEmail(SendEmailModel model)
          => await _httpClient.PostAsJsonAsync("", model);
    }
}