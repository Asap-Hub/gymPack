using gym.Application.Extentions.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace gym.Application.Commands.IdentityCommand.Requests
{
    public class createUserCommand : IRequest<BaseResponse>
    {
    }
}
