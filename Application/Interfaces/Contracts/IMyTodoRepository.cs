using gym.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace gym.Application.Interfaces.Repositories
{
    public class IMyTodoRepository : IGenericBaseRepository<TblMyTodo>
    {
        public Task<int> createAsync(FormattableString sqlQuery)
        {
            throw new NotImplementedException();
        }

        public Task<int> deleteAsync(FormattableString sqlQuery)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<TblMyTodo>> findAllAsync(FormattableString sqlQuery)
        {
            throw new NotImplementedException();
        }

        public Task<TblMyTodo> findByIdAsync(FormattableString sqlQuery)
        {
            throw new NotImplementedException();
        }

        public Task<int> updateAsync(FormattableString sqlQuery)
        {
            throw new NotImplementedException();
        }
    }
}
