using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habit_App_Models.ViewModels
{
    public class HomeCreateVM
    {
        public int? HabitId { get; set; }
        public string HabitName { get; set; }
        public string UserId { get; set; }
        [Required]
        public float MeasurementUnit { get; set; }
        
    }
}
