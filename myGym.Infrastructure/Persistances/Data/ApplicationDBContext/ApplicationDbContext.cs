using gym.Domain.Common;
using gym.Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace gym.Infrastructure.Persistances.Data.ApplicationDBContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entries in ChangeTracker.Entries<BaseDomain>())
            {
                entries.Entity.EdittedDate = DateTime.Now;
                if (entries.State == EntityState.Added)
                {

                    entries.Entity.CreatedDate = DateTime.Now;
                }

            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<TblMyTodo> tblMyTodo { get; set; }
        public DbSet<TblProgress> tblProgress { get; set; }
    }
}
