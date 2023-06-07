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
    public class GetAllTodoRequestHandler : IRequestHandler<GetAllTodoRequest, List<TodoDto>>
    {
        private readonly ITodoRepository _repository;
        private readonly IMapper _mapper; 

        public GetAllTodoRequestHandler(ITodoRepository repository, IMapper mapper )
        {
            _repository = repository;
            _mapper = mapper; 
        }
        public async Task<List<TodoDto>> Handle(GetAllTodoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                FormattableString sql = $"";
                var getData = await _repository.findAllAsync(sql);
                var mapResult = _mapper.Map<List<TodoDto>>(getData);
                return mapResult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
