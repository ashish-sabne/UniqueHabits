using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniqueHabits.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddHabitReviewFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomizationDescription",
                table: "Implementation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PreviousImplementationId",
                table: "Implementation",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Result",
                table: "Implementation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Implementation",
                keyColumns: new[] { "HabitId", "Id" },
                keyValues: new object[] { new Guid("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4") },
                columns: new[] { "CustomizationDescription", "PreviousImplementationId", "Result" },
                values: new object[] { null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomizationDescription",
                table: "Implementation");

            migrationBuilder.DropColumn(
                name: "PreviousImplementationId",
                table: "Implementation");

            migrationBuilder.DropColumn(
                name: "Result",
                table: "Implementation");
        }
    }
}
