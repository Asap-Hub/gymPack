using FluentValidation;
using gym.Application.Commands.IdentityCommand.Requests;
using gym.Application.DTOs.Identity;
using gym.Application.Extentions.Exceptions;
using gym.Application.Extentions.IdentityExtension;
using gym.Application.Extentions.Responses;
using gym.Application.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Security.Policy;
using System.Threading;
using System.Threading.Tasks; 

namespace gym.Application.Commands.IdentityCommand.Queries
{
    public class createUserCommandHandler : IRequestHandler<createUserCommandRequest, BaseResponse>
    {
        private readonly UserManager<User> _userManager;
        private readonly IEmailService _emailService; 
        private readonly IValidator<CreateUserDto> _validator;
        private readonly IUrlHelper urlHelper;
         

        public createUserCommandHandler(UserManager<User> userManager, IEmailService emailService, IUrlHelperFactory urlHelperFactory, IValidator<CreateUserDto> validator, IUrlHelper urlHelper )
        {
            _userManager = userManager;
            _emailService = emailService; 
            _validator = validator;
            this.urlHelper=urlHelper;

        }

        public async Task<BaseResponse> Handle(createUserCommandRequest request, CancellationToken cancellationToken)
        {
            var validateUser = await _validator.ValidateAsync(request.createDto);

            if (!validateUser.IsValid)
            {
                throw new ValidException(validateUser);

            }

            var userNameGenerator = (request.createDto.FirstName.Trim().ToLower() + request.createDto.LastName.Trim().ToLower());
            var userName = userNameGenerator.Substring(0, userNameGenerator.Length -1);

            var dto = new User
            {
                UserName = userName,
                FirstName = request.createDto.FirstName,
                LastName = request.createDto.LastName,
                Email = request.createDto.Email
               
            };

            var createUser = await _userManager.CreateAsync(dto, request.createDto.Password);

            if (createUser.Succeeded)
            {

                var confirmEmail = await _userManager.GenerateEmailConfirmationTokenAsync(dto);



                var verificationLink = urlHelper.PageLink(pageName: "/confirmation",
                            values: new
                            {
                                User = dto.Id,
                                Token = confirmEmail,
                            }
                   );

                await _emailService.sendEmailAsync("asaphub01@gmail.com",
                    dto.Email!,
                    "Please confirm your email",
                    $"Click on the link in the email we sent to :{verificationLink} to verify your account"
                    );
            }

            else
            {
                //throw new ValidException(validateUser);

                foreach (var error in createUser.Errors)
                {
                    //return new BaseResponse
                    //{
                    //    Message = "Error",
                    //    IsSuccess = false,
                    //    Errors = error,
                    //};
                    Console.WriteLine(error);
                }
            }
            return new BaseResponse {
                Message = "Sucess",
                IsSuccess = true
            };
        }

        //if (createUser.Succeeded)
        //{
        //    var confirmEmail = await _userManager.GenerateEmailConfirmationTokenAsync(dto);
        //    // return Ok( value: new {
        //    //     User = dto.Id,
        //    //     Token = confirmEmail,
        //    //});
        //    var verificationLink = Url.PageLink(pageName: "SOME ROUTE",
        //                 values: new
        //                 {
        //                     User = dto.Id,
        //                     Token = confirmEmail,
        //                 }
        //        );

        //    await _emailServices.sendEmailAsync("ab@gmail.com",
        //        user.Email!,
        //        "Please confirm your email",
        //        $"please click on this link to confirms your email address:{verificationLink}"
        //        );

        //}
        //else
        //{
            //foreach (var error in createUser.Errors)
            //{
            //    ModelState.AddModelError("Registration", error.Description);
            //}
    //}
    //return BadRequest(ModelState);

}


}
