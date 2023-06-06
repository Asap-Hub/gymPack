using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace gym.Application.Commands.Todo.Requests
{
    public class DeleteTodoCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
