using AutoMapper;
using gym.Application.Commands.Progress.Requests;
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
    public class UpdateProgressCommandHandler : IRequestHandler<UpdatedProgressCommand, Unit>
    {
        private readonly IProgressRepository _repository;
        private readonly IMapper _mapper;

        public UpdateProgressCommandHandler(IProgressRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdatedProgressCommand request, CancellationToken cancellationToken)
        {
            try 
            {
                var dto = request.UpdateProgressDto;
                var Entity = new TblProgress();
                var Data = _mapper.Map(dto, Entity);

                FormattableString sql = $"";

                var updateProgress = await _repository.updateAsync(sql);
                return Unit.Value;
                                
            
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
