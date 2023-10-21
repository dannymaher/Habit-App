using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habit_App_Models
{
    public class Habit
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Measurement { get; set; }

        public List<ApplicationUserHabit> UserHabits { get; set; }
        public List<ApplicationUserHabitRecord> RecordHabits { get; set;}
    }
}
