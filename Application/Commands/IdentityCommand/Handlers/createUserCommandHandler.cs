using gym.Application.Commands.IdentityCommand.Requests;
using gym.Application.Extentions.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace gym.Application.Commands.IdentityCommand.Queries
{
    public class createUserCommandHandler : IRequestHandler<createUserCommand, BaseResponse>
    {
        public createUserCommandHandler()
        {
            
        }
    }
}
