using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniqueHabits.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedHabit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Habits",
                columns: new[] { "Id", "Category", "CategoryDescription", "MeasurableResult", "StartDate", "SystemName", "Why", "ImplementationDetails_How", "ImplementationDetails_When", "ImplementationDetails_Where", "ImplementationDetails_WithWhat", "ImplementationDetails_WithWhom" },
                values: new object[] { new Guid("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"), "Career", "", "Improve from a 2 to a 5 (on a scale of 1-10) in terms of confidence in my\r\nleadership knowledge.", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grow my leadership knowledge each week.", "I want to have more career options so I can change people’s lives.", "• Play my “Energy Music” playlist.\r\n• Open LinkedIn Learning app on my tablet.\r\n• Continue from the last spot I was at when I finished the day before. (If I don’t\r\nhave a course, do a search for “Leadership” and pick the next one on the list that I\r\nhaven’t taken.)\r\n• While watching the course, listen for things I can DO that day.\r\n• Make notes in Evernote, especially on actions I can take.\r\n• After 20 minutes, stop.\r\n• Then take 5 minutes to post on LinkedIn what I learned.\r\n• Copy what I wrote and send myself an email.\r\n• Read the email when starting my work.", "Tablet, LinkedIn Learning app, Phone with Evernote (for note-taking), Email", "On my couch", "Tablet, LinkedIn Learning app, Phone with Evernote (for note-taking), Email", "Share on LinkedIn one thing I learned today" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Habits",
                keyColumn: "Id",
                keyValue: new Guid("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"));
        }
    }
}
