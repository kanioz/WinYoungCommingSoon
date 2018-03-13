using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WinYoungUI.Models.Entities;

namespace WinYoungUI.Models
{
    public class DbInitializer : IDbInitializer
    {
        private readonly WinYoungContext _context;
        private readonly UserManager<User> _userManager;
        
        public DbInitializer(WinYoungContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async void Initialize()
        {
            var migrations = _context.Database.GetPendingMigrations();
            if (migrations.Any())
            {
                _context.Database.Migrate();
            }
            if (await _context.Users.SingleOrDefaultAsync(u => u.UserName == "Admin") == null)
            {

                var result = await _userManager.CreateAsync(new User
                {
                    UserName = "Admin",
                    Email = "emre.ozbey@wy.com.tr",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    NormalizedUserName = "Admin",
                    NormalizedEmail = "emre.ozbey@wy.com.tr"
                }, "WinYoung2018!");
                if (!result.Succeeded)
                    throw new Exception(string.Join(Environment.NewLine, result.Errors));
            }
        }
    }
}
