using Habit_App_Data.Repository.IRepository;
using Habit_App_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habit_App_Data.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private ApplicationDbContext _context;
        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _context = db;
        }
        public void Update(ApplicationUser user)
        {
            _context.Update(user);
        }
        public ApplicationUser GetUserWithHabits(string userId)
        {
            return _context.Users.Include(c => c.UserHabits).ThenInclude(u => u.Habit).Where(x => x.Id == userId).FirstOrDefault();

        }
    }
}
