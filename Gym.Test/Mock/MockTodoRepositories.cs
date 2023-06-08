using gym.Application.DTOs.TodoDtos;
using gym.Application.Interfaces.Repositories;
using gym.Domain.Model;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Test.Mock
{
  
    public static class MockTodoRepositories
    {

        public static  Mock<ITodoRepository> GetTodoRepository() 
        {

            var todoData = new List<TblMyTodo>
            {
                new TblMyTodo {
                    TodoId = 1, 
                    Title = "task 2",
                    Note = "finish hard 2",
                    StartDate = DateTime.Now,
                    EndDate = new DateTime(2023-80-10),
                    CreatedBy = "Instructor Malik", 
                    EdittedBy = "Asap", 
                },
                 new TblMyTodo {
                    TodoId = 2,
                    Title = "task 1",
                    Note = "finish hard",
                    StartDate = DateTime.Now,
                    EndDate = new DateTime(2023-30-10),
                    CreatedBy = "Instructor Malik",
                    EdittedBy = "Dasty",
                },


            };
            FormattableString sql = $"";
             
            var mockRepo = new Mock<ITodoRepository>();


            mockRepo.Setup(m => m.findAllAsync(sql)).ReturnsAsync(todoData);


            mockRepo.Setup(m => m.createAsync(sql)).ReturnsAsync((TblMyTodo data) =>
            {
                todoData.Add(data);
                
                return 0;
            });


            return mockRepo;

        }


    }
}
