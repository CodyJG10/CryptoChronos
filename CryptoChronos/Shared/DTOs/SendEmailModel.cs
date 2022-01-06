using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoChronos.Shared.DTOs
{
    public class SendEmailModel
    {
        public string FromEmail { get; set; }
        public string FromName { get; set; }
        public string To { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
    }
}
