using gym.Application.Commands.AccountUser.Requests;
using gym.Application.Extentions;
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
    public class verifyTwoFacAuthCommandHandler : IRequestHandler<verifyTwoFacAuthCommand, IdentityBaseResponse>
    {
        private readonly SignInManager<User> _signInManager;

        public verifyTwoFacAuthCommandHandler(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }
        public async Task<IdentityBaseResponse> Handle(verifyTwoFacAuthCommand request, CancellationToken cancellationToken)
        {
            var verifyOTP = await _signInManager.TwoFactorSignInAsync("Email", request.SecurityCode, request.RememberMe, false);

            if (verifyOTP.Succeeded)
            {
                return new IdentityBaseResponse
                {
                    IsSuccess = true,
                    Message = "Validation Passed",
                };
                //you can use createAtRoute and pass the route to home page 
                //use claims to assign to other pages
            }

            else
            {
                if (verifyOTP.IsLockedOut)
                {
                    return new IdentityBaseResponse
                    {
                        IsSuccess = verifyOTP.IsLockedOut,
                        Message = $"You are  {verifyOTP.IsLockedOut}"
                    };
                }
                else
                {
                    return new IdentityBaseResponse
                    {
                        IsSuccess = false,
                        Message = "Failed to login", 
                    };
                }

            }
             
        }
    }
}
 