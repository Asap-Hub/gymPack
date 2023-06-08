using gym.Application.Commands.Progress.Requests;
using gym.Application.DTOs.ProgressDtos;
using gym.Application.Extentions.Responses; 
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc; 
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gym.Api.Controllers.Progress
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProgressTrackerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProgressTrackerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<IActionResult> CreateProgress([FromBody] CreateProgressDto createProgressDto) 
        {
            if(!ModelState.IsValid) 
            { 
                return BadRequest(ModelState);
            }


            var createProgress = await _mediator.Send(new CreateProgressCommand { CreateProgressDto = createProgressDto});

            if(createProgress != null)
            {
                return Ok(new BaseResponse
                {
                Id = createProgress,
                 issuccess = true,
                    Status = StatusCodes.Status201Created,
                Message = "Progress Tracker Added",
                });

            }
            return BadRequest(new BaseResponse
            { 
                issuccess = false,
                Status = StatusCodes.Status400BadRequest, 
                
            });
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdatedProgress([FromRoute] int Id,[FromBody] UpdateProgressDto updateProgressDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var getProgress = await _mediator.Send(new GetProgressByIdRequest { Id = Id});
            if(getProgress != null)
            {
                var updateProgress = await _mediator.Send(new UpdatedProgressCommand { UpdateProgressDto = updateProgressDto });    
                if(updateProgress != null)
                {
                    return Ok(new BaseResponse
                    { 
                    Id = getProgress.ProgressId,
                    issuccess = true,
                    Status = StatusCodes.Status202Accepted
                    });
                }
            }
            return BadRequest(new BaseResponse
            {
                Id = getProgress.ProgressId,
                issuccess = false,
                Status = StatusCodes.Status400BadRequest
            });

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{Id}")]
        public async Task<ActionResult<ProgressDto>> GetProgressById([FromRoute] int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var getProgress = await _mediator.Send(new GetProgressByIdRequest { Id = Id });
            if (getProgress != null) 
            {
                return Ok(new BaseResponse
                {
                    Id = getProgress.ProgressId,
                    issuccess = true,
                    Status = StatusCodes.Status200OK
                });

            }
            return BadRequest(new BaseResponse
            {
                Id = getProgress.ProgressId,
                issuccess = false,
                Message = $"Progress Tracker with {getProgress.ProgressId} was not found",
                Status = StatusCodes.Status404NotFound
            });
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<ActionResult<List<ProgressDto>>> GetAllProgressCommand([FromRoute] int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var getProgress = await _mediator.Send(new GetAllProgressCommand { });
            if (getProgress != null) 
            {
                return Ok(new BaseResponse
                { 
                    issuccess = true,
                    Status = StatusCodes.Status200OK
                });

            }
            return BadRequest(new BaseResponse
            { 
                issuccess = false,
                Status = StatusCodes.Status404NotFound
            });
        }

    }
}
