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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
