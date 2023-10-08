using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Habit_App_Data.Migrations
{
    /// <inheritdoc />
    public partial class addJoin4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HabitName",
                table: "ApplicationUserHabit",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HabitName",
                table: "ApplicationUserHabit");
        }
    }
}
