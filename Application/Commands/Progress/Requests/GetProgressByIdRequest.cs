using gym.Application.DTOs.ProgressDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace gym.Application.Commands.Progress.Requests
{
    public class GetProgressByIdRequest : IRequest<ProgressDto>
    {
        public int Id { get; set; }
    }
}
