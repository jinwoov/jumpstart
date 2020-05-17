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

        }

        public DbSet<Job> Jobs { get; set; }
    }

}
