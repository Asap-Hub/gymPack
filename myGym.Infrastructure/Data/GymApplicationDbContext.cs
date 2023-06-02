
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace gym.Infrastructure.Data
{
    public class GymApplicationDbContext:IdentityDbContext<IdentityUser>
    {
        public GymApplicationDbContext(DbContextOptions<GymApplicationDbContext> options):base(options)
        {
            
        }
    }
}
