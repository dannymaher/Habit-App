using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Habit_App.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class UserManageController : Controller
    {
        public UserManageController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
