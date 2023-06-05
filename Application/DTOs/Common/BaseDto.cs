using System;
using System.Collections.Generic;
using System.Text;

namespace gym.Application.DTOs.Common
{
    public abstract class BaseDto 
    {
        public string CreatedBy { get; set; } 
        public string EdittedBy { get; set; }
    }
}
