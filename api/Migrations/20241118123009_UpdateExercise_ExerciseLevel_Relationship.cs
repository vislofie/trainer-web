using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateExercise_ExerciseLevel_Relationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "440795de-5095-4e53-b1c8-cfb6d8e9fdc8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7556a1af-3b04-4a6d-825c-fdb39fcff9c0");

            migrationBuilder.CreateTable(
                name: "ExerciseLevel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Picture = table.Column<string>(type: "text", nullable: false),
                    Video = table.Column<string>(type: "text", nullable: false),
                    ExerciseLevelId = table.Column<int>(type: "integer", nullable: false),
                    ExerciseLevelId1 = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercise_ExerciseLevel_ExerciseLevelId",
                        column: x => x.ExerciseLevelId,
                        principalTable: "ExerciseLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exercise_ExerciseLevel_ExerciseLevelId1",
                        column: x => x.ExerciseLevelId1,
                        principalTable: "ExerciseLevel",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "79ed947f-ccf5-431b-972c-e72c00c88459", null, "Admin", "ADMIN" },
                    { "7e0640be-75ee-4ec4-b3db-7a90c8f51b77", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_ExerciseLevelId",
                table: "Exercise",
                column: "ExerciseLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_ExerciseLevelId1",
                table: "Exercise",
                column: "ExerciseLevelId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "ExerciseLevel");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79ed947f-ccf5-431b-972c-e72c00c88459");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e0640be-75ee-4ec4-b3db-7a90c8f51b77");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "440795de-5095-4e53-b1c8-cfb6d8e9fdc8", null, "User", "USER" },
                    { "7556a1af-3b04-4a6d-825c-fdb39fcff9c0", null, "Admin", "ADMIN" }
                });
        }
    }
}
