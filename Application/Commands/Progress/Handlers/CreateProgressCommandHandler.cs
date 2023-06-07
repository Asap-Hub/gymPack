using AutoMapper;
using gym.Application.Commands.Progress.Requests;
using gym.Application.Extentions.Exceptions;
using gym.Application.Interfaces.Repositories;
using gym.Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace gym.Application.Commands.Progress.Handlers
{
    public class CreateProgressCommandHandler : IRequestHandler<CreateProgressCommand, int>
    {
        private readonly IProgressRepository _repository;
        private readonly IMapper _mapper;

        public CreateProgressCommandHandler(IProgressRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateProgressCommand request, CancellationToken cancellationToken)
        { 
            try
            {
                var dto = request.CreateProgressDto;
                var Entity = new TblProgress();
                var Data = _mapper.Map(dto, Entity);


                FormattableString sql = $"";
                var CreateProgress = await _repository.createAsync(sql);
                return CreateProgress;
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
