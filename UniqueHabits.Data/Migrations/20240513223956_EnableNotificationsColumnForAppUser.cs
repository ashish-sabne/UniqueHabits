using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniqueHabits.Data.Migrations
{
    /// <inheritdoc />
    public partial class EnableNotificationsColumnForAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EnableNotifications",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7A9BC443-C678-4288-8D23-EFE9CE7E5232",
                column: "EnableNotifications",
                value: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnableNotifications",
                table: "AspNetUsers");
        }
    }
}
