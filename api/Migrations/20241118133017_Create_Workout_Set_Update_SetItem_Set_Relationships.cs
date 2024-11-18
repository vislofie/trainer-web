using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Create_Workout_Set_Update_SetItem_Set_Relationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54792818-5868-40bd-b016-6ee261b5997f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e564db3a-bf8e-4f71-938d-70154821e792");

            migrationBuilder.AddColumn<int>(
                name: "WorkoutId",
                table: "Set",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Workout",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WorkoutName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workout", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "12434a1d-e3b7-4ac3-ae02-37120b8e8245", null, "User", "USER" },
                    { "6d55d4db-eea0-4c60-a422-c11976c21d71", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Set_WorkoutId",
                table: "Set",
                column: "WorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Set_Workout_WorkoutId",
                table: "Set",
                column: "WorkoutId",
                principalTable: "Workout",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Set_Workout_WorkoutId",
                table: "Set");

            migrationBuilder.DropTable(
                name: "Workout");

            migrationBuilder.DropIndex(
                name: "IX_Set_WorkoutId",
                table: "Set");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12434a1d-e3b7-4ac3-ae02-37120b8e8245");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d55d4db-eea0-4c60-a422-c11976c21d71");

            migrationBuilder.DropColumn(
                name: "WorkoutId",
                table: "Set");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "54792818-5868-40bd-b016-6ee261b5997f", null, "User", "USER" },
                    { "e564db3a-bf8e-4f71-938d-70154821e792", null, "Admin", "ADMIN" }
                });
        }
    }
}
