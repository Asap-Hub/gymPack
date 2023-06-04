using gym.Application.Commands.AccountUser.Requests;
using gym.Application.Extentions.IdentityExtension;
using gym.Application.Extentions.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace gym.Application.Commands.AccountUser.Handlers
{
    public class confirmAccountCommandHandler : IRequestHandler<confirmAccountCommand, int>
    {
        private readonly UserManager<User> _userManager;

        public confirmAccountCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public Task<BaseResponse> Handle(confirmAccountCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
 