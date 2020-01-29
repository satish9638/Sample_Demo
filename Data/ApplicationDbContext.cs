using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sample_Test.Models;

namespace Sample_Test.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opts) : base(opts)
        {
        }

        public DbSet<Buyer> Buyer { get; set; }
        public DbSet<Event> Event { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {            
            base.OnModelCreating(builder);
        }
    }
}
