using AutoMapper;
using gym.Application.Commands.Todo.Requests;
using gym.Application.DTOs.TodoDtos;
using gym.Application.Interfaces;
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
        private readonly IGenericBaseRepository<TodoDto> _repository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetAllTodoRequestHandler(IGenericBaseRepository<TodoDto> repository, IMapper mapper, ILogger logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
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
                _logger.LogInformation(ex.Message);
                return null;
            }
        }
    }
}
