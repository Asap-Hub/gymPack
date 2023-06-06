using AutoMapper;
using gym.Application.Commands.Todo.Requests;
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
        private readonly ILogger _logger;

        public UpdateTodoComandHandler(IGenericBaseRepository<TblMyTodo> repository, IMapper mapper, ILogger logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Unit> Handle(UpdateTodoComand request, CancellationToken cancellationToken)
        {
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
                 _logger.LogInformation(ex.Message);

                return Unit.Value;
                //throw new Exception(ex.Message);
            }
        }
    }
}
