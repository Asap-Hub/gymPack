using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace gym.Application.Extentions.Responses
{
    public class BaseResponse
    {
        public int Id { get; set; }
        public bool issuccess { get; set; } 
        public int Status { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
    }
}
