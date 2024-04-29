using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniqueHabits.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatedByUserIdColumnForHabits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Habits",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Habits",
                keyColumn: "Id",
                keyValue: new Guid("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"),
                column: "CreatedById",
                value: "7A9BC443-C678-4288-8D23-EFE9CE7E5232");

            migrationBuilder.CreateIndex(
                name: "IX_Habits_CreatedById",
                table: "Habits",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Habits_AspNetUsers_CreatedById",
                table: "Habits",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habits_AspNetUsers_CreatedById",
                table: "Habits");

            migrationBuilder.DropIndex(
                name: "IX_Habits_CreatedById",
                table: "Habits");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Habits");
        }
    }
}
