using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Add_Exercise_Set_Relationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b7039a6-5675-4379-8112-f448f577b351");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ea97d70-b99a-4719-9043-ee23153dd62d");

            migrationBuilder.AddColumn<int>(
                name: "ExerciseId",
                table: "Set",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "54792818-5868-40bd-b016-6ee261b5997f", null, "User", "USER" },
                    { "e564db3a-bf8e-4f71-938d-70154821e792", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Set_ExerciseId",
                table: "Set",
                column: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Set_Exercise_ExerciseId",
                table: "Set",
                column: "ExerciseId",
                principalTable: "Exercise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Set_Exercise_ExerciseId",
                table: "Set");

            migrationBuilder.DropIndex(
                name: "IX_Set_ExerciseId",
                table: "Set");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54792818-5868-40bd-b016-6ee261b5997f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e564db3a-bf8e-4f71-938d-70154821e792");

            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "Set");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0b7039a6-5675-4379-8112-f448f577b351", null, "User", "USER" },
                    { "7ea97d70-b99a-4719-9043-ee23153dd62d", null, "Admin", "ADMIN" }
                });
        }
    }
}
