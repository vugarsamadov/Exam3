using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam3.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Exam3.Infrastructure.Configurations;
using Microsoft.Extensions.Configuration;

namespace Exam3.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<TeamMember> TeamMembers { get; set; }
        private IConfiguration _configuration { get; }

        public ApplicationDbContext(DbContextOptions options,IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("MSSQL"));
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(SocialMediaConfig).Assembly);
            base.OnModelCreating(builder);
        }

    }
}
