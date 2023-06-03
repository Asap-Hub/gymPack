using AutoMapper;
using gym.Application.DTOs.Common;
using gym.Application.DTOs.TodoDtos;
using gym.Domain.Common;
using gym.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace gym.Application.Mappers.Todo
{
    public class MyTodoMapper : Profile
    {
        public MyTodoMapper()
        {

            CreateMap<TodoDto, TblMyTodo>().ReverseMap();
            CreateMap<CreateTodoDto, TblMyTodo>().ReverseMap();
        }
    }
}
