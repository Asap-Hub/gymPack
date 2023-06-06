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

                new TblProgress { Id = 1, Status = "pending", Percentage = 0, Completed = false, Confirmed = false, ConfirmedBy = "Instructor Malik", CreatedBy = "Asap", CreatedDate = DateTime.Now, EdittedBy = "Asap", EdittedDate = DateTime.Now }, 
                new TblProgress { Id = 2, Status = "done", Percentage = 100, Completed = true, Confirmed = false, ConfirmedBy = "Instructor Malik", CreatedBy = "Asap", CreatedDate = DateTime.Now, EdittedBy = "Asap", EdittedDate = DateTime.Now },

                new TblProgress { Id = 3, Status = "done", Percentage = 100, Completed = true, Confirmed = true, ConfirmedBy = "Instructor Malik", CreatedBy = "Asap", CreatedDate = DateTime.Now, EdittedBy = "Asap", EdittedDate = DateTime.Now },

                new TblProgress { Id = 4, Status = "pending", Percentage = 0, Completed = false, Confirmed = false, ConfirmedBy = "Instructor Malik", CreatedBy = "Asap", CreatedDate = DateTime.Now, EdittedBy = "Asap", EdittedDate = DateTime.Now },

                new TblProgress { Id = 5, Status = "progress", Percentage = 50, Completed = false, Confirmed = true, ConfirmedBy = "Instructor Malik", CreatedBy = "Asap", CreatedDate = DateTime.Now, EdittedBy = "Asap", EdittedDate = DateTime.Now }


                ) ;
        }
    }
}
 