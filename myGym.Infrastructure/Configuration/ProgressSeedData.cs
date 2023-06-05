using gym.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace gym.Infrastructure.Configuration
{
    public class ProgressSeedData : IEntityTypeConfiguration<TblProgress>
    {
        public void Configure(EntityTypeBuilder<TblProgress> builder)
        {
            builder.HasData
                (

                new TblProgress { Id = 1, Status = "pending", Percentage = 0, Completed = false, Reviewed = false, ReviewBy = "Malik", CreatedBy = "Malik", CreatedDate = DateTime.Now, EdittedBy = "Mus", EdittedDate = DateTime.Now }, 
                new TblProgress { Id = 2, Status = "done", Percentage = 100, Completed = true, Reviewed = false, ReviewBy = "Malik", CreatedBy = "Malik", CreatedDate = DateTime.Now, EdittedBy = "Mus", EdittedDate = DateTime.Now },
                new TblProgress { Id = 3, Status = "done", Percentage = 100, Completed = true, Reviewed = true, ReviewBy = "Malik", CreatedBy = "Malik", CreatedDate = DateTime.Now, EdittedBy = "Mus", EdittedDate = DateTime.Now },
                new TblProgress { Id = 4, Status = "pending", Percentage = 0, Completed = false, Reviewed = false, ReviewBy = "Malik", CreatedBy = "Malik", CreatedDate = DateTime.Now, EdittedBy = "Mus", EdittedDate = DateTime.Now },
                new TblProgress { Id = 5, Status = "progress", Percentage = 50, Completed = false, Reviewed = true, ReviewBy = "Malik", CreatedBy = "Malik", CreatedDate = DateTime.Now, EdittedBy = "Mus", EdittedDate = DateTime.Now }


                ) ;
        }
    }
}
 