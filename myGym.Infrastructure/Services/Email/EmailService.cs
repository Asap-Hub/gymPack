using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using gym.Application.Interfaces.Services;
using MailKit.Security;
using MimeKit;

namespace gym.Infrastructure.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly IOptions<SMTPSettings> _smtpSettings;

        public EmailService(IOptions<SMTPSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings;
        }
        public async Task sendEmailAsync(string from, string to, string subject, string body)
        {
            var message = new MailMessage(from, to, subject, body);

            using (var emailClient = new SmtpClient(_smtpSettings.Value.Host, _smtpSettings.Value.Port))
            {
                emailClient.Credentials = new NetworkCredential(
                    _smtpSettings.Value.User,
                    _smtpSettings.Value.Password
                    );

                await emailClient.SendMailAsync(message);
            }
        }


    }
}
