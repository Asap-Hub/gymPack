using System;
using System.Collections.Generic;
using System.Text;

namespace gym.Application.DTOs.Common
{
    public abstract class BaseIdDto : BaseDto
    {
        public int Id { get; set; }
    }
}
