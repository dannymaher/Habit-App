using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Habit_App_Models.ViewModels
{
    public class RoleManagementVM
    {
        public ApplicationUser User { get; set; }
        public IEnumerable<SelectListItem> RoleList { get; set; }
        public string currentRole { get; set; }
    }
}
