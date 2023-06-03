using gym.Domain.Common;
using System;
using System.Collections.Generic;

namespace gym.Domain.Model
{

    public partial class TblProgress: BaseDomain
    { 
        public string Status { get; set; } = null!;
        public int Percentage { get; set; }
        public bool Completed { get; set; }
        public bool Reviewed { get; set; }
        public string? ReviewBy { get; set; }
         
    }
}