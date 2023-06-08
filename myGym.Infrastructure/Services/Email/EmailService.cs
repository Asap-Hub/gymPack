using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using gym.Application.Interfaces.Services; 

namespace gym.Infrastructure.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly IOptions<SMTPSettings> _smtpSettings;

        public EmailService(IOptions<SMTPSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings;
        }
        public async Task SendEmailAsync(string from, string to, string subject, string body)
        {
            var message = new MailMessage(from, to, subject, body);

            using (var emailClient = new SmtpClient(_smtpSettings.Value.Host, _smtpSettings.Value.Port))
            {
                emailClient.EnableSsl = true;
                emailClient.Credentials = new NetworkCredential(
                    _smtpSettings.Value.User,
                    _smtpSettings.Value.Password
                    );

                await emailClient.SendMailAsync(message);
            }

            //MailMessage mailMessage = new MailMessage();
            //mailMessage.From = new MailAddress(from);
            //mailMessage.To.Add(new MailAddress(to));

            //mailMessage.Subject = "Two Factor Code";
            //mailMessage.IsBodyHtml = true;
            //mailMessage.Body = body;

            //SmtpClient client = new SmtpClient();
            //client.Credentials = new System.Net.NetworkCredential(_smtpSettings.Value.User, _smtpSettings.Value.Password);
            //client.Host = _smtpSettings.Value.Host;
            //client.Port = _smtpSettings.Value.Port;

            //try
            //{
            //    client.Send(mailMessage);
            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    // log exception
            //}
            //return false;
        }

       
    }
}
