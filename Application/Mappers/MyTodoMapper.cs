using AutoMapper;
using gym.Application.DTOs;
using gym.Application.DTOs.Common;
using gym.Domain.Common;
using gym.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace gym.Application.Mappers
{
    public class MyTodoMapper:Profile
    {
        public MyTodoMapper()
        {
          
            CreateMap<MyTodoDto, TblMyTodo>().ReverseMap();
        }
    }
}
