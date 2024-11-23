using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Remove_FK_Constraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_ExerciseLevels_ExerciseLevelId",
                table: "Exercise");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7310f3f0-119a-4cae-abc4-f9ba206f04de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa4a1ab2-75d4-4c71-a42d-89ee774b1fd6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "19f61ce6-0bb8-4ffa-8c2a-9a13cbbccf33", null, "Admin", "ADMIN" },
                    { "ab5678e9-c941-4c01-accf-26d70995bc0b", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_ExerciseLevels_ExerciseLevelId",
                table: "Exercise",
                column: "ExerciseLevelId",
                principalTable: "ExerciseLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_ExerciseLevels_ExerciseLevelId",
                table: "Exercise");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19f61ce6-0bb8-4ffa-8c2a-9a13cbbccf33");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab5678e9-c941-4c01-accf-26d70995bc0b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7310f3f0-119a-4cae-abc4-f9ba206f04de", null, "Admin", "ADMIN" },
                    { "aa4a1ab2-75d4-4c71-a42d-89ee774b1fd6", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_ExerciseLevels_ExerciseLevelId",
                table: "Exercise",
                column: "ExerciseLevelId",
                principalTable: "ExerciseLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
