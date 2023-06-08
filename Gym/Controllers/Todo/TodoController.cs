using gym.Application.Commands.Todo.Handlers;
using gym.Application.Commands.Todo.Requests;
using gym.Application.DTOs.TodoDtos;
using gym.Application.Extentions.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Exchange.WebServices.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gym.Api.Controllers.Todo
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodoController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateTodo([FromBody] CreateTodoDto createDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createTodo = await _mediator.Send(new CreateTodoCommand { createDto = createDto });
            if(createTodo != null)
            {
                return Ok(new IdentityBaseResponse
                {
                    Id = createTodo,
                    IsSuccess = true,
                    Message = "Account Created Successfully",
                    statusCode = StatusCodes.Status200OK,
                }); 
            }
            return BadRequest(new IdentityBaseResponse
            { 
                IsSuccess = false , 
                statusCode = StatusCodes.Status400BadRequest
            });
        }

         
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType (StatusCodes.Status400BadRequest)]
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateTodo([FromRoute] int Id, [FromBody] UpdateTodoDto updateDto) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var getTodo = await _mediator.Send(new GetTodoRequest { Id = Id});

            if(getTodo != null) 
            {
                var updateTodo = await _mediator.Send(new UpdateTodoComand { updateDto = updateDto });
                if(updateTodo != null)
                {
                    return Ok(new IdentityBaseResponse
                    {
                        Id = updateDto.TodoId,
                        IsSuccess = true,
                        statusCode = StatusCodes.Status201Created

                    });
                }
            }

            return BadRequest(new IdentityBaseResponse
            { 
                IsSuccess = false,
                statusCode = StatusCodes.Status400BadRequest

            });

        }



        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{Id}")]
        public async Task<ActionResult<TodoDto>> GetTodo([FromRoute] int Id) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var getUser = await _mediator.Send(new GetTodoRequest {Id = Id });
            if(getUser != null)
            {
                return Ok(new IdentityBaseResponse
                { 
                    Id = getUser.TodoId,
                    IsSuccess = true,
                    statusCode = StatusCodes.Status200OK,
                });
            }
            return BadRequest(new IdentityBaseResponse
            {
                Id = getUser.TodoId,
                IsSuccess = false,
                statusCode = StatusCodes.Status200OK,
            });
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<ActionResult<List<TodoDto>>> GetAllTodo() 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var getUser = await _mediator.Send(new GetAllTodoRequest { });
            if(getUser != null)
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
        
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{Id}")]
        public async Task<IActionResult> DeleteTodo([FromQuery] int Id) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deleteUser = await _mediator.Send(new DeleteTodoCommand {Id = Id });
            if(deleteUser != null)
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
    }
}
