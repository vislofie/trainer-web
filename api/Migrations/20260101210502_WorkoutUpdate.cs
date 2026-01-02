using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class WorkoutUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_AspNetUsers_CreatedById",
                table: "Exercise");

            migrationBuilder.DropForeignKey(
                name: "FK_SetItem_Set_SetId",
                table: "SetItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SetItem",
                table: "SetItem");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0280bdd8-a184-4191-b4f9-ef31c2b7c20c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8483e568-62ff-4f1d-9160-d6196d8cbdaa");

            migrationBuilder.RenameTable(
                name: "SetItem",
                newName: "SetItems");

            migrationBuilder.RenameIndex(
                name: "IX_SetItem_SetId",
                table: "SetItems",
                newName: "IX_SetItems_SetId");

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Workouts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Workouts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SetItems",
                table: "SetItems",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c56e5fc6-e95b-4e71-a7bd-972def7cf5c4", null, "Admin", "ADMIN" },
                    { "f80efeea-a45c-4abe-9581-a4ead9ae5d17", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_CreatedById",
                table: "Workouts",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_AspNetUsers_CreatedById",
                table: "Exercise",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SetItems_Set_SetId",
                table: "SetItems",
                column: "SetId",
                principalTable: "Set",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_AspNetUsers_CreatedById",
                table: "Workouts",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_AspNetUsers_CreatedById",
                table: "Exercise");

            migrationBuilder.DropForeignKey(
                name: "FK_SetItems_Set_SetId",
                table: "SetItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_AspNetUsers_CreatedById",
                table: "Workouts");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_CreatedById",
                table: "Workouts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SetItems",
                table: "SetItems");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c56e5fc6-e95b-4e71-a7bd-972def7cf5c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f80efeea-a45c-4abe-9581-a4ead9ae5d17");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Workouts");

            migrationBuilder.RenameTable(
                name: "SetItems",
                newName: "SetItem");

            migrationBuilder.RenameIndex(
                name: "IX_SetItems_SetId",
                table: "SetItem",
                newName: "IX_SetItem_SetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SetItem",
                table: "SetItem",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0280bdd8-a184-4191-b4f9-ef31c2b7c20c", null, "User", "USER" },
                    { "8483e568-62ff-4f1d-9160-d6196d8cbdaa", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_AspNetUsers_CreatedById",
                table: "Exercise",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SetItem_Set_SetId",
                table: "SetItem",
                column: "SetId",
                principalTable: "Set",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
