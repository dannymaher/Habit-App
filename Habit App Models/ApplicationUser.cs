

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Habit_App_Models
{
    public class ApplicationUser : IdentityUser
    {
        //[ValidateNever ]
        public List<ApplicationUserHabit> UserHabits { get; set; }
        public List<ApplicationUserHabitRecord> UserHabitRecords { get; set; }

        [NotMapped]
        public string Role { get; set; }
    }

}