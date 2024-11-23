using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class DeleteRestrict_FileInfo_Exercise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_ExerciseLevels_ExerciseLevelId",
                table: "Exercise");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_FileInfo_PictureId",
                table: "Exercise");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_FileInfo_VideoId",
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
                    { "1cca98de-1196-4254-a93d-b0746f71cd0d", null, "Admin", "ADMIN" },
                    { "1f418cfa-41aa-4b1b-8f75-779cba57854e", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_ExerciseLevels_ExerciseLevelId",
                table: "Exercise",
                column: "ExerciseLevelId",
                principalTable: "ExerciseLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_FileInfo_PictureId",
                table: "Exercise",
                column: "PictureId",
                principalTable: "FileInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_FileInfo_VideoId",
                table: "Exercise",
                column: "VideoId",
                principalTable: "FileInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_ExerciseLevels_ExerciseLevelId",
                table: "Exercise");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_FileInfo_PictureId",
                table: "Exercise");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_FileInfo_VideoId",
                table: "Exercise");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1cca98de-1196-4254-a93d-b0746f71cd0d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f418cfa-41aa-4b1b-8f75-779cba57854e");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_FileInfo_PictureId",
                table: "Exercise",
                column: "PictureId",
                principalTable: "FileInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_FileInfo_VideoId",
                table: "Exercise",
                column: "VideoId",
                principalTable: "FileInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
