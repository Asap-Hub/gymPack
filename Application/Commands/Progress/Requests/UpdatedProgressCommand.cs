using gym.Application.DTOs.ProgressDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace gym.Application.Commands.Progress.Requests
{
    public class UpdatedProgressCommand : IRequest<Unit>
    {
        public UpdateProgressDto UpdateProgressDto { get; set; }
    }
}
