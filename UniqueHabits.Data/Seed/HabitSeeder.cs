using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniqueHabits.Domain.Aggregates;
using UniqueHabits.Shared.Enums;

namespace UniqueHabits.Data.Seed
{
    public static class HabitSeeder
    {
        public static DataBuilder Seed(this EntityTypeBuilder<Habit> b)
        {
            return b.HasData(
                new
                {
                    Id = Guid.Parse("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"),
                    SystemName = "Grow my leadership knowledge each week.",
                    MeasurableResult = "Improve from a 2 to a 5 (on a scale of 1-10) in terms of confidence in my\r\nleadership knowledge.",
                    Why = "I want to have more career options so I can change people’s lives.",
                    StartDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Unspecified),
                    Category = HabitCategory.Career,
                    CategoryDescription = "",
                }
            ); 
        }

        public static DataBuilder Seed(this OwnedNavigationBuilder<Habit, ImplementationDetails> b)
        {
            return b.HasData(
                new
                {
                    HabitId = Guid.Parse("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"),
                    How = "• Play my “Energy Music” playlist.\r\n• Open LinkedIn Learning app on my tablet.\r\n• Continue from the last spot I was at when I finished the day before. (If I don’t have a course, do a search for “Leadership” and pick the next one on the list that I haven’t taken.)\r\n• While watching the course, listen for things I can DO that day.\r\n• Make notes in Evernote, especially on actions I can take.\r\n• After 20 minutes, stop.\r\n• Then take 5 minutes to post on LinkedIn what I learned.\r\n• Copy what I wrote and send myself an email.\r\n• Read the email when starting my work.",
                    WithWhat = "Tablet, LinkedIn Learning app, Phone with Evernote (for note-taking), Email",
                    When = "Tablet, LinkedIn Learning app, Phone with Evernote (for note-taking), Email",
                    Where = "On my couch",
                    WithWhom = "Share on LinkedIn one thing I learned today"
                }
            );
        }
    }
}
