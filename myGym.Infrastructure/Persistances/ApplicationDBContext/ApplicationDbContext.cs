using gym.Application.Extentions.IdentityExtension;
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

namespace gym.Infrastructure.Persistances.ApplicationDBContext
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<TblMyTodo> tblMyTodo { get; set; }
        public DbSet<TblProgress> tblProgress { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);


           base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TblMyTodo>(
                entity =>
                {
                    entity.HasKey(entity => entity.TodoId);
                    entity.ToTable("tblMyTodo");
                }
                );


            modelBuilder.Entity<TblProgress>(
                entity => 
                { 
                    entity.HasKey(entity => entity.ProgressId);
                    entity.ToTable("tblProgress");
                }
                );

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

    }
}
