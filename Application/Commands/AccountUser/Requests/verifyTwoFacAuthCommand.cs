using gym.Application.Extentions.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace gym.Application.Commands.AccountUser.Requests
{
    public class verifyTwoFacAuthCommand : IRequest<IdentityBaseResponse>
    {
        public string SecurityCode { get; set; }
        public bool RememberMe { get; set; }
    }
}
