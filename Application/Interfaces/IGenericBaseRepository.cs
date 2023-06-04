using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace gym.Application.Interfaces
{
    public interface IGenericBaseRepository<TEntity> where TEntity : class
    {
        Task<int> createAsync(FormattableString sqlQuery);
        Task<int> updateAsync(FormattableString sqlQuery);
        Task<int> deleteAsync(FormattableString sqlQuery);
        Task<TEntity> findByIdAsync(FormattableString sqlQuery);
        Task<IReadOnlyList<TEntity>> findAllAsync(FormattableString sqlQuery);
    }
}
