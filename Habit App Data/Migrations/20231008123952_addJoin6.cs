using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Habit_App_Data.Migrations
{
    /// <inheritdoc />
    public partial class addJoin6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "ApplicationUserHabit",
                newName: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ApplicationUserHabit",
                newName: "ApplicationUserId");
        }
    }
}
