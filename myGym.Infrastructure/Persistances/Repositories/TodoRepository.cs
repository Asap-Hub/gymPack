using gym.Application.Interfaces.Repositories;
using gym.Domain.Model;
using gym.Infrastructure.Persistances.ApplicationDBContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace gym.Infrastructure.Persistances.Repositories
{
    public class TodoRepository : GenericBaseRepository<TblMyTodo>, ITodoRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TodoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
