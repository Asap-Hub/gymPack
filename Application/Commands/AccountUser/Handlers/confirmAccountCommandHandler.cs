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
    public class confirmAccountCommandHandler : IRequestHandler<ConfirmAccountCommand, IdentityBaseResponse>
    {
        private readonly UserManager<User> _userManager;

        public confirmAccountCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityBaseResponse> Handle(ConfirmAccountCommand request, CancellationToken cancellationToken)
        {
            
            var findUser = await _userManager.FindByIdAsync(request.userId);

            if(findUser !=null) 
            {

                var result = await _userManager.ConfirmEmailAsync(findUser, request.Token);
                if(result.Succeeded) 
                {

                    return new IdentityBaseResponse
                    {
                        IsSuccess = true,
                        Message = "Email Confirmation was successful", 
                    };

                }
             }

            else
            {
                return new IdentityBaseResponse
                {
                    IsSuccess = false,
                    Message = "Email Confirmation was Unsuccessful",
                };
            }
            return null;
        }
    
    }
} 