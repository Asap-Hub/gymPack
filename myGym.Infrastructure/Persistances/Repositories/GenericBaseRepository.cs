using gym.Application.Interfaces;
using gym.Infrastructure.Persistances.ApplicationDBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym.Infrastructure.Persistances.Repositories
{
    public class GenericBaseRepository<TEntity> : IGenericBaseRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _dbContext;

        public GenericBaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> createAsync(FormattableString sqlQuery)
        {
            var result = await _dbContext.Database.ExecuteSqlInterpolatedAsync(sqlQuery);
            await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<int> deleteAsync(FormattableString sqlQuery)
        {
            var result = await _dbContext.Database.ExecuteSqlInterpolatedAsync(sqlQuery);
            await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<IReadOnlyList<TEntity>> findAllAsync(FormattableString sqlQuery)
        {
            List<TEntity> result = await _dbContext.Set<TEntity>().FromSqlInterpolated(sqlQuery).AsNoTracking().ToListAsync();

            return result;
        }

        public async Task<TEntity> findByIdAsync(FormattableString sqlQuery)
        {
            List<TEntity> result = await _dbContext.Set<TEntity>().FromSqlInterpolated(sqlQuery).AsNoTracking().ToListAsync();

            return result.FirstOrDefault()!;
        }

        public async Task<int> updateAsync(FormattableString sqlQuery)
        {
            var result = await _dbContext.Database.ExecuteSqlInterpolatedAsync(sqlQuery);
            await _dbContext.SaveChangesAsync();
            return result;
        }
    }

}
