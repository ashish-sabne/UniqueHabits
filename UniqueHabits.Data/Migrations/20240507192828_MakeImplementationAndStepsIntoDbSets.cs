using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniqueHabits.Data.Migrations
{
    /// <inheritdoc />
    public partial class MakeImplementationAndStepsIntoDbSets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Implementation_Habits_HabitId",
                table: "Implementation");

            migrationBuilder.DropForeignKey(
                name: "FK_Implementation_Implementation_PreviousImplementationId",
                table: "Implementation");

            migrationBuilder.DropForeignKey(
                name: "FK_ImplementationStep_Implementation_ImplementationId",
                table: "ImplementationStep");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Implementation",
                table: "Implementation");

            migrationBuilder.RenameTable(
                name: "Implementation",
                newName: "Implementations");

            migrationBuilder.RenameIndex(
                name: "IX_Implementation_PreviousImplementationId",
                table: "Implementations",
                newName: "IX_Implementations_PreviousImplementationId");

            migrationBuilder.RenameIndex(
                name: "IX_Implementation_HabitId",
                table: "Implementations",
                newName: "IX_Implementations_HabitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Implementations",
                table: "Implementations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Implementations_Habits_HabitId",
                table: "Implementations",
                column: "HabitId",
                principalTable: "Habits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Implementations_Implementations_PreviousImplementationId",
                table: "Implementations",
                column: "PreviousImplementationId",
                principalTable: "Implementations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImplementationStep_Implementations_ImplementationId",
                table: "ImplementationStep",
                column: "ImplementationId",
                principalTable: "Implementations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Implementations_Habits_HabitId",
                table: "Implementations");

            migrationBuilder.DropForeignKey(
                name: "FK_Implementations_Implementations_PreviousImplementationId",
                table: "Implementations");

            migrationBuilder.DropForeignKey(
                name: "FK_ImplementationStep_Implementations_ImplementationId",
                table: "ImplementationStep");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Implementations",
                table: "Implementations");

            migrationBuilder.RenameTable(
                name: "Implementations",
                newName: "Implementation");

            migrationBuilder.RenameIndex(
                name: "IX_Implementations_PreviousImplementationId",
                table: "Implementation",
                newName: "IX_Implementation_PreviousImplementationId");

            migrationBuilder.RenameIndex(
                name: "IX_Implementations_HabitId",
                table: "Implementation",
                newName: "IX_Implementation_HabitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Implementation",
                table: "Implementation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Implementation_Habits_HabitId",
                table: "Implementation",
                column: "HabitId",
                principalTable: "Habits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
