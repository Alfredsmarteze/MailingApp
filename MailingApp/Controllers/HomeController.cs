using MailingApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;

namespace MailingApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress("Smart", "alfredsmarteze@gmail.com");

            message.From.Add(from);

            MailboxAddress to = new MailboxAddress("To Alfred", "alfredsmarteze@outlook.com");

            message.To.Add(to);

            message.Subject = "This is mail subject";


            BodyBuilder builder = new BodyBuilder();
            builder.HtmlBody = "<h1>Hello World</h1>";
            builder.TextBody = "Learning Mail Sending";

            message.Body = builder.ToMessageBody();

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.spiritwrite.com.ng",25,false);
            smtpClient.Authenticate("user@spiritwrite.com.ng", "Y!X3eXp-5Y1a9j");
            smtpClient.Send(message);
            smtpClient.Disconnect(true);
            smtpClient.Dispose();

            return View();
        }

        public IActionResult Mailing()
        {
            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress("Smart", "alfredsmarteze@gmail.com");

            message.From.Add(from);

            MailboxAddress to = new MailboxAddress("To Alfred", "alfredsmarteze@outlook.com");

            message.To.Add(to);

            message.Subject = "This is mail subject";


            BodyBuilder builder = new BodyBuilder();
            builder.HtmlBody = "<h1>Hello World</h1>";
            builder.TextBody = "Learning Mail Sending";

            message.Body = builder.ToMessageBody();

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.spiritwrite.com.ng", 25, true);
            smtpClient.Authenticate("user@spiritwrite.com.ng", "Y!X3eXp-5Y1a9j");

            smtpClient.Send(message);
            smtpClient.Disconnect(true);
            smtpClient.Dispose();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
