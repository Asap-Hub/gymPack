using gym.Application.Commands.IdentityCommand.Requests;
using gym.Application.DTOs.Identity;
using gym.Application.Extentions.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace gym.Api.Controllers
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
            if(!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            var createUser = await _mediator.Send(new createUserCommandRequest{
                createDto = createDto
            });

            if(createUser != null)
            {
                return Ok(new BaseResponse { 
                Id = createDto.GetHashCode(),
                IsSuccess = true,
                Message = "Registration Successfully",
                statusCode = StatusCodes.Status200OK,

                });
            }

            
            return BadRequest();
        }
    }
}
