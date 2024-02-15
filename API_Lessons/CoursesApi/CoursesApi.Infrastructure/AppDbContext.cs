using CoursesApi.Core.Entities;
using CoursesApi.Infrastructure.Initializers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApi.Infrastructure
{
    internal class AppDbContext : DbContext
    {
        public AppDbContext() : base() { }
        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Tutor>().HasIndex(e => e.Email).IsUnique(true);
            modelBuilder.Entity<Course>().HasIndex(n => n.Name).IsUnique(true);
            modelBuilder.Entity<Category>().HasIndex(n => n.Name).IsUnique(true);

            modelBuilder.SeedCourse();
            modelBuilder.SeedCategory();
            modelBuilder.SeedTutor();
        }

        public DbSet<Course> Course { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Tutor> Tutor { get; set; }
    }
}
