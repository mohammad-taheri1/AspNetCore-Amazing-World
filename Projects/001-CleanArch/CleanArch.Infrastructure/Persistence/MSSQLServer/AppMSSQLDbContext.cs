using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infrastructure.Persistence.MSSQLServer
{
    public class AppMSSQLDbContext : DbContext
    {
        public AppMSSQLDbContext(DbContextOptions<AppMSSQLDbContext> options) : base(options)
        {
        }

        public DbSet<Student>  Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<Student>().HasKey(q => q.Id);
        }
    }
}
