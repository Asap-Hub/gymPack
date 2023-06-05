using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace gym.Application.Interfaces.Services
{
    public interface IEmailService
    {
        Task sendEmailAsync(string from, string to, string subject, string body);
    }
}
