using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniqueHabits.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateHabitImplementationRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImplementationStep_Implementation_ImplementationHabitId_ImplementationId",
                table: "ImplementationStep");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImplementationStep",
                table: "ImplementationStep");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Implementation",
                table: "Implementation");

            migrationBuilder.DeleteData(
                table: "ImplementationStep",
                keyColumns: new[] { "Id", "ImplementationHabitId", "ImplementationId" },
                keyColumnTypes: new[] { "uniqueidentifier", "uniqueidentifier", "uniqueidentifier" },
                keyValues: new object[] { new Guid("15c47fda-6c6e-4901-b463-1ab15addac7e"), new Guid("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4") });

            migrationBuilder.DeleteData(
                table: "ImplementationStep",
                keyColumns: new[] { "Id", "ImplementationHabitId", "ImplementationId" },
                keyColumnTypes: new[] { "uniqueidentifier", "uniqueidentifier", "uniqueidentifier" },
                keyValues: new object[] { new Guid("1abdf905-808c-4ac7-bdc7-8741694adcb4"), new Guid("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4") });

            migrationBuilder.DeleteData(
                table: "ImplementationStep",
                keyColumns: new[] { "Id", "ImplementationHabitId", "ImplementationId" },
                keyColumnTypes: new[] { "uniqueidentifier", "uniqueidentifier", "uniqueidentifier" },
                keyValues: new object[] { new Guid("20482634-af53-4db0-99d9-cda5a83da543"), new Guid("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4") });

            migrationBuilder.DeleteData(
                table: "ImplementationStep",
                keyColumns: new[] { "Id", "ImplementationHabitId", "ImplementationId" },
                keyColumnTypes: new[] { "uniqueidentifier", "uniqueidentifier", "uniqueidentifier" },
                keyValues: new object[] { new Guid("3dba9c2e-218d-4dad-b1f2-264a4cea85b1"), new Guid("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4") });

            migrationBuilder.DeleteData(
                table: "ImplementationStep",
                keyColumns: new[] { "Id", "ImplementationHabitId", "ImplementationId" },
                keyColumnTypes: new[] { "uniqueidentifier", "uniqueidentifier", "uniqueidentifier" },
                keyValues: new object[] { new Guid("6d07f8b3-81d6-4cf9-83b5-583029d84185"), new Guid("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4") });

            migrationBuilder.DeleteData(
                table: "ImplementationStep",
                keyColumns: new[] { "Id", "ImplementationHabitId", "ImplementationId" },
                keyColumnTypes: new[] { "uniqueidentifier", "uniqueidentifier", "uniqueidentifier" },
                keyValues: new object[] { new Guid("a319ba49-3228-4e61-8ea9-5208d616af07"), new Guid("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4") });

            migrationBuilder.DeleteData(
                table: "ImplementationStep",
                keyColumns: new[] { "Id", "ImplementationHabitId", "ImplementationId" },
                keyColumnTypes: new[] { "uniqueidentifier", "uniqueidentifier", "uniqueidentifier" },
                keyValues: new object[] { new Guid("c07213c8-c8a6-491e-8ef5-0388cfcc4066"), new Guid("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4") });

            migrationBuilder.DeleteData(
                table: "ImplementationStep",
                keyColumns: new[] { "Id", "ImplementationHabitId", "ImplementationId" },
                keyColumnTypes: new[] { "uniqueidentifier", "uniqueidentifier", "uniqueidentifier" },
                keyValues: new object[] { new Guid("c61bb021-d507-4cdd-bb5a-7cb0b33b7f28"), new Guid("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4") });

            migrationBuilder.DeleteData(
                table: "ImplementationStep",
                keyColumns: new[] { "Id", "ImplementationHabitId", "ImplementationId" },
                keyColumnTypes: new[] { "uniqueidentifier", "uniqueidentifier", "uniqueidentifier" },
                keyValues: new object[] { new Guid("e315e429-fbd6-4a9f-9df3-e3e4bfbb584c"), new Guid("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4") });

            migrationBuilder.DeleteData(
                table: "Implementation",
                keyColumns: new[] { "HabitId", "Id" },
                keyValues: new object[] { new Guid("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4") });

            migrationBuilder.DropColumn(
                name: "ImplementationHabitId",
                table: "ImplementationStep");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImplementationStep",
                table: "ImplementationStep",
                columns: new[] { "ImplementationId", "Id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Implementation",
                table: "Implementation",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Implementation",
                columns: new[] { "Id", "CreatedDate", "CustomizationCategory", "CustomizationDescription", "HabitId", "PreviousImplementationId", "Result", "When", "Where", "WithWhat", "WithWhom" },
                values: new object[] { new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4"), new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"), null, null, "First thing in the morning for 25 minutes.", "On my couch", "Tablet, LinkedIn Learning app, Phone with Evernote (for note-taking), Email", "Share on LinkedIn one thing I learned today" });

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
                name: "IX_Implementation_HabitId",
                table: "Implementation",
                column: "HabitId");

            migrationBuilder.CreateIndex(
                name: "IX_Implementation_PreviousImplementationId",
                table: "Implementation",
                column: "PreviousImplementationId",
                unique: true,
                filter: "[PreviousImplementationId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Implementation_Implementation_PreviousImplementationId",
                table: "Implementation",
                column: "PreviousImplementationId",
                principalTable: "Implementation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImplementationStep_Implementation_ImplementationId",
                table: "ImplementationStep",
                column: "ImplementationId",
                principalTable: "Implementation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Implementation_Implementation_PreviousImplementationId",
                table: "Implementation");

            migrationBuilder.DropForeignKey(
                name: "FK_ImplementationStep_Implementation_ImplementationId",
                table: "ImplementationStep");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImplementationStep",
                table: "ImplementationStep");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Implementation",
                table: "Implementation");

            migrationBuilder.DropIndex(
                name: "IX_Implementation_HabitId",
                table: "Implementation");

            migrationBuilder.DropIndex(
                name: "IX_Implementation_PreviousImplementationId",
                table: "Implementation");

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

            migrationBuilder.DeleteData(
                table: "Implementation",
                keyColumn: "Id",
                keyValue: new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4"));

            migrationBuilder.AddColumn<Guid>(
                name: "ImplementationHabitId",
                table: "ImplementationStep",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImplementationStep",
                table: "ImplementationStep",
                columns: new[] { "ImplementationHabitId", "ImplementationId", "Id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Implementation",
                table: "Implementation",
                columns: new[] { "HabitId", "Id" });

            migrationBuilder.InsertData(
                table: "Implementation",
                columns: new[] { "HabitId", "Id", "CreatedDate", "CustomizationCategory", "CustomizationDescription", "PreviousImplementationId", "Result", "When", "Where", "WithWhat", "WithWhom" },
                values: new object[] { new Guid("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4"), new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "First thing in the morning for 25 minutes.", "On my couch", "Tablet, LinkedIn Learning app, Phone with Evernote (for note-taking), Email", "Share on LinkedIn one thing I learned today" });

            migrationBuilder.InsertData(
                table: "ImplementationStep",
                columns: new[] { "Id", "ImplementationHabitId", "ImplementationId", "Sequence", "Step" },
                values: new object[,]
                {
                    { new Guid("15c47fda-6c6e-4901-b463-1ab15addac7e"), new Guid("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4"), 4, "While watching the course, listen for things I can DO that day." },
                    { new Guid("1abdf905-808c-4ac7-bdc7-8741694adcb4"), new Guid("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4"), 2, "Open LinkedIn Learning app on my tablet." },
                    { new Guid("20482634-af53-4db0-99d9-cda5a83da543"), new Guid("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4"), 1, "Play my \"Energy Music\" playlist." },
                    { new Guid("3dba9c2e-218d-4dad-b1f2-264a4cea85b1"), new Guid("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4"), 6, "Make notes in Evernote, especially on actions I can take." },
                    { new Guid("6d07f8b3-81d6-4cf9-83b5-583029d84185"), new Guid("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4"), 9, "Read the email when starting my work." },
                    { new Guid("a319ba49-3228-4e61-8ea9-5208d616af07"), new Guid("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4"), 8, "Copy what I wrote and send myself an email." },
                    { new Guid("c07213c8-c8a6-491e-8ef5-0388cfcc4066"), new Guid("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4"), 3, "Continue from the last spot I was at when I finished the day before. (If I don’t have a course, do a search for \"Leadership\" and pick the next one on the list that I haven’t taken.)" },
                    { new Guid("c61bb021-d507-4cdd-bb5a-7cb0b33b7f28"), new Guid("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4"), 7, "After 20 minutes, stop." },
                    { new Guid("e315e429-fbd6-4a9f-9df3-e3e4bfbb584c"), new Guid("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4"), 5, "Make notes in Evernote, especially on actions I can take." }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ImplementationStep_Implementation_ImplementationHabitId_ImplementationId",
                table: "ImplementationStep",
                columns: new[] { "ImplementationHabitId", "ImplementationId" },
                principalTable: "Implementation",
                principalColumns: new[] { "HabitId", "Id" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
