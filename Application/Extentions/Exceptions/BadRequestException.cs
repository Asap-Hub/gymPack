using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace gym.Application.Extentions.Exceptions
{
    public class BadRequestException 
    {
        public BadRequestException(IdentityError Message)
        {

        }
    }
}
