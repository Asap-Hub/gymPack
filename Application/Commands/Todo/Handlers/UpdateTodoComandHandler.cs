using AutoMapper;
using FluentValidation;
using gym.Application.Commands.Todo.Requests;
using gym.Application.DTOs.TodoDtos;
using gym.Application.Extentions.Exceptions;
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
    public class UpdateTodoComandHandler : IRequestHandler<UpdateTodoComand, Unit>
    {
        private readonly IGenericBaseRepository<TblMyTodo> _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateTodoDto> _validator;

        public UpdateTodoComandHandler(IGenericBaseRepository<TblMyTodo> repository, IMapper mapper, IValidator<UpdateTodoDto> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task<Unit> Handle(UpdateTodoComand request, CancellationToken cancellationToken)
        {
            var validateTodo = await _validator.ValidateAsync(request.updateDto);

            if (!validateTodo.IsValid) 
            {
                throw new ValidException(validateTodo);
            }

            try
            {
                var dto = request.updateDto;
                var entity = new TblMyTodo();
                var data = _mapper.Map(dto, entity);
                FormattableString sql = $"";


                var updateDto = await _repository.updateAsync(sql);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                 
            }
        }
    }
}
