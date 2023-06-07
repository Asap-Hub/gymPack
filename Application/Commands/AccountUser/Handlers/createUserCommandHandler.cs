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
    public class createUserCommandHandler : IRequestHandler<createUserCommandRequest, IdentityBaseResponse>
    {
        private readonly UserManager<User> _userManager;
        private readonly IEmailService _emailService; 
        private readonly IValidator<CreateUserDto> _validator;
        private readonly IUrlHelper _urlHelper;
         

        public createUserCommandHandler(UserManager<User> userManager, IEmailService emailService, IUrlHelperFactory urlHelperFactory, IValidator<CreateUserDto> validator, IUrlHelper urlHelper )
        {
            _userManager = userManager;
            _emailService = emailService; 
            _validator = validator;
            _urlHelper = urlHelper;

        }

        public async Task<IdentityBaseResponse> Handle(createUserCommandRequest request, CancellationToken cancellationToken)
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



                var verificationLink = _urlHelper.PageLink(pageName: "/ConfirmAccount",
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

                foreach (var error in createUser.Errors)
                {
                    return new IdentityBaseResponse
                    {
                        Message = "Error",
                        IsSuccess = false,
                        Errors = error,
                    }; 
                }
            }
            return new IdentityBaseResponse {
                Message = "Sucess",
                IsSuccess = true
            };
        }

    }
}
