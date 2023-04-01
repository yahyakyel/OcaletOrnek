using Microsoft.EntityFrameworkCore;

namespace Writer.API.Models
{
    public class WritersDBContext : DbContext
    {
        public WritersDBContext(DbContextOptions<WritersDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Writer>().ToTable("Writer");
        }
        public DbSet<Writer> Writers { get; set; }

    }

}
