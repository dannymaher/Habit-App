using Habit_App_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habit_App_Data.Repository.IRepository
{
    public interface IHabitRepository : IRepository<Habit>
    {
        void Update(Habit habit);
    }
}
