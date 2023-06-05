using gym.Application.Commands.Todo.Requests;
using gym.Application.DTOs.TodoDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace gym.Application.Commands.Todo.Handlers
{
    public class GetAllTodoRequestHandler : IRequestHandler<GetAllTodoRequest, List<TodoDto>>
    {
        public Task<List<TodoDto>> Handle(GetAllTodoRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
