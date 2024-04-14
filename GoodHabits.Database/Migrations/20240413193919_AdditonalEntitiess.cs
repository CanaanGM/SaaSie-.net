using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoodHabits.Database.Migrations
{
    /// <inheritdoc />
    public partial class AdditonalEntitiess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goal_Habits_HabitId",
                table: "Goal");

            migrationBuilder.DropForeignKey(
                name: "FK_Reminder_Habits_HabitId",
                table: "Reminder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reminder",
                table: "Reminder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Goal",
                table: "Goal");

            migrationBuilder.RenameTable(
                name: "Reminder",
                newName: "Reminders");

            migrationBuilder.RenameTable(
                name: "Goal",
                newName: "Goals");

            migrationBuilder.RenameIndex(
                name: "IX_Reminder_Id",
                table: "Reminders",
                newName: "IX_Reminders_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Reminder_HabitId",
                table: "Reminders",
                newName: "IX_Reminders_HabitId");

            migrationBuilder.RenameIndex(
                name: "IX_Goal_Id",
                table: "Goals",
                newName: "IX_Goals_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Goal_HabitId",
                table: "Goals",
                newName: "IX_Goals_HabitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reminders",
                table: "Reminders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Goals",
                table: "Goals",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Progress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HabitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Progress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Progress_Habits_HabitId",
                        column: x => x.HabitId,
                        principalTable: "Habits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Progress_HabitId",
                table: "Progress",
                column: "HabitId");

            migrationBuilder.CreateIndex(
                name: "IX_Progress_Id",
                table: "Progress",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Id",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_Habits_HabitId",
                table: "Goals",
                column: "HabitId",
                principalTable: "Habits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reminders_Habits_HabitId",
                table: "Reminders",
                column: "HabitId",
                principalTable: "Habits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goals_Habits_HabitId",
                table: "Goals");

            migrationBuilder.DropForeignKey(
                name: "FK_Reminders_Habits_HabitId",
                table: "Reminders");

            migrationBuilder.DropTable(
                name: "Progress");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reminders",
                table: "Reminders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Goals",
                table: "Goals");

            migrationBuilder.RenameTable(
                name: "Reminders",
                newName: "Reminder");

            migrationBuilder.RenameTable(
                name: "Goals",
                newName: "Goal");

            migrationBuilder.RenameIndex(
                name: "IX_Reminders_Id",
                table: "Reminder",
                newName: "IX_Reminder_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Reminders_HabitId",
                table: "Reminder",
                newName: "IX_Reminder_HabitId");

            migrationBuilder.RenameIndex(
                name: "IX_Goals_Id",
                table: "Goal",
                newName: "IX_Goal_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Goals_HabitId",
                table: "Goal",
                newName: "IX_Goal_HabitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reminder",
                table: "Reminder",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Goal",
                table: "Goal",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Goal_Habits_HabitId",
                table: "Goal",
                column: "HabitId",
                principalTable: "Habits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reminder_Habits_HabitId",
                table: "Reminder",
                column: "HabitId",
                principalTable: "Habits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
