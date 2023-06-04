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
    public class signUserOutCommandHandler : IRequestHandler<signUserOutCommand, BaseResponse>
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public signUserOutCommandHandler(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<BaseResponse> Handle(signUserOutCommand request, CancellationToken cancellationToken)
        {
            var findUser = await _userManager.FindByEmailAsync(request.Email);
            if(findUser != null)
            {
                await _signInManager.SignOutAsync();

                return new BaseResponse
                {
                    IsSuccess = true,
                    Message = "SignOut Successfully"
                };
            }
            return new BaseResponse
            {
                IsSuccess = false,
                Message = "Operation Failed"
            };
        }
    }
}
//await _signInManager.SignOutAsync();
//return Ok();