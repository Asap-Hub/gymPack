using gym.Application.DTOs.Identity;
using gym.Application.Extentions.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace gym.Application.Commands.IdentityCommand.Requests
{
    public class createUserCommandRequest : IRequest<BaseResponse>
    {
        public CreateUserDto createDto { get; set; }
    }
}
