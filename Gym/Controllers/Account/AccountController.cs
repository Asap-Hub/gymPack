using gym.Application.Commands.AccountUser.Requests;
using gym.Application.Commands.IdentityCommand.Requests;
using gym.Application.DTOs.Identity;
using gym.Application.Extentions.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace gym.Api.Controllers.Account
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> CreateUserAccount([FromBody] CreateUserDto createDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createUser = await _mediator.Send(new createUserCommandRequest
            {
                createDto = createDto
            });

            if (createUser.IsSuccess)
            {
                return CreatedAtRoute("ConfirmAccount",
                    new IdentityBaseResponse
                    {
                        Id = createDto.GetHashCode(),
                        IsSuccess = true,
                        Message = "Registration Successfully",
                        statusCode = StatusCodes.Status200OK,

                    }, createUser);

            }

            return BadRequest();
        }


        [HttpGet(Name = "ConfirmAccount")]
        public async Task<IActionResult> ConfirmAccount(string userId, string Token)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var confirmAccount = await _mediator.Send(new ConfirmAccountCommand { userId = userId, Token = Token });
            if (confirmAccount.IsSuccess)
            {
                return Ok(new IdentityBaseResponse
                {
                    IsSuccess = true,
                    statusCode = StatusCodes.Status200OK,
                    Message = "Email Confirmation was successful"
                });
            }

            return BadRequest(new IdentityBaseResponse
            {
                IsSuccess = false,
                statusCode = StatusCodes.Status400BadRequest,
                Message = "Email Confirmation was Unsuccessful"
            });
        }


        [HttpGet]
        public async Task<IActionResult> LogInWithTwoFactoryCode(string Email, bool RememberMe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var signInWith2Fac = await _mediator.Send(new signInWithTwoFactoryAuthRequest { Email = Email, RememberMe = RememberMe });
            if (signInWith2Fac != null)
            {
                return Ok(new IdentityBaseResponse
                {
                    IsSuccess = true,
                    statusCode = StatusCodes.Status200OK,
                });
            }

            else
            {
                return BadRequest(new IdentityBaseResponse
                {
                    IsSuccess = false,
                    statusCode = StatusCodes.Status400BadRequest,
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> verifyWithTwoFactoryAuth(string SecurityCode, bool RememberMe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var verifyMyOTP = await _mediator.Send(new verifyTwoFacAuthCommand { SecurityCode = SecurityCode, RememberMe = RememberMe });

            if (verifyMyOTP.IsSuccess)
            {
                return Ok(new IdentityBaseResponse
                {
                    IsSuccess = true,
                    statusCode = StatusCodes.Status200OK,
                });
            }

            return BadRequest(new IdentityBaseResponse
            {
                IsSuccess = false,
                statusCode = StatusCodes.Status400BadRequest,
            });

        }

        [HttpPost]
        public async Task<IActionResult> signUserOut([FromBody] string Email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var signOut = await _mediator.Send(new signUserOutCommand { Email = Email });

            if (signOut.IsSuccess)
            {
                return Ok(new IdentityBaseResponse
                {
                    IsSuccess = true,
                    statusCode = StatusCodes.Status200OK,
                });
            }
            else
            {
                return BadRequest(new IdentityBaseResponse
                {
                    IsSuccess = false,
                    statusCode = StatusCodes.Status400BadRequest,
                });
            }
        }
    }
}
