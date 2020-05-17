using jumpstartAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jumpstartAPI.Data
{
    public class JumpStartDbContext : DbContext
    {
        public JumpStartDbContext(DbContextOptions<JumpStartDbContext> options) : base (options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserJob>().HasKey(x => new { x.UserID, x.JobID });
        }

        public DbSet<UserJob> UserJob { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Job> Jobs { get; set; }
    }

}
