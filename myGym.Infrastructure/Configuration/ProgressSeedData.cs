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

                new TblProgress { ProgressId = 1, Status = "pending", Percentage = 0, Completed = false, Confirmed = false, ConfirmedBy = "Instructor Malik", CreatedBy = "Asap", CreatedDate = new DateTime(2023-02-18), EdittedBy = "Asap", EdittedDate = DateTime.Now }, 
                new TblProgress { ProgressId = 2, Status = "done", Percentage = 100, Completed = true, Confirmed = false, ConfirmedBy = "Instructor Malik", CreatedBy = "Asap", CreatedDate = new DateTime(2023-03-28), EdittedBy = "Asap", EdittedDate = DateTime.Now },

                new TblProgress { ProgressId = 3, Status = "done", Percentage = 100, Completed = true, Confirmed = true, ConfirmedBy = "Instructor Malik", CreatedBy = "Asap", CreatedDate = new DateTime(2023-03-18), EdittedBy = "Asap", EdittedDate = DateTime.Now },

                new TblProgress { ProgressId = 4, Status = "pending", Percentage = 0, Completed = false, Confirmed = false, ConfirmedBy = "Instructor Malik", CreatedBy = "Asap", CreatedDate = new DateTime(2023-03-18), EdittedBy = "Asap", EdittedDate = DateTime.Now },

                new TblProgress { ProgressId = 5, Status = "progress", Percentage = 50, Completed = false, Confirmed = true, ConfirmedBy = "Instructor Malik", CreatedBy = "Asap", CreatedDate = new DateTime(2023-02-28), EdittedBy = "Asap", EdittedDate = DateTime.Now }


                ) ;
        }
    }
}
 