using gym.Domain.Common;
using System;
using System.Collections.Generic;

namespace gym.Domain.Model
{

    public partial class TblProgress: BaseDomain
    {
        public int ProgressId { get; set; }
        public string Status { get; set; } = null!;
        public int Percentage { get; set; }
        public bool Completed { get; set; }
        public bool Confirmed { get; set; }
        public string ConfirmedBy { get; set; }
         
    }
}