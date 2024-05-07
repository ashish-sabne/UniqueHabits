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
                    CreatedById = "7A9BC443-C678-4288-8D23-EFE9CE7E5232"
                }
            );
        }

        public static DataBuilder Seed(this EntityTypeBuilder<Implementation> b)
        {
            return b.HasData(
                new
                {
                    Id = Guid.Parse("0fd52347-6f3c-461f-b05d-57ae63e9a9f4"),
                    HabitId = Guid.Parse("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"),
                    WithWhat = "Tablet, LinkedIn Learning app, Phone with Evernote (for note-taking), Email",
                    When = "First thing in the morning for 25 minutes.",
                    Where = "On my couch",
                    WithWhom = "Share on LinkedIn one thing I learned today",
                    CreatedDate = new DateTime(2024, 1, 12, 0, 0, 0)
                }
            );
        }

        public static DataBuilder Seed(this EntityTypeBuilder<ImplementationStep> b)
        {
            return b.HasData(
                new
                {
                    Id = Guid.Parse("20482634-af53-4db0-99d9-cda5a83da543"),
                    ImplementationId = Guid.Parse("0fd52347-6f3c-461f-b05d-57ae63e9a9f4"),
                    ImplementationHabitId = Guid.Parse("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"),
                    Step = "Play my \"Energy Music\" playlist.",
                    Sequence = 1
                },
                new
                {
                    Id = Guid.Parse("1abdf905-808c-4ac7-bdc7-8741694adcb4"),
                    ImplementationId = Guid.Parse("0fd52347-6f3c-461f-b05d-57ae63e9a9f4"),
                    ImplementationHabitId = Guid.Parse("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"),
                    Step = "Open LinkedIn Learning app on my tablet.",
                    Sequence = 2
                },
                new
                {
                    Id = Guid.Parse("c07213c8-c8a6-491e-8ef5-0388cfcc4066"),
                    ImplementationId = Guid.Parse("0fd52347-6f3c-461f-b05d-57ae63e9a9f4"),
                    ImplementationHabitId = Guid.Parse("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"),
                    Step = "Continue from the last spot I was at when I finished the day before. (If I don’t have a course, do a search for \"Leadership\" and pick the next one on the list that I haven’t taken.)",
                    Sequence = 3
                },
                new
                {
                    Id = Guid.Parse("15c47fda-6c6e-4901-b463-1ab15addac7e"),
                    ImplementationId = Guid.Parse("0fd52347-6f3c-461f-b05d-57ae63e9a9f4"),
                    ImplementationHabitId = Guid.Parse("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"),
                    Step = "While watching the course, listen for things I can DO that day.",
                    Sequence = 4
                },
                new
                {
                    Id = Guid.Parse("e315e429-fbd6-4a9f-9df3-e3e4bfbb584c"),
                    ImplementationId = Guid.Parse("0fd52347-6f3c-461f-b05d-57ae63e9a9f4"),
                    ImplementationHabitId = Guid.Parse("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"),
                    Step = "Make notes in Evernote, especially on actions I can take.",
                    Sequence = 5
                },
                new
                {
                    Id = Guid.Parse("3dba9c2e-218d-4dad-b1f2-264a4cea85b1"),
                    ImplementationId = Guid.Parse("0fd52347-6f3c-461f-b05d-57ae63e9a9f4"),
                    ImplementationHabitId = Guid.Parse("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"),
                    Step = "Make notes in Evernote, especially on actions I can take.",
                    Sequence = 6
                },
                new
                {
                    Id = Guid.Parse("c61bb021-d507-4cdd-bb5a-7cb0b33b7f28"),
                    ImplementationId = Guid.Parse("0fd52347-6f3c-461f-b05d-57ae63e9a9f4"),
                    ImplementationHabitId = Guid.Parse("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"),
                    Step = "After 20 minutes, stop.",
                    Sequence = 7
                },
                new
                {
                    Id = Guid.Parse("a319ba49-3228-4e61-8ea9-5208d616af07"),
                    ImplementationId = Guid.Parse("0fd52347-6f3c-461f-b05d-57ae63e9a9f4"),
                    ImplementationHabitId = Guid.Parse("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"),
                    Step = "Copy what I wrote and send myself an email.",
                    Sequence = 8
                },
                new
                {
                    Id = Guid.Parse("6d07f8b3-81d6-4cf9-83b5-583029d84185"),
                    ImplementationId = Guid.Parse("0fd52347-6f3c-461f-b05d-57ae63e9a9f4"),
                    ImplementationHabitId = Guid.Parse("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"),
                    Step = "Read the email when starting my work.",
                    Sequence = 9
                }
            );
        }
    }
}
