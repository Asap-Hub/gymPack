using gym.Application.DTOs.TodoDtos;
using gym.Application.Extentions.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace gym.Application.Commands.Todo.Requests
{
    public class CreateTodoCommand :  IRequest<int>
    {
        public CreateTodoDto createDto {get; set;}
    }
}
