using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateExercise_ExerciseLevel_Relationship_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_ExerciseLevel_ExerciseLevelId",
                table: "Exercise");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_ExerciseLevel_ExerciseLevelId1",
                table: "Exercise");

            migrationBuilder.DropIndex(
                name: "IX_Exercise_ExerciseLevelId1",
                table: "Exercise");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3bee2bb7-0bdb-49bb-9fdf-eebd1950d0ed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6fd768f8-8fb4-4077-b985-64f1a0391db7");

            migrationBuilder.DropColumn(
                name: "ExerciseLevelId1",
                table: "Exercise");

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
                    { "7fcb9ae4-0ce0-4831-ab98-90a2c7aba0a6", null, "User", "USER" },
                    { "99a6b773-b0c7-4772-b59b-eb709ca34b07", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_ExerciseLevel_ExerciseLevelId",
                table: "Exercise",
                column: "ExerciseLevelId",
                principalTable: "ExerciseLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
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
                keyValue: "7fcb9ae4-0ce0-4831-ab98-90a2c7aba0a6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99a6b773-b0c7-4772-b59b-eb709ca34b07");

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseLevelId",
                table: "Exercise",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "ExerciseLevelId1",
                table: "Exercise",
                type: "integer",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3bee2bb7-0bdb-49bb-9fdf-eebd1950d0ed", null, "User", "USER" },
                    { "6fd768f8-8fb4-4077-b985-64f1a0391db7", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_ExerciseLevelId1",
                table: "Exercise",
                column: "ExerciseLevelId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_ExerciseLevel_ExerciseLevelId",
                table: "Exercise",
                column: "ExerciseLevelId",
                principalTable: "ExerciseLevel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_ExerciseLevel_ExerciseLevelId1",
                table: "Exercise",
                column: "ExerciseLevelId1",
                principalTable: "ExerciseLevel",
                principalColumn: "Id");
        }
    }
}
