using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WinYoungUI.Models.Entities;

namespace WinYoungUI.Models
{
    public class WinYoungContext : IdentityDbContext<User>
    {
        public WinYoungContext(DbContextOptions<WinYoungContext> options) : base(options)
        {

        }

        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet<SiteSetting> SiteSettings { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<ContentCategory> ContentCategories { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
