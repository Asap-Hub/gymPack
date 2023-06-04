
using gym.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace gym.Application.Commands.AccountUser.Requests
{
    public class confirmAccountCommand : IRequest<int>
    {
    }
}
