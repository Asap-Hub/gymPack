using AutoMapper;
using gym.Application.Commands.Progress.Requests;
using gym.Application.DTOs.ProgressDtos;
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
    public class GetProgressByIdCommand : IRequestHandler<GetProgressByIdRequest, ProgressDto>
    {
        private readonly IProgressRepository _repository;
        private readonly IMapper _mapper;

        public GetProgressByIdCommand(IProgressRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ProgressDto> Handle(GetProgressByIdRequest request, CancellationToken cancellationToken)
        {
            try
            {
                FormattableString sql = $"";
                var GetById = await _repository.findByIdAsync(sql);

                var result = _mapper.Map<ProgressDto>(GetById);
                return result;
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
