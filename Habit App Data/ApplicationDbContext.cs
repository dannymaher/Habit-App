using Habit_App_Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Habit_App_Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<ApplicationUser> Users { get;set; }
        public DbSet<Habit> Habits { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ApplicationUser>().HasMany(e => e.Habits).WithMany(e => e.Users);
            //modelBuilder.Entity<Habit>().HasMany(e => e.Users).WithMany(e => e.Habits);
            base.OnModelCreating(modelBuilder);
        }
    }
}