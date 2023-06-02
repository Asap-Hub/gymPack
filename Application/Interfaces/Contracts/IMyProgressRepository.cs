using gym.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace gym.Application.Interfaces.Repositories
{
    public class IMyProgressRepository : IGenericBaseRepository<TblProgress>
    {
        public Task<int> createAsync(FormattableString sqlQuery)
        {
            throw new NotImplementedException();
        }

        public Task<int> deleteAsync(FormattableString sqlQuery)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<TblProgress>> findAllAsync(FormattableString sqlQuery)
        {
            throw new NotImplementedException();
        }

        public Task<TblProgress> findByIdAsync(FormattableString sqlQuery)
        {
            throw new NotImplementedException();
        }

        public Task<int> updateAsync(FormattableString sqlQuery)
        {
            throw new NotImplementedException();
        }
    }
}
