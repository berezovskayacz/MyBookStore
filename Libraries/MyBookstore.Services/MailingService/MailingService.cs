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
    public class MailingService : IMailingService
    {
        const string subject = "Subject";
        const string body = "Body";

        public async Task SendAsync(string to, string subject, string body, bool IsBodyHtml)
        {
            var fromAddress = new MailAddress("info@gmail.com", "FROM My Bookstore");
            var toAddress = new MailAddress(to);
            const string fromPassword = "";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }




        }
    }
}
