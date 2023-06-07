using AutoMapper;
using gym.Application.Commands.Todo.Handlers;
using gym.Application.Commands.Todo.Requests;
using gym.Application.DTOs.TodoDtos;
using gym.Application.Interfaces.Repositories;
using gym.Application.Mappers.Identity;
using gym.Application.Mappers.Todo;
using Gym.Test.Mock;
using Microsoft.Exchange.WebServices.Data;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Gym.Test.Todo.Queries
{
    public class GetAllTodoRequestHandlerTest
    {
        private readonly Mock<ITodoRepository>  _mockRepo;

        private readonly IMapper _mapper;
        public GetAllTodoRequestHandlerTest()
        {
            _mockRepo = MockTodoRepositories.GetTodoRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MyTodoMapper>();
            });

            _mapper = mapperConfig.CreateMapper();
        }


        [Fact]
        public   async Task<List<TodoDto>> GetAllTodoTes()
        {
            var handler = new GetAllTodoRequestHandler(_mockRepo.Object ,_mapper);

            var result =   await handler.Handle(new GetAllTodoRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<TodoDto>>();

              //result.Count.ShouldBe(0);
              Assert.Equal(0, result.Count);    

            return result;
        }


    }
}
