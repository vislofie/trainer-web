using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Update_No_Navigation_Property_Exercise_Set : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf3e7363-4dbe-42f1-ba09-e05bf93e9f5d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d057a850-d687-441d-8232-45219244570c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "acbb90b5-110d-46f3-a84b-d14888da4a9e", null, "Admin", "ADMIN" },
                    { "fd62229d-558f-4409-a795-a16a2dd886bd", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "acbb90b5-110d-46f3-a84b-d14888da4a9e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd62229d-558f-4409-a795-a16a2dd886bd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cf3e7363-4dbe-42f1-ba09-e05bf93e9f5d", null, "User", "USER" },
                    { "d057a850-d687-441d-8232-45219244570c", null, "Admin", "ADMIN" }
                });
        }
    }
}
