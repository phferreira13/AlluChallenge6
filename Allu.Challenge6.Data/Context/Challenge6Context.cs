using Allu.Challenge6.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Allu.Challenge6.Data.Context
{
    public class Challenge6Context : DbContext
    {
        public Challenge6Context(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Tutor> Tutores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
