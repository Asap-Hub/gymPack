using AutoMapper;
using gym.Application.DTOs.Identity;
using gym.Application.Extentions.IdentityExtension;
using System;
using System.Collections.Generic;
using System.Text;

namespace gym.Application.Mappers.Identity
{
    public class UserMapper:Profile
    {
        public UserMapper()
        {
            CreateMap<CreateUserDto, User>().ReverseMap();
        }
    }
}
