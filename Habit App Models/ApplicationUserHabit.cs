using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habit_App_Models
{
    public class ApplicationUserHabit
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        public int HabitId { get; set; }
        [ForeignKey("HabitId")]
        public Habit Habit { get; set; }

       

    }
}
