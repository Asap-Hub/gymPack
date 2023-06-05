using System;
using System.Collections.Generic;
using System.Text;

namespace gym.Infrastructure.Services.Email
{
    public class SMTPSettings
    {
        public string Host { get; set; } = null!;
        public int Port { get; set; }
        public string User { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
