using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using MyBookstore.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MyBookstore.Services
{
    public interface IMailingService
    {
        Task SendAsync(string to, string subject, string body, bool IsBodyHtml);
    }
}
