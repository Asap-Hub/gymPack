using gym.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace gym.Application.DTOs.TodoDtos
{
    public class CreateTodoDto  : BaseDto
    {
        public int TodoId { get; set; }
        public string Title { get; set; }

        public string Note { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
