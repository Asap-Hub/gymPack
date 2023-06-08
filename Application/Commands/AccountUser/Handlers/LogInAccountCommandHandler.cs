using gym.Application.Commands.AccountUser.Requests;
using gym.Application.Extentions.IdentityExtension;
using gym.Application.Extentions.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace gym.Application.Commands.AccountUser.Handlers
{
    public class LogInAccountCommandHandler : IRequestHandler<LogInAccountCommand, BaseResponse>
    {
        private readonly SignInManager<User> _signInManager;
        private readonly IUrlHelper _urlHelper;

        public LogInAccountCommandHandler(SignInManager<User> signInManager, IUrlHelper urlHelper)
        {
            _signInManager = signInManager;
            _urlHelper = urlHelper;
        }
        public async Task<BaseResponse> Handle(LogInAccountCommand request, CancellationToken cancellationToken)
        {
            var login = await _signInManager.PasswordSignInAsync(request.LoginDto.Email, request.LoginDto.Password,request.LoginDto.RememberMe ,  false);

            if(login.Succeeded) 
            {
                return new BaseResponse { issuccess = login.Succeeded};
                
            }
            else
            {
                if(login.RequiresTwoFactor)
                {

                    //return (BaseResponse)RedirectResult("ConfirmAccount");
                    //var verificationLink = _urlHelper.ActionLink(controller: "/ConfirmAccount",
                    //            values: new
                    //            {
                    //                User = dto.Id,
                    //                Token = confirmEmail,
                    //            }
                    //   );

                }
                if (login.IsLockedOut)
                {
                    return new BaseResponse
                    {
                        issuccess = login.IsLockedOut,
                        Message =  "Login, You are Locked Out"
                    };
                }
                else
                {
                    return new BaseResponse
                    {
                        issuccess = false,
                        Message = "Failed to login",
                    };
                }
            }
        }

       
    }
}
