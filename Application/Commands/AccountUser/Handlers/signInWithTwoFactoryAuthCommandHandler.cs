using gym.Application.Commands.AccountUser.Requests;
using gym.Application.DTOs.Common;
using gym.Application.Extentions.IdentityExtension;
using gym.Application.Extentions.Responses;
using gym.Application.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace gym.Application.Commands.AccountUser.Handlers
{
    public class signInWithTwoFactoryAuthCommandHandler : IRequestHandler<signInWithTwoFactoryAuthRequest, IdentityBaseResponse>
    {
        private readonly UserManager<User> _userManager;
        private readonly IEmailService _emailService;

        public signInWithTwoFactoryAuthCommandHandler(UserManager<User> userManager, IEmailService emailService)
        {
            _userManager = userManager;
            _emailService = emailService;
        }
        public EmailMFA EmailMFA { get; set; }
        public async Task<IdentityBaseResponse> Handle(signInWithTwoFactoryAuthRequest request, CancellationToken cancellationToken)
        {
            var findUser = await _userManager.FindByEmailAsync(request.Email);

            if(findUser != null)
            {
                //EmailMFA.securityCode = request.Email;
                //EmailMFA.RememberMe = request.RememberMe;
                var getSecurityCode = await _userManager.GenerateTwoFactorTokenAsync(findUser, "Email");
                if(getSecurityCode != null)
                {
                    await _emailService.sendEmailAsync(
                        "asaphub01@gmail.com",
                        request.Email,
                        "Your Gym OTP Code",
                        $"use this otp to login into your app.{getSecurityCode}"
                        );
                }
            
            }
            return new IdentityBaseResponse{ 
            IsSuccess = false,
            Message = "Unable To Signin using the provided Critecials"
            };
        }
    }
}

 
