using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace WinYoungUI.Models
{
    public class WinYoungContext : DbContext
    {
        public WinYoungContext(DbContextOptions<WinYoungContext> options) : base(options)
        {

        }

        public DbSet<NewsLetter> NewsLetters { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NewsLetter>().ToTable("NewsLetter");
        }
    }
}
