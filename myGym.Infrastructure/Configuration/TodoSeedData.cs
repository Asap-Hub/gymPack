using gym.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace gym.Infrastructure.Configuration
{
    internal class TodoSeedData : IEntityTypeConfiguration<TblMyTodo>
    {
        public void Configure(EntityTypeBuilder<TblMyTodo> builder)
        {
            builder.HasData(

                new TblMyTodo { Id = 2, Title = "task 1", Note = "finish hard", StartDate = DateTime.Now, EndDate = new DateTime(2023-80-10), CreatedBy = "Instructor Malik", CreatedDate = DateTime.Now, EdittedBy = "Asap", EdittedDate = DateTime.Now },
                new TblMyTodo { Id = 3, Title = "task 2", Note = "finish hard", StartDate = DateTime.Now, EndDate = new DateTime(2023-7-10), CreatedBy = "Instructor Malik", CreatedDate = DateTime.Now, EdittedBy = "Asap", EdittedDate = DateTime.Now },
                new TblMyTodo { Id = 4, Title = "task 3", Note = "finish hard", StartDate = DateTime.Now, EndDate = new DateTime(2023-10-10), CreatedBy = "Instructor Malik", CreatedDate = DateTime.Now, EdittedBy = "Asap", EdittedDate = DateTime.Now },
                new TblMyTodo { Id = 5, Title = "task 4", Note = "finish hard", StartDate = DateTime.Now, EndDate = new DateTime(2023-10-16), CreatedBy = "Instructor Malik", CreatedDate = DateTime.Now, EdittedBy = "Asap", EdittedDate = DateTime.Now },
                new TblMyTodo { Id = 6, Title = "task 5", Note = "finish hard", StartDate = DateTime.Now, EndDate = new DateTime(2023-10-18), CreatedBy = "Instructor Malik", CreatedDate = DateTime.Now, EdittedBy = "Asap", EdittedDate = DateTime.Now }
                );
        }
    }
}
 