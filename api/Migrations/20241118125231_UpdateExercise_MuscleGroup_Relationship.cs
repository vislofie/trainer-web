using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateExercise_MuscleGroup_Relationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseMuscleGroup_MuscleGroups_MuscleGroupsId",
                table: "ExerciseMuscleGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MuscleGroups",
                table: "MuscleGroups");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a661940-878f-46ee-ae7e-676261086005");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5df9405f-718d-447a-981d-e8d5798b7ca8");

            migrationBuilder.RenameTable(
                name: "MuscleGroups",
                newName: "MuscleGroup");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MuscleGroup",
                table: "MuscleGroup",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9126ae61-538b-42c0-97fd-0b5bc8390dd3", null, "Admin", "ADMIN" },
                    { "b7c0cca5-7966-470b-8a45-a81125076853", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseMuscleGroup_MuscleGroup_MuscleGroupsId",
                table: "ExerciseMuscleGroup",
                column: "MuscleGroupsId",
                principalTable: "MuscleGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseMuscleGroup_MuscleGroup_MuscleGroupsId",
                table: "ExerciseMuscleGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MuscleGroup",
                table: "MuscleGroup");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9126ae61-538b-42c0-97fd-0b5bc8390dd3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7c0cca5-7966-470b-8a45-a81125076853");

            migrationBuilder.RenameTable(
                name: "MuscleGroup",
                newName: "MuscleGroups");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MuscleGroups",
                table: "MuscleGroups",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4a661940-878f-46ee-ae7e-676261086005", null, "Admin", "ADMIN" },
                    { "5df9405f-718d-447a-981d-e8d5798b7ca8", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseMuscleGroup_MuscleGroups_MuscleGroupsId",
                table: "ExerciseMuscleGroup",
                column: "MuscleGroupsId",
                principalTable: "MuscleGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
