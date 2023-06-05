using System;
using System.Collections.Generic;
using System.Text;

namespace gym.Domain.Common
{
    public abstract class BaseDomain
    {
        
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime EdittedDate { get; set; }
        public string EdittedBy { get; set; }
    }
}
