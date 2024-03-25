using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infrastructure.Persistence.PostgreSQL
{
    public class AppPostgreSQLDbContext : DbContext
    {
        public AppPostgreSQLDbContext(DbContextOptions<AppPostgreSQLDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().ToTable("MyStudentsTable");
            modelBuilder.Entity<Student>().HasKey(q => q.Id);
        }
    }
}
