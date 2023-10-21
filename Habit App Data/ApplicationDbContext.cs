using Habit_App_Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

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
        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");
        }
        /// <summary>
        /// Converts <see cref="DateOnly" /> to <see cref="DateTime"/> and vice versa.
        /// </summary>
        public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
        {
            /// <summary>
            /// Creates a new instance of this converter.
            /// </summary>
            public DateOnlyConverter() : base(
                    d => d.ToDateTime(TimeOnly.MinValue),
                    d => DateOnly.FromDateTime(d))
            { }
        }
    }
}