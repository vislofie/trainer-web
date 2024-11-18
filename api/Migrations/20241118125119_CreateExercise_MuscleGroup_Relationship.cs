using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class CreateExercise_MuscleGroup_Relationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_ExerciseLevel_ExerciseLevelId",
                table: "Exercise");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExerciseLevel",
                table: "ExerciseLevel");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7fcb9ae4-0ce0-4831-ab98-90a2c7aba0a6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99a6b773-b0c7-4772-b59b-eb709ca34b07");

            migrationBuilder.RenameTable(
                name: "ExerciseLevel",
                newName: "ExerciseLevels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExerciseLevels",
                table: "ExerciseLevels",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "MuscleGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuscleGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseMuscleGroup",
                columns: table => new
                {
                    ExercisesId = table.Column<int>(type: "integer", nullable: false),
                    MuscleGroupsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseMuscleGroup", x => new { x.ExercisesId, x.MuscleGroupsId });
                    table.ForeignKey(
                        name: "FK_ExerciseMuscleGroup_Exercise_ExercisesId",
                        column: x => x.ExercisesId,
                        principalTable: "Exercise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseMuscleGroup_MuscleGroups_MuscleGroupsId",
                        column: x => x.MuscleGroupsId,
                        principalTable: "MuscleGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4a661940-878f-46ee-ae7e-676261086005", null, "Admin", "ADMIN" },
                    { "5df9405f-718d-447a-981d-e8d5798b7ca8", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseMuscleGroup_MuscleGroupsId",
                table: "ExerciseMuscleGroup",
                column: "MuscleGroupsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_ExerciseLevels_ExerciseLevelId",
                table: "Exercise",
                column: "ExerciseLevelId",
                principalTable: "ExerciseLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_ExerciseLevels_ExerciseLevelId",
                table: "Exercise");

            migrationBuilder.DropTable(
                name: "ExerciseMuscleGroup");

            migrationBuilder.DropTable(
                name: "MuscleGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExerciseLevels",
                table: "ExerciseLevels");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a661940-878f-46ee-ae7e-676261086005");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5df9405f-718d-447a-981d-e8d5798b7ca8");

            migrationBuilder.RenameTable(
                name: "ExerciseLevels",
                newName: "ExerciseLevel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExerciseLevel",
                table: "ExerciseLevel",
                column: "Id");

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
    }
}
