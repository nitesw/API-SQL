using Microsoft.EntityFrameworkCore;
using NewsApi.Core.Entities;
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

        public DbSet<Category> Categories { get; set; }
        public DbSet<News> News { get; set; }
    }
}
