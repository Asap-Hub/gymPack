using System;
using System.Collections.Generic;
using System.Text;

namespace gym.Application.Extentions.Exceptions
{
    public class BadRequestException : ApplicationException
    {
        public BadRequestException(string Message) : base(Message)
        {

        }
    }
}
