using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateExercise_ExerciseLevel_Relationship_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_ExerciseLevel_ExerciseLevelId",
                table: "Exercise");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79ed947f-ccf5-431b-972c-e72c00c88459");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e0640be-75ee-4ec4-b3db-7a90c8f51b77");

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseLevelId",
                table: "Exercise",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3bee2bb7-0bdb-49bb-9fdf-eebd1950d0ed", null, "User", "USER" },
                    { "6fd768f8-8fb4-4077-b985-64f1a0391db7", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_ExerciseLevel_ExerciseLevelId",
                table: "Exercise",
                column: "ExerciseLevelId",
                principalTable: "ExerciseLevel",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_ExerciseLevel_ExerciseLevelId",
                table: "Exercise");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3bee2bb7-0bdb-49bb-9fdf-eebd1950d0ed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6fd768f8-8fb4-4077-b985-64f1a0391db7");

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseLevelId",
                table: "Exercise",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "79ed947f-ccf5-431b-972c-e72c00c88459", null, "Admin", "ADMIN" },
                    { "7e0640be-75ee-4ec4-b3db-7a90c8f51b77", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_ExerciseLevel_ExerciseLevelId",
                table: "Exercise",
                column: "ExerciseLevelId",
                principalTable: "ExerciseLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
