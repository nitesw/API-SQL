using Microsoft.EntityFrameworkCore;
using NewsApi.Core.Entities;
using NewsApi.Infrastructure.Initializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Infrastructure
{
    internal class AppDbContext : DbContext
    {
        public AppDbContext() : base() { }
        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Author>().HasIndex(c => c.Username).IsUnique(true);

            modelBuilder.SeedCategory();
            modelBuilder.SeedNews();
            modelBuilder.SeedAuthor();
            modelBuilder.SeedStatistics();
            modelBuilder.SeedRole();
            modelBuilder.SeedUser();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Statistics> Statistics { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }
    }
}
