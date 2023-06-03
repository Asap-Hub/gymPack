using System;
using System.Collections.Generic;
using System.Text;

namespace gym.Application.Extentions.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, object key) : base($"{name} ({key}) not Found")
        {

        }
    }
}
