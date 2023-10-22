using Habit_App_Data;
using Habit_App_Data.Repository;
using Habit_App_Data.Repository.IRepository;
using Habit_App_Models;
using Habit_App_Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Habit_App.Areas.User.Controllers
{
    [Area("User")]
    public class HabitController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ApplicationDbContext _context;

        public HabitController(IUnitOfWork unitOfWork, ApplicationDbContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Habit> AllHabits = _unitOfWork.Habits.GetAll();
            var ClaimsIdentity = (ClaimsIdentity)User.Identity;
            var UserId = ClaimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            ApplicationUser user = _unitOfWork.ApplicationUsers.GetUserWithHabits(UserId);
            List<HabitIndexVM> HabitVMList = new();
            int counter = 0;
            foreach(var habit in AllHabits)
            {
                bool isSubbed = false;
                if(counter < user.UserHabits.Count())
                {
                    if (AllHabits.Contains(user.UserHabits[counter].Habit))
                    {
                        isSubbed = true;
                    }
                }
                
                
                HabitVMList.Add(new() {
                    Id = habit.Id,
                    isSubscribed = isSubbed,
                    Name = habit.Name,
                    Measurement = habit.Measurement
                    
                });
                
                counter++;
            }
            
            return View(HabitVMList);
        }

        public IActionResult Details(Habit habit) {
            return View(habit);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Habit habit)
        {
            _unitOfWork.Habits.Add(habit);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            Habit habit = _unitOfWork.Habits.Get(x => x.Id == id);
            return View(habit);
        }
        [HttpPost]
        public IActionResult Edit(Habit habit)
        {
            _unitOfWork.Habits.Update(habit);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        
        public IActionResult Add(int? id)
        {
            Habit habit = _unitOfWork.Habits.Get(x => x.Id == id);
            var ClaimsIdentity = (ClaimsIdentity)User.Identity;
            var UserId = ClaimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            ApplicationUser user = _unitOfWork.ApplicationUsers.Get(x => x.Id == UserId, includeProperties: "UserHabits");
            ApplicationUserHabit applicationUserHabit = new(){
                Habit = habit,
                UserId = UserId,
                HabitId = habit.Id,
                User = user
            };
            user.UserHabits.Add(applicationUserHabit);
               
                

            
           
            
   
                
            
            _unitOfWork.ApplicationUsers.Update(user);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
        
        public IActionResult Remove(int? id)
        {
            Habit habits = _unitOfWork.Habits.Get(x => x.Id == id);
            var ClaimsIdentity = (ClaimsIdentity)User.Identity;
            var UserId = ClaimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            
            ApplicationUser user = _unitOfWork.ApplicationUsers.GetUserWithHabits(UserId);
            user.UserHabits = user.UserHabits.Where(x => x.HabitId != id).ToList();
            _unitOfWork.ApplicationUsers.Update(user);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}

