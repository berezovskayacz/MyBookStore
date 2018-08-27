using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBookstore.Services;
using System.Web;
using MyBookstore.Data;
using MyBookstore.Core;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBookstore.Models;
using PagedList;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http.Headers;
using FluentValidation.Attributes;
//using ActionMailer.Net.Mvc;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;

namespace MyBookstore.Web.Controllers
{
    public class MailController // : Controller
    {
        //    public void RegisterEmail(RegisterViewModel model)
        //    {
        //        To.Add(model.Email);
        //        From = "berezovskaya.cz@gmail.com";
        //        Subject = "Welcome to My Bookstore!";

        //    }
        //}

        //private async Task SendAsync(string to, string subject, string body, bool IsBodyHtml, RegisterViewModel model)
        //{
        //    var message = new MailMessage();
        //    message.To.Add(new MailAddress(model.Email));
        //    message.From = new MailAddress("berezovskaya.cz@gmail.com");
        //    message.Subject = "Welcome to My Bookstore";
        //    message.Body = body;
        //    message.IsBodyHtml = IsBodyHtml;

        //    using (var smtp = new SmtpClient())
        //    {
        //        var credential = new NetworkCredential
        //        {
        //            UserName = model.Name,
        //            Password = model.Password
        //        };
        //        smtp.Credentials = credential;
        //        smtp.Host = _tjsSettings.SmtpHost;
        //        smtp.Port = _tjsSettings.SmtpPort;
        //        smtp.EnableSsl = _tjsSettings.SmtpEnableSsl;
        //        await smtp.SendMailAsync(message);
        //    }

        //}
    }
}