using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class UnknownUpdateIDKBruh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e410773-136c-4ff3-95b5-c83f7ec4533c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b822e03-1202-4f5b-b962-454752121b5d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7310f3f0-119a-4cae-abc4-f9ba206f04de", null, "Admin", "ADMIN" },
                    { "aa4a1ab2-75d4-4c71-a42d-89ee774b1fd6", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                    { "6e410773-136c-4ff3-95b5-c83f7ec4533c", null, "Admin", "ADMIN" },
                    { "7b822e03-1202-4f5b-b962-454752121b5d", null, "User", "USER" }
                });
        }
    }
}
