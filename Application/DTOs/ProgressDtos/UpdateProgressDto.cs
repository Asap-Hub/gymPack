using gym.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace gym.Application.DTOs.ProgressDtos
{
    public class UpdateProgressDto : BaseDto
    {
        public int ProgressId { get; set; }
        public string Status { get; set; } = null!;
        public int Percentage { get; set; }
        public bool Completed { get; set; }
        public bool Confirmed { get; set; }
        public string ConfirmedBy { get; set; } = null!;
    }
}
