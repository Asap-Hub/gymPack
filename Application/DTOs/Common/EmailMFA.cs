using System;
using System.Collections.Generic;
using System.Text;

namespace gym.Application.DTOs.Common
{
    public class EmailMFA
    {
        public string securityCode { get; set; }
        public bool RememberMe { get; set; }
    }
}
