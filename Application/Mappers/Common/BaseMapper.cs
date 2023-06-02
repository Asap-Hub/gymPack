using AutoMapper;
using gym.Application.DTOs.Common;
using gym.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace gym.Application.Mappers.Common
{
    public class BaseMapper : Profile
    {
        public BaseMapper()
        {
            CreateMap<BaseDto, BaseDomain>().ReverseMap();
        }
    }
}
