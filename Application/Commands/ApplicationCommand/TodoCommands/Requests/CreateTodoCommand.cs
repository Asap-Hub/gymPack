using gym.Application.DTOs.TodoDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace gym.Application.Commands.ApplicationCommand.TodoCommands.Requests
{
    public class CreateMyTodoCommand : IRequest<int>
    {
        public CreateTodoDto createDto { get; set; }
    }
}
