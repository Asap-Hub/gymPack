using AutoMapper;
using gym.Application.DTOs.ProgressDtos;
using gym.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace gym.Application.Mappers.Progress
{
    public class ProgressMapper : Profile
    {
        public ProgressMapper()
        {

            CreateMap<ProgressMapper, TblProgress>().ReverseMap();
            CreateMap<UpdateProgressDto, TblProgress>().ReverseMap();   
            CreateMap<CreateProgressDto, TblProgress>().ReverseMap();   
        }
    }
}
