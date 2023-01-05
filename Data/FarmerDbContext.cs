using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using crowdfarming.Models.Domains;

namespace crowdfarming.Data
{
    public class FarmerDbContext : DbContext
    {
        public FarmerDbContext(DbContextOptions<FarmerDbContext> options) : base(options)
        {
        }

        public DbSet<Farmer> Farmers { get; set; }
        public DbSet<Investor> Investors { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Investment> Investments { get; set; }
    }
}