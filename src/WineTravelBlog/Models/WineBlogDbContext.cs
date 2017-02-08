using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WineTravelBlog.Models
{
    public class WineBlogDbContext: DbContext
    {
        public WineBlogDbContext()
        {

        }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Winery> Wineries { get; set; }
        public DbSet<Wine> Wines { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database = WineTravelBlog; integrated security = True");
        }
        public WineBlogDbContext(DbContextOptions<WineBlogDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
