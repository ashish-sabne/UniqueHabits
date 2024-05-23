using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniqueHabits.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedNotifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                TRUNCATE TABLE Notifications
                GO

                INSERT INTO [dbo].[Notifications] 
                (
                    [Id], 
                    [Title], 
                    [DateNotified], 
                    [IsRead], 
                    [HabitId], 
                    [CreatedById], 
                    [NotificationType]
                )

                SELECT NEWID(), N'Your habit is due for review', CONVERT(date, DATEADD(DAY,15,i.CreatedDate)) , 
                CASE 
	                WHEN DATEADD(DAY,15,i.CreatedDate) <= GETDATE() THEN 1
	                ELSE 0
                END, HabitId, h.CreatedById, N'ReviewDue'
                FROM Implementations i
                JOIN Habits h on h.Id = i.HabitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
