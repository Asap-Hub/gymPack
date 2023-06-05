using gym.Application.DTOs.TodoDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace gym.Application.Commands.Todo.Requests
{
    public class UpdateTodoComand : IRequest<Unit>
    {
        public UpdateTodoDto updateDto { get; set; }
    }
}
