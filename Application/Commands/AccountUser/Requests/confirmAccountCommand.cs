using gym.Application.Extentions.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace gym.Application.Commands.AccountUser.Requests
{
    public class ConfirmAccountCommand : IRequest<IdentityBaseResponse>
    {
        public string userId { get; set;}
        public string Token { get; set;}
    }
}
