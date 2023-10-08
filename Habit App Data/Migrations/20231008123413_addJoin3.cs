using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Habit_App_Data.Migrations
{
    /// <inheritdoc />
    public partial class addJoin3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserHabit_AspNetUsers_UsersId",
                table: "ApplicationUserHabit");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserHabit_Habits_HabitsId",
                table: "ApplicationUserHabit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserHabit",
                table: "ApplicationUserHabit");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUserHabit_UsersId",
                table: "ApplicationUserHabit");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "ApplicationUserHabit");

            migrationBuilder.RenameColumn(
                name: "HabitsId",
                table: "ApplicationUserHabit",
                newName: "HabitId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ApplicationUserHabit",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "ApplicationUserHabit",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AspNetUsersId",
                table: "ApplicationUserHabit",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserHabit",
                table: "ApplicationUserHabit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserHabit_AspNetUsersId",
                table: "ApplicationUserHabit",
                column: "AspNetUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserHabit_HabitId",
                table: "ApplicationUserHabit",
                column: "HabitId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserHabit_AspNetUsers_AspNetUsersId",
                table: "ApplicationUserHabit",
                column: "AspNetUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserHabit_Habits_HabitId",
                table: "ApplicationUserHabit",
                column: "HabitId",
                principalTable: "Habits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserHabit_AspNetUsers_AspNetUsersId",
                table: "ApplicationUserHabit");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserHabit_Habits_HabitId",
                table: "ApplicationUserHabit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserHabit",
                table: "ApplicationUserHabit");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUserHabit_AspNetUsersId",
                table: "ApplicationUserHabit");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUserHabit_HabitId",
                table: "ApplicationUserHabit");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ApplicationUserHabit");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "ApplicationUserHabit");

            migrationBuilder.DropColumn(
                name: "AspNetUsersId",
                table: "ApplicationUserHabit");

            migrationBuilder.RenameColumn(
                name: "HabitId",
                table: "ApplicationUserHabit",
                newName: "HabitsId");

            migrationBuilder.AddColumn<string>(
                name: "UsersId",
                table: "ApplicationUserHabit",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserHabit",
                table: "ApplicationUserHabit",
                columns: new[] { "HabitsId", "UsersId" });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserHabit_UsersId",
                table: "ApplicationUserHabit",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserHabit_AspNetUsers_UsersId",
                table: "ApplicationUserHabit",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserHabit_Habits_HabitsId",
                table: "ApplicationUserHabit",
                column: "HabitsId",
                principalTable: "Habits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
