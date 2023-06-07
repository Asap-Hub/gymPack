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
    public class GetAllProgressCommandHandler : IRequestHandler<GetAllProgressCommand, List<ProgressDto>>
    {
        private readonly IProgressRepository _repository;
        private readonly IMapper _mapper;

        public GetAllProgressCommandHandler(IProgressRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<ProgressDto>> Handle(GetAllProgressCommand request, CancellationToken cancellationToken)
        {
            try
            {
                FormattableString sql = $"";   
                var getAllData = await _repository.findAllAsync(sql);

                var Data = _mapper.Map<List<ProgressDto>>(getAllData);
                return Data;
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
