using gym.Application.Commands.AccountUser.Requests;
using gym.Application.Extentions.IdentityExtension;
using gym.Application.Extentions.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Exchange.WebServices.Data;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace gym.Application.Commands.AccountUser.Handlers
{
    public class confirmAccountCommandHandler : IRequestHandler<ConfirmAccountCommand, BaseResponse>
    {
        private readonly UserManager<User> _userManager;

        public confirmAccountCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<BaseResponse> Handle(ConfirmAccountCommand request, CancellationToken cancellationToken)
        {
            
            var findUser = await _userManager.FindByIdAsync(request.userId);

            if(findUser != null) 
            {

                var result = await _userManager.ConfirmEmailAsync(findUser, request.Token);
                if(result.Succeeded) 
                {

                    return new BaseResponse
                    {
                        IsSuccess = true,
                        Message = "Email Confirmation was successful", 
                    };

                }
             }

            return new BaseResponse
            {
                IsSuccess = true,
                Message = "Email Confirmation was Unsuccessful",
            };
        }
    
    }
}
//var findUser = await _userManager.FindByIdAsync(userID);

//if (findUser != null)
//{
//    var result = await _userManager.ConfirmEmailAsync(findUser, Token);
//    if (result.Succeeded)
//    {
//        return Ok(value: new Message { message = "Email Confirmation was successful" });

//    }
//}
//return BadRequest(error: new Message { message = "Email Confirmation was successful" });