using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Article.API.Models
{
    public class ArticlesDBContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }

        public ArticlesDBContext(DbContextOptions<ArticlesDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().ToTable("Article");
        }
    }
}
