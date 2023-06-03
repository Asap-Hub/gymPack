using gym.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace gym.Application.DTOs.ProgressDtos
{
    public class ProgressDto : BaseDto
    {
        public string Status { get; set; } = null!;
        public int Percentage { get; set; }
        public bool Completed { get; set; }
        public bool Reviewed { get; set; }
        public string ReviewBy { get; set; } = null!;
    }
}
