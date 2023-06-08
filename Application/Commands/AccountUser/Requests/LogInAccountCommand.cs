using gym.Application.DTOs.Identity;
using gym.Application.Extentions.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace gym.Application.Commands.AccountUser.Requests
{
    public class LogInAccountCommand : IRequest<BaseResponse>
    {
        public LoginDto LoginDto { get; set; }
    }
}
