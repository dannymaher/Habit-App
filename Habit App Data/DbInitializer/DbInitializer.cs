
using Habit_App_Models;

using Habit_App_Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habit_App_Data.DbInitializer
{

    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private ApplicationDbContext _context;

        public DbInitializer(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public async void Initialize()
        {
            //If migrations exist then migrate
            try
            {
                if (_context.Database.GetPendingMigrations().Count() > 0)
                {
                    _context.Database.Migrate();
                }
            }
            catch(Exception ex) {

            }

            //create roles if they dont exist
            if(!_roleManager.RoleExistsAsync(SD.ROLE_ADMIN).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(SD.ROLE_ADMIN)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.ROLE_USER)).GetAwaiter().GetResult();

                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "Admin1@gmail.com",
                    Email = "Admin1@gmail.com",

                }, "Admin!123").GetAwaiter().GetResult();
                ApplicationUser user = _context.Users.FirstOrDefault(u => u.Email == "Admin1@gmail.com");
                _userManager.AddToRoleAsync(user, SD.ROLE_ADMIN).GetAwaiter().GetResult();
                
            }
        }
    }
}
