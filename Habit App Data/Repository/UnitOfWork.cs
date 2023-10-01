using Habit_App_Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habit_App_Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IApplicationUserRepository ApplicationUserRepository { get; private set; }


        private ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            
            _db = db;
            ApplicationUserRepository = new ApplicationUserRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
