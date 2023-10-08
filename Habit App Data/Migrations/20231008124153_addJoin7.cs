using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Habit_App_Data.Migrations
{
    /// <inheritdoc />
    public partial class addJoin7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserHabit_AspNetUsers_AspNetUsersId",
                table: "ApplicationUserHabit");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUserHabit_AspNetUsersId",
                table: "ApplicationUserHabit");

            migrationBuilder.DropColumn(
                name: "AspNetUsersId",
                table: "ApplicationUserHabit");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ApplicationUserHabit",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserHabit_UserId",
                table: "ApplicationUserHabit",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserHabit_AspNetUsers_UserId",
                table: "ApplicationUserHabit",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserHabit_AspNetUsers_UserId",
                table: "ApplicationUserHabit");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUserHabit_UserId",
                table: "ApplicationUserHabit");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ApplicationUserHabit",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "AspNetUsersId",
                table: "ApplicationUserHabit",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserHabit_AspNetUsersId",
                table: "ApplicationUserHabit",
                column: "AspNetUsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserHabit_AspNetUsers_AspNetUsersId",
                table: "ApplicationUserHabit",
                column: "AspNetUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
