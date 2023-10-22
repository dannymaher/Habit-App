
using Habit_App_Data;
using Habit_App_Data.Repository.IRepository;
using Habit_App_Models;
using Habit_App_Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.Security.Claims;

namespace Habit_App.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            
        }

        public IActionResult Index()
        {
            var ClaimsIdentity = (ClaimsIdentity)User.Identity;
            var UserId = ClaimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            ApplicationUser user = _unitOfWork.ApplicationUsers.GetUserWithHabits(UserId);

            
            
            return View(user);
        }
        public IActionResult Details(int? id)
        {
            var ClaimsIdentity = (ClaimsIdentity)User.Identity;
            var UserId = ClaimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            ApplicationUser user = _unitOfWork.ApplicationUsers.GetUserWithHabitRecords(UserId);
            List<ApplicationUserHabitRecord> list = user.UserHabitRecords;
            //if list is empty will return null. not sure why will fix later

            List<ApplicationUserHabitRecord> result = new List<ApplicationUserHabitRecord> { };

            if (list.IsNullOrEmpty())
            {
               list = new List<ApplicationUserHabitRecord>() { };
                
            }
            else
            {
                list = list.Where(x => x.HabitId == id).ToList();
                result = list.GroupBy(x => x.Date).Select(group => new ApplicationUserHabitRecord
                {
                    Date = group.Key,
                    MeasurementUnit = group.Select(y => y.MeasurementUnit).Sum()
                }).ToList();
            }
            
            
            HomeDetailsVM vm = new HomeDetailsVM()
            {
                Records = list,
                HabitId = id,
                ChartRecords = result
                
            };
            
            return View(vm);
        }

        
        public IActionResult Create(int? id) {

            var ClaimsIdentity = (ClaimsIdentity)User.Identity;
            var UserId = ClaimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            Habit Habit = _unitOfWork.Habits.Get(x => x.Id == id,includeProperties: "UserHabits");
            HomeCreateVM vm = new HomeCreateVM()
            {
                HabitId = id,
                MeasurementUnit = 0,
                UserId = UserId,
                HabitName = Habit.Name
                
            };
            return View(vm);
        
        }
        [HttpPost]
        public IActionResult Create(HomeCreateVM model)
        {
            ApplicationUser user = _unitOfWork.ApplicationUsers.GetUserWithHabitRecords(model.UserId);
            if (user.UserHabitRecords.IsNullOrEmpty())
            {
                user.UserHabitRecords = new List<ApplicationUserHabitRecord>() { };
            }
            Habit habit = _unitOfWork.Habits.Get(x => x.Id == model.HabitId, includeProperties: "UserHabits");
            user.UserHabitRecords.Add(new ApplicationUserHabitRecord()
            {
                Date = DateOnly.FromDateTime(DateTime.Now),
                HabitId = (int)model.HabitId,
                MeasurementUnit = model.MeasurementUnit,
                UserId=user.Id
            });
            _unitOfWork.ApplicationUsers.Update(user);
            _unitOfWork.Save();
            TempData["Success"] = "Record added";
            return RedirectToAction("Details",new {id=model.HabitId});

        }
        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetRecordsByDate(int? id, bool filter = false, int filterDays = 7)
        {
            List<ApplicationUserHabitRecord> result = new List<ApplicationUserHabitRecord> { };
            List<ApplicationUserHabitRecord> list = new List<ApplicationUserHabitRecord> { };
            var ClaimsIdentity = (ClaimsIdentity)User.Identity;
            var UserId = ClaimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            ApplicationUser user = _unitOfWork.ApplicationUsers.GetUserWithHabitRecords(UserId);
            if (user.UserHabitRecords.IsNullOrEmpty())
            {
                return Json(result);
            }
            list = user.UserHabitRecords.Where(x => x.HabitId == id).ToList();
            result = list.GroupBy(x => x.Date).Select(group => new ApplicationUserHabitRecord
            {
                Date = group.Key,
                MeasurementUnit = group.Select(y => y.MeasurementUnit).Sum()
            }).OrderBy(x => x.Date).ToList();
            if (filter)
            {
                result = result.Where(x => x.Date > DateOnly.FromDateTime(DateTime.Now.AddDays(filterDays * -1))).ToList();
            }

            return Json(result);
        }
        
    }
}