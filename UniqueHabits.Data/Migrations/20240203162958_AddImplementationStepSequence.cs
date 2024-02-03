using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniqueHabits.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddImplementationStepSequence : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Sequence",
                table: "ImplementationStep",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ImplementationStep",
                keyColumns: new[] { "Id", "ImplementationHabitId", "ImplementationId" },
                keyValues: new object[] { new Guid("15c47fda-6c6e-4901-b463-1ab15addac7e"), new Guid("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4") },
                column: "Sequence",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ImplementationStep",
                keyColumns: new[] { "Id", "ImplementationHabitId", "ImplementationId" },
                keyValues: new object[] { new Guid("1abdf905-808c-4ac7-bdc7-8741694adcb4"), new Guid("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4") },
                column: "Sequence",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ImplementationStep",
                keyColumns: new[] { "Id", "ImplementationHabitId", "ImplementationId" },
                keyValues: new object[] { new Guid("20482634-af53-4db0-99d9-cda5a83da543"), new Guid("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4") },
                column: "Sequence",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ImplementationStep",
                keyColumns: new[] { "Id", "ImplementationHabitId", "ImplementationId" },
                keyValues: new object[] { new Guid("3dba9c2e-218d-4dad-b1f2-264a4cea85b1"), new Guid("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4") },
                column: "Sequence",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ImplementationStep",
                keyColumns: new[] { "Id", "ImplementationHabitId", "ImplementationId" },
                keyValues: new object[] { new Guid("6d07f8b3-81d6-4cf9-83b5-583029d84185"), new Guid("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4") },
                column: "Sequence",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ImplementationStep",
                keyColumns: new[] { "Id", "ImplementationHabitId", "ImplementationId" },
                keyValues: new object[] { new Guid("a319ba49-3228-4e61-8ea9-5208d616af07"), new Guid("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4") },
                column: "Sequence",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ImplementationStep",
                keyColumns: new[] { "Id", "ImplementationHabitId", "ImplementationId" },
                keyValues: new object[] { new Guid("c07213c8-c8a6-491e-8ef5-0388cfcc4066"), new Guid("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4") },
                column: "Sequence",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ImplementationStep",
                keyColumns: new[] { "Id", "ImplementationHabitId", "ImplementationId" },
                keyValues: new object[] { new Guid("c61bb021-d507-4cdd-bb5a-7cb0b33b7f28"), new Guid("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4") },
                column: "Sequence",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ImplementationStep",
                keyColumns: new[] { "Id", "ImplementationHabitId", "ImplementationId" },
                keyValues: new object[] { new Guid("e315e429-fbd6-4a9f-9df3-e3e4bfbb584c"), new Guid("171d31ef-0a27-4fe8-bfd4-bb12083d5ba0"), new Guid("0fd52347-6f3c-461f-b05d-57ae63e9a9f4") },
                column: "Sequence",
                value: 5);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sequence",
                table: "ImplementationStep");
        }
    }
}
