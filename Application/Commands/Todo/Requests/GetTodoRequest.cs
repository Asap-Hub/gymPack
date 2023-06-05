using gym.Application.DTOs.TodoDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace gym.Application.Commands.Todo.Requests
{
    public class GetTodoRequest : IRequest<TodoDto>
    {
        public int Id { get; set; }
    }
}
