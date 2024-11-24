using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Add_FileInfo_Path : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1cca98de-1196-4254-a93d-b0746f71cd0d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f418cfa-41aa-4b1b-8f75-779cba57854e");

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "FileInfo",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0217ae5f-06c0-44b9-a532-88d2b918fbb2", null, "User", "USER" },
                    { "b5a15467-89d7-4f34-b80e-63956956e8d9", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0217ae5f-06c0-44b9-a532-88d2b918fbb2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5a15467-89d7-4f34-b80e-63956956e8d9");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "FileInfo");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1cca98de-1196-4254-a93d-b0746f71cd0d", null, "Admin", "ADMIN" },
                    { "1f418cfa-41aa-4b1b-8f75-779cba57854e", null, "User", "USER" }
                });
        }
    }
}
