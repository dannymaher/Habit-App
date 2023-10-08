using Habit_App_Data.Repository.IRepository;
using Habit_App_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habit_App_Data.Repository
{
    public class HabitRepository : Repository<Habit>, IHabitRepository
    {
        private ApplicationDbContext _context;

        public HabitRepository(ApplicationDbContext context) :base(context) 
        {
            _context = context;
        }

        public void Update(Habit habit)
        {
            _context.Update(habit);
        }
    }
}
