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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Habits");
        }
    }
}
