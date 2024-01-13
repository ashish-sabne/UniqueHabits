using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniqueHabits.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Habits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SystemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeasurableResult = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Why = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImplementationDetails_How = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImplementationDetails_WithWhat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImplementationDetails_When = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImplementationDetails_Where = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImplementationDetails_WithWhom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habits", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Habits",
                columns: new[] { "Id", "Category", "CategoryDescription", "MeasurableResult", "StartDate", "SystemName", "Why", "ImplementationDetails_How", "ImplementationDetails_When", "ImplementationDetails_Where", "ImplementationDetails_WithWhat", "ImplementationDetails_WithWhom" },
                values: new object[] { new Guid("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"), "Career", "", "Improve from a 2 to a 5 (on a scale of 1-10) in terms of confidence in my\r\nleadership knowledge.", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grow my leadership knowledge each week.", "I want to have more career options so I can change people’s lives.", "• Play my “Energy Music” playlist.\r\n• Open LinkedIn Learning app on my tablet.\r\n• Continue from the last spot I was at when I finished the day before. (If I don’t have a course, do a search for “Leadership” and pick the next one on the list that I haven’t taken.)\r\n• While watching the course, listen for things I can DO that day.\r\n• Make notes in Evernote, especially on actions I can take.\r\n• After 20 minutes, stop.\r\n• Then take 5 minutes to post on LinkedIn what I learned.\r\n• Copy what I wrote and send myself an email.\r\n• Read the email when starting my work.", "Tablet, LinkedIn Learning app, Phone with Evernote (for note-taking), Email", "On my couch", "Tablet, LinkedIn Learning app, Phone with Evernote (for note-taking), Email", "Share on LinkedIn one thing I learned today" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Habits");
        }
    }
}
