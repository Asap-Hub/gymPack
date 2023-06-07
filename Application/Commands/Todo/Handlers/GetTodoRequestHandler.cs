using AutoMapper;
using gym.Application.Commands.Todo.Requests;
using gym.Application.DTOs.TodoDtos;
using gym.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace gym.Application.Commands.Todo.Handlers
{
    public class GetTodoRequestHandler : IRequestHandler<GetTodoRequest, TodoDto>
    {
        private readonly ITodoRepository _repository;
        private readonly IMapper _mapper; 

        public GetTodoRequestHandler(ITodoRepository repository, IMapper mapper )
        {
            _repository = repository;
            _mapper = mapper; 
        }
        public async Task<TodoDto> Handle(GetTodoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                FormattableString sql = $"";
                var getData = await _repository.findByIdAsync(sql);
                var mapResult = _mapper.Map<TodoDto>(getData);
                return mapResult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
