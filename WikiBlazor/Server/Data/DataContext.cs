using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WikiBlazor.Shared.Models;

namespace WikiBlazor.Server.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Article> Articles { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Test"},
                new Category { Id = 2, Name = "Fish"},
                new Category { Id = 3, Name = "Art"}
            );

            modelBuilder.Entity<Category>().Ignore(c => c.Articles);

            modelBuilder.Entity<Article>().HasData(
                new Article
                {
                    Id = 1,
                    Title = "Fish (singer)",
                    Url = "https://en.wikipedia.org/wiki/Fish_(singer)"
                },
                new Article
                {
                    Id = 2,
                    Title = "The Art of Unit Testing",
                    Url = "https://en.wikipedia.org/wiki/The_Art_of_Unit_Testing"
                }
            );

            modelBuilder.Entity<Article>()
                .HasMany(a => a.Categories)
                .WithMany(c => c.Articles)
                .UsingEntity<Dictionary<string, object>>("ArticleCategory",
                    r => r.HasOne<Category>().WithMany().HasForeignKey("CategoryId"),
                    l => l.HasOne<Article>().WithMany().HasForeignKey("ArticleId"),
                    joinEntityType =>
                    {
                        joinEntityType.HasKey("ArticleId", "CategoryId");
                        joinEntityType.HasData(
                            new { ArticleId = 1L, CategoryId = 2L },
                            new { ArticleId = 1L, CategoryId = 3L },
                            new { ArticleId = 2L, CategoryId = 1L },
                            new { ArticleId = 2L, CategoryId = 3L }
                        );
                    });
        }
    }
}