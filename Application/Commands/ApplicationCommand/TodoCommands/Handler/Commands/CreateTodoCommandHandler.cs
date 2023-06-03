using AutoMapper;
using gym.Application.Interfaces.Repositories;
using gym.Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using gym.Application.DTOs.TodoDtos;
using System.Threading.Tasks;
using System.Threading;
using gym.Application.Commands.ApplicationCommand.TodoCommands.Requests;

namespace gym.Application.Commands.ApplicationCommand.TodoCommands.Handler.Commands
{


    public class CreateMyTodoCommandHandler : IRequestHandler<CreateMyTodoCommand, int>
    {
        private readonly IGenericBaseRepository<TblMyTodo> _baseRepository;
        private readonly IMapper _mapper;

        public CreateMyTodoCommandHandler(IGenericBaseRepository<TblMyTodo> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateMyTodoCommand request, CancellationToken cancellationToken)
        {
            var entity = new TblMyTodo();
            FormattableString sql = $"";
            var createResponse = await _baseRepository.createAsync(sql);
            var result = _mapper.Map(createResponse, entity);
            return result.Id;
        }
    }
}

