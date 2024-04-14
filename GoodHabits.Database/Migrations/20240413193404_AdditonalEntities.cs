using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoodHabits.Database.Migrations
{
    /// <inheritdoc />
    public partial class AdditonalEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Habits",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Habits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Habits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Goal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HabitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Goal_Habits_HabitId",
                        column: x => x.HabitId,
                        principalTable: "Habits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reminder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Frequency = table.Column<int>(type: "int", nullable: false),
                    HabitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reminder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reminder_Habits_HabitId",
                        column: x => x.HabitId,
                        principalTable: "Habits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Habits",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "Duration", "UserId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "Habits",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "Duration", "UserId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "Habits",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "Duration", "UserId" },
                values: new object[] { 0, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Habits_Name_Id",
                table: "Habits",
                columns: new[] { "Name", "Id" });

            migrationBuilder.CreateIndex(
                name: "IX_Goal_HabitId",
                table: "Goal",
                column: "HabitId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Goal_Id",
                table: "Goal",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reminder_HabitId",
                table: "Reminder",
                column: "HabitId");

            migrationBuilder.CreateIndex(
                name: "IX_Reminder_Id",
                table: "Reminder",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Goal");

            migrationBuilder.DropTable(
                name: "Reminder");

            migrationBuilder.DropIndex(
                name: "IX_Habits_Name_Id",
                table: "Habits");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Habits");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Habits");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Habits",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
