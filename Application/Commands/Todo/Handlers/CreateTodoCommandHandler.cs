using AutoMapper;
using gym.Application.Commands.Todo.Requests;
using gym.Application.Extentions.Responses;
using gym.Application.Interfaces;
using gym.Domain.Model;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace gym.Application.Commands.Todo.Handlers
{
    public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, int>
    {
        private readonly IGenericBaseRepository<TblMyTodo> _repository;
        private readonly IMapper _mapper;
        //private readonly ILogger _logger;

        public CreateTodoCommandHandler(IGenericBaseRepository<TblMyTodo> repository, IMapper mapper )
        {
            _repository = repository;
            _mapper = mapper; 
        }
        public async Task<int> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var dto = request.createDto;
                var entity = new TblMyTodo();
                var data = _mapper.Map(dto, entity);
                FormattableString sql = $"";


                var createTodo = await _repository.createAsync(sql);

                return createTodo;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
               
            }
        }
    }
}
