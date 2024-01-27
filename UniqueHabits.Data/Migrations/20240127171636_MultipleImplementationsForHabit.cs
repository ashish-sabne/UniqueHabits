using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniqueHabits.Data.Migrations
{
    /// <inheritdoc />
    public partial class MultipleImplementationsForHabit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImplementationDetails_How",
                table: "Habits");

            migrationBuilder.DropColumn(
                name: "ImplementationDetails_When",
                table: "Habits");

            migrationBuilder.DropColumn(
                name: "ImplementationDetails_Where",
                table: "Habits");

            migrationBuilder.DropColumn(
                name: "ImplementationDetails_WithWhat",
                table: "Habits");

            migrationBuilder.DropColumn(
                name: "ImplementationDetails_WithWhom",
                table: "Habits");

            migrationBuilder.CreateTable(
                name: "Implementation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HabitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WithWhat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    When = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Where = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WithWhom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Implementation", x => new { x.HabitId, x.Id });
                    table.ForeignKey(
                        name: "FK_Implementation_Habits_HabitId",
                        column: x => x.HabitId,
                        principalTable: "Habits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImplementationStep",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImplementationHabitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImplementationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Step = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImplementationStep", x => new { x.ImplementationHabitId, x.ImplementationId, x.Id });
                    table.ForeignKey(
                        name: "FK_ImplementationStep_Implementation_ImplementationHabitId_ImplementationId",
                        columns: x => new { x.ImplementationHabitId, x.ImplementationId },
                        principalTable: "Implementation",
                        principalColumns: new[] { "HabitId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Implementation",
                columns: new[] { "HabitId", "Id", "CreatedDate", "When", "Where", "WithWhat", "WithWhom" },
                values: new object[] { new Guid("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4"), new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tablet, LinkedIn Learning app, Phone with Evernote (for note-taking), Email", "On my couch", "Tablet, LinkedIn Learning app, Phone with Evernote (for note-taking), Email", "Share on LinkedIn one thing I learned today" });

            migrationBuilder.InsertData(
                table: "ImplementationStep",
                columns: new[] { "Id", "ImplementationHabitId", "ImplementationId", "Step" },
                values: new object[,]
                {
                    { new Guid("15c47fda-6c6e-4901-b463-1ab15addac7e"), new Guid("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4"), "While watching the course, listen for things I can DO that day." },
                    { new Guid("1abdf905-808c-4ac7-bdc7-8741694adcb4"), new Guid("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4"), "Open LinkedIn Learning app on my tablet." },
                    { new Guid("20482634-af53-4db0-99d9-cda5a83da543"), new Guid("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4"), "Play my \"Energy Music\" playlist." },
                    { new Guid("3dba9c2e-218d-4dad-b1f2-264a4cea85b1"), new Guid("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4"), "Make notes in Evernote, especially on actions I can take." },
                    { new Guid("6d07f8b3-81d6-4cf9-83b5-583029d84185"), new Guid("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4"), "Read the email when starting my work." },
                    { new Guid("a319ba49-3228-4e61-8ea9-5208d616af07"), new Guid("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4"), "Copy what I wrote and send myself an email." },
                    { new Guid("c07213c8-c8a6-491e-8ef5-0388cfcc4066"), new Guid("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4"), "Continue from the last spot I was at when I finished the day before. (If I don’t have a course, do a search for \"Leadership\" and pick the next one on the list that I haven’t taken.)" },
                    { new Guid("c61bb021-d507-4cdd-bb5a-7cb0b33b7f28"), new Guid("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4"), "After 20 minutes, stop." },
                    { new Guid("e315e429-fbd6-4a9f-9df3-e3e4bfbb584c"), new Guid("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4"), "Make notes in Evernote, especially on actions I can take." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImplementationStep");

            migrationBuilder.DropTable(
                name: "Implementation");

            migrationBuilder.AddColumn<string>(
                name: "ImplementationDetails_How",
                table: "Habits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImplementationDetails_When",
                table: "Habits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImplementationDetails_Where",
                table: "Habits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImplementationDetails_WithWhat",
                table: "Habits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImplementationDetails_WithWhom",
                table: "Habits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Habits",
                keyColumn: "Id",
                keyValue: new Guid("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"),
                columns: new[] { "ImplementationDetails_How", "ImplementationDetails_When", "ImplementationDetails_Where", "ImplementationDetails_WithWhat", "ImplementationDetails_WithWhom" },
                values: new object[] { "• Play my “Energy Music” playlist.\r\n• Open LinkedIn Learning app on my tablet.\r\n• Continue from the last spot I was at when I finished the day before. (If I don’t have a course, do a search for “Leadership” and pick the next one on the list that I haven’t taken.)\r\n• While watching the course, listen for things I can DO that day.\r\n• Make notes in Evernote, especially on actions I can take.\r\n• After 20 minutes, stop.\r\n• Then take 5 minutes to post on LinkedIn what I learned.\r\n• Copy what I wrote and send myself an email.\r\n• Read the email when starting my work.", "Tablet, LinkedIn Learning app, Phone with Evernote (for note-taking), Email", "On my couch", "Tablet, LinkedIn Learning app, Phone with Evernote (for note-taking), Email", "Share on LinkedIn one thing I learned today" });
        }
    }
}
