using AutoMapper;
using gym.Application.Commands.Todo.Requests;
using gym.Application.Extentions.Exceptions;
using gym.Application.Interfaces;
using gym.Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace gym.Application.Commands.Todo.Handlers
{
    public class DeleteTodoCommandHandler : IRequestHandler<DeleteTodoCommand, int>
    {
        private readonly IGenericBaseRepository<TblMyTodo> _repository; 

        public DeleteTodoCommandHandler(IGenericBaseRepository<TblMyTodo> repository )
        {
            _repository = repository; 
        }
        public async Task<int> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
        {
            try
            {
              
                FormattableString sql = $"";

                var DeleteTodo = await _repository.deleteAsync(sql);

            }
            catch (Exception ex)
            {
                throw new NotFoundException(request.Id.ToString(), ex.Message);
               
            }
            return 0;
        }
    }
}
