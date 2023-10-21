using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Habit_App_Models.ViewModels
{
    public class HomeDetailsVM
    {
        public int? HabitId { get;set; }
        public List<ApplicationUserHabitRecord> Records { get; set; }
        public List<ApplicationUserHabitRecord> ChartRecords { get; set; }
        
    }
}
