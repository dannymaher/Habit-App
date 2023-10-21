using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Habit_App_Data.Migrations
{
    /// <inheritdoc />
    public partial class addRecordsTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUserHabitRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HabitId = table.Column<int>(type: "int", nullable: false),
                    MeasurementUnit = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserHabitRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationUserHabitRecord_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserHabitRecord_Habits_HabitId",
                        column: x => x.HabitId,
                        principalTable: "Habits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserHabitRecord_HabitId",
                table: "ApplicationUserHabitRecord",
                column: "HabitId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserHabitRecord_UserId",
                table: "ApplicationUserHabitRecord",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserHabitRecord");
        }
    }
}
