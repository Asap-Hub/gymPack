using System;
using System.Collections.Generic;
using System.Text;

namespace gym.Application.Responses
{
    public class BaseResponse
    {
        public int Id { get; set; }
        public bool success { get; set; } = true;
        public string message { get; set; }
        public List<string> errors { get; set; }
    }
}
