using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniqueHabits.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateHabitStepImplementationRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ImplementationStep",
                table: "ImplementationStep");

            migrationBuilder.DeleteData(
                table: "ImplementationStep",
                keyColumns: new[] { "Id", "ImplementationId" },
                keyValues: new object[] { new Guid("15c47fda-6c6e-4901-b463-1ab15addac7e"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4") });

            migrationBuilder.DeleteData(
                table: "ImplementationStep",
                keyColumns: new[] { "Id", "ImplementationId" },
                keyValues: new object[] { new Guid("1abdf905-808c-4ac7-bdc7-8741694adcb4"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4") });

            migrationBuilder.DeleteData(
                table: "ImplementationStep",
                keyColumns: new[] { "Id", "ImplementationId" },
                keyValues: new object[] { new Guid("20482634-af53-4db0-99d9-cda5a83da543"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4") });

            migrationBuilder.DeleteData(
                table: "ImplementationStep",
                keyColumns: new[] { "Id", "ImplementationId" },
                keyValues: new object[] { new Guid("3dba9c2e-218d-4dad-b1f2-264a4cea85b1"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4") });

            migrationBuilder.DeleteData(
                table: "ImplementationStep",
                keyColumns: new[] { "Id", "ImplementationId" },
                keyValues: new object[] { new Guid("6d07f8b3-81d6-4cf9-83b5-583029d84185"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4") });

            migrationBuilder.DeleteData(
                table: "ImplementationStep",
                keyColumns: new[] { "Id", "ImplementationId" },
                keyValues: new object[] { new Guid("a319ba49-3228-4e61-8ea9-5208d616af07"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4") });

            migrationBuilder.DeleteData(
                table: "ImplementationStep",
                keyColumns: new[] { "Id", "ImplementationId" },
                keyValues: new object[] { new Guid("c07213c8-c8a6-491e-8ef5-0388cfcc4066"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4") });

            migrationBuilder.DeleteData(
                table: "ImplementationStep",
                keyColumns: new[] { "Id", "ImplementationId" },
                keyValues: new object[] { new Guid("c61bb021-d507-4cdd-bb5a-7cb0b33b7f28"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4") });

            migrationBuilder.DeleteData(
                table: "ImplementationStep",
                keyColumns: new[] { "Id", "ImplementationId" },
                keyValues: new object[] { new Guid("e315e429-fbd6-4a9f-9df3-e3e4bfbb584c"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4") });

            migrationBuilder.AlterColumn<Guid>(
                name: "ImplementationId",
                table: "ImplementationStep",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImplementationStep",
                table: "ImplementationStep",
                column: "Id");

            migrationBuilder.InsertData(
                table: "ImplementationStep",
                columns: new[] { "Id", "ImplementationId", "Sequence", "Step" },
                values: new object[,]
                {
                    { new Guid("15c47fda-6c6e-4901-b463-1ab15addac7e"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4"), 4, "While watching the course, listen for things I can DO that day." },
                    { new Guid("1abdf905-808c-4ac7-bdc7-8741694adcb4"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4"), 2, "Open LinkedIn Learning app on my tablet." },
                    { new Guid("20482634-af53-4db0-99d9-cda5a83da543"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4"), 1, "Play my \"Energy Music\" playlist." },
                    { new Guid("3dba9c2e-218d-4dad-b1f2-264a4cea85b1"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4"), 6, "Make notes in Evernote, especially on actions I can take." },
                    { new Guid("6d07f8b3-81d6-4cf9-83b5-583029d84185"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4"), 9, "Read the email when starting my work." },
                    { new Guid("a319ba49-3228-4e61-8ea9-5208d616af07"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4"), 8, "Copy what I wrote and send myself an email." },
                    { new Guid("c07213c8-c8a6-491e-8ef5-0388cfcc4066"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4"), 3, "Continue from the last spot I was at when I finished the day before. (If I don’t have a course, do a search for \"Leadership\" and pick the next one on the list that I haven’t taken.)" },
                    { new Guid("c61bb021-d507-4cdd-bb5a-7cb0b33b7f28"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4"), 7, "After 20 minutes, stop." },
                    { new Guid("e315e429-fbd6-4a9f-9df3-e3e4bfbb584c"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4"), 5, "Make notes in Evernote, especially on actions I can take." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImplementationStep_ImplementationId",
                table: "ImplementationStep",
                column: "ImplementationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ImplementationStep",
                table: "ImplementationStep");

            migrationBuilder.DropIndex(
                name: "IX_ImplementationStep_ImplementationId",
                table: "ImplementationStep");

            migrationBuilder.DeleteData(
                table: "ImplementationStep",
                keyColumn: "Id",
                keyValue: new Guid("15c47fda-6c6e-4901-b463-1ab15addac7e"));

            migrationBuilder.DeleteData(
                table: "ImplementationStep",
                keyColumn: "Id",
                keyValue: new Guid("1abdf905-808c-4ac7-bdc7-8741694adcb4"));

            migrationBuilder.DeleteData(
                table: "ImplementationStep",
                keyColumn: "Id",
                keyValue: new Guid("20482634-af53-4db0-99d9-cda5a83da543"));

            migrationBuilder.DeleteData(
                table: "ImplementationStep",
                keyColumn: "Id",
                keyValue: new Guid("3dba9c2e-218d-4dad-b1f2-264a4cea85b1"));

            migrationBuilder.DeleteData(
                table: "ImplementationStep",
                keyColumn: "Id",
                keyValue: new Guid("6d07f8b3-81d6-4cf9-83b5-583029d84185"));

            migrationBuilder.DeleteData(
                table: "ImplementationStep",
                keyColumn: "Id",
                keyValue: new Guid("a319ba49-3228-4e61-8ea9-5208d616af07"));

            migrationBuilder.DeleteData(
                table: "ImplementationStep",
                keyColumn: "Id",
                keyValue: new Guid("c07213c8-c8a6-491e-8ef5-0388cfcc4066"));

            migrationBuilder.DeleteData(
                table: "ImplementationStep",
                keyColumn: "Id",
                keyValue: new Guid("c61bb021-d507-4cdd-bb5a-7cb0b33b7f28"));

            migrationBuilder.DeleteData(
                table: "ImplementationStep",
                keyColumn: "Id",
                keyValue: new Guid("e315e429-fbd6-4a9f-9df3-e3e4bfbb584c"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ImplementationId",
                table: "ImplementationStep",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImplementationStep",
                table: "ImplementationStep",
                columns: new[] { "ImplementationId", "Id" });

            migrationBuilder.InsertData(
                table: "ImplementationStep",
                columns: new[] { "Id", "ImplementationId", "Sequence", "Step" },
                values: new object[,]
                {
                    { new Guid("15c47fda-6c6e-4901-b463-1ab15addac7e"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4"), 4, "While watching the course, listen for things I can DO that day." },
                    { new Guid("1abdf905-808c-4ac7-bdc7-8741694adcb4"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4"), 2, "Open LinkedIn Learning app on my tablet." },
                    { new Guid("20482634-af53-4db0-99d9-cda5a83da543"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4"), 1, "Play my \"Energy Music\" playlist." },
                    { new Guid("3dba9c2e-218d-4dad-b1f2-264a4cea85b1"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4"), 6, "Make notes in Evernote, especially on actions I can take." },
                    { new Guid("6d07f8b3-81d6-4cf9-83b5-583029d84185"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4"), 9, "Read the email when starting my work." },
                    { new Guid("a319ba49-3228-4e61-8ea9-5208d616af07"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4"), 8, "Copy what I wrote and send myself an email." },
                    { new Guid("c07213c8-c8a6-491e-8ef5-0388cfcc4066"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4"), 3, "Continue from the last spot I was at when I finished the day before. (If I don’t have a course, do a search for \"Leadership\" and pick the next one on the list that I haven’t taken.)" },
                    { new Guid("c61bb021-d507-4cdd-bb5a-7cb0b33b7f28"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4"), 7, "After 20 minutes, stop." },
                    { new Guid("e315e429-fbd6-4a9f-9df3-e3e4bfbb584c"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4"), 5, "Make notes in Evernote, especially on actions I can take." }
                });
        }
    }
}
