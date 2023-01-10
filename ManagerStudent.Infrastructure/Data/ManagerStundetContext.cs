using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ManagerStudent.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ManagerStudent.Infrastructure.SeedData;

namespace ManagerStudent.Infrastructure.Data
{
    public class ManagerStundetContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Score> Scores { get; set; }

        public ManagerStundetContext(DbContextOptions<ManagerStundetContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
           // SeedData.SeedData.Seed(modelBuilder);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);

            configurationBuilder.Properties<string>().HaveMaxLength(30);
            configurationBuilder.Properties<DateTime>().HaveColumnType("date");
            configurationBuilder.Properties<Char>().HaveColumnType("Char(1)");
        }
    }

   
}
