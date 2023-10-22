using Habit_App_Data.Repository;
using Habit_App_Data.Repository.IRepository;
using Habit_App_Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Habit_App.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class UserManageController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUnitOfWork _unitOfWork;
        

        public UserManageController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult RoleManagement(int? id)
        {

            return View();
        }
        #region API Calls
        [HttpGet]
        public IActionResult GetAll()
        {
            List<ApplicationUser> objUserList = _unitOfWork.ApplicationUsers.GetAll().ToList();

            foreach (var user in objUserList)
            {

                user.Role = _userManager.GetRolesAsync(user).GetAwaiter().GetResult().FirstOrDefault();

                
            }

            return Json(new { data = objUserList });
        }


        [HttpPost]
        public IActionResult LockUnlock([FromBody] string id)
        {

            var objFromDb = _unitOfWork.ApplicationUsers.Get(u => u.Id == id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while Locking/Unlocking" });
            }

            if (objFromDb.LockoutEnd != null && objFromDb.LockoutEnd > DateTime.Now)
            {
                //user is currently locked and we need to unlock them
                objFromDb.LockoutEnd = DateTime.Now;
                _unitOfWork.ApplicationUsers.Update(objFromDb);
                _unitOfWork.Save();
                return Json(new { success = true, message = "Unlock successful" });

            }
            else
            {
                objFromDb.LockoutEnd = DateTime.Now.AddYears(1000);
                _unitOfWork.ApplicationUsers.Update(objFromDb);
                _unitOfWork.Save();
                return Json(new { success = true, message = "Lock successful" });
            }



        }

        #endregion
    }
}
