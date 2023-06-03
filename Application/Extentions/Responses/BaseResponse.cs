using System;
using System.Collections.Generic;
using System.Text;

namespace gym.Application.Extentions.Responses
{
    public class BaseResponse
    {
        public int Id { get; set; }

        public int statusCode { get; set; }

        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
