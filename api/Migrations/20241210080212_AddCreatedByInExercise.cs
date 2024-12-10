using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatedByInExercise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0217ae5f-06c0-44b9-a532-88d2b918fbb2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5a15467-89d7-4f34-b80e-63956956e8d9");

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Exercise",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0280bdd8-a184-4191-b4f9-ef31c2b7c20c", null, "User", "USER" },
                    { "8483e568-62ff-4f1d-9160-d6196d8cbdaa", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_CreatedById",
                table: "Exercise",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_AspNetUsers_CreatedById",
                table: "Exercise",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_AspNetUsers_CreatedById",
                table: "Exercise");

            migrationBuilder.DropIndex(
                name: "IX_Exercise_CreatedById",
                table: "Exercise");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0280bdd8-a184-4191-b4f9-ef31c2b7c20c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8483e568-62ff-4f1d-9160-d6196d8cbdaa");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Exercise");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0217ae5f-06c0-44b9-a532-88d2b918fbb2", null, "User", "USER" },
                    { "b5a15467-89d7-4f34-b80e-63956956e8d9", null, "Admin", "ADMIN" }
                });
        }
    }
}
