using AutoMapper;
using FluentValidation;
using gym.Application.Commands.Todo.Requests;
using gym.Application.DTOs.TodoDtos;
using gym.Application.Extentions.Exceptions;
using gym.Application.Extentions.Responses;
using gym.Application.Interfaces.Repositories;
using gym.Domain.Model;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace gym.Application.Commands.Todo.Handlers
{
    public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, int>
    {
        private readonly ITodoRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateTodoDto> _validate;

        public CreateTodoCommandHandler(ITodoRepository repository, IMapper mapper, IValidator<CreateTodoDto> validate )
        {
            _repository = repository;
            _mapper = mapper;
            _validate = validate;
        }
        public async Task<int> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            var validateUser = await _validate.ValidateAsync(request.createDto);

            if(!validateUser.IsValid)
            {
                throw new ValidException(validateUser);
            }
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
