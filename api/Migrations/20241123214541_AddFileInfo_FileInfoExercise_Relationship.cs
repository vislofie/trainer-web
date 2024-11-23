using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddFileInfo_FileInfoExercise_Relationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "acbb90b5-110d-46f3-a84b-d14888da4a9e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd62229d-558f-4409-a795-a16a2dd886bd");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "Video",
                table: "Exercise");

            migrationBuilder.AddColumn<int>(
                name: "PictureId",
                table: "Exercise",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VideoId",
                table: "Exercise",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FileInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Size = table.Column<long>(type: "bigint", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileInfo", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6e410773-136c-4ff3-95b5-c83f7ec4533c", null, "Admin", "ADMIN" },
                    { "7b822e03-1202-4f5b-b962-454752121b5d", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_PictureId",
                table: "Exercise",
                column: "PictureId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_VideoId",
                table: "Exercise",
                column: "VideoId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_FileInfo_PictureId",
                table: "Exercise");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_FileInfo_VideoId",
                table: "Exercise");

            migrationBuilder.DropTable(
                name: "FileInfo");

            migrationBuilder.DropIndex(
                name: "IX_Exercise_PictureId",
                table: "Exercise");

            migrationBuilder.DropIndex(
                name: "IX_Exercise_VideoId",
                table: "Exercise");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e410773-136c-4ff3-95b5-c83f7ec4533c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b822e03-1202-4f5b-b962-454752121b5d");

            migrationBuilder.DropColumn(
                name: "PictureId",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "VideoId",
                table: "Exercise");

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Exercise",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Video",
                table: "Exercise",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "acbb90b5-110d-46f3-a84b-d14888da4a9e", null, "Admin", "ADMIN" },
                    { "fd62229d-558f-4409-a795-a16a2dd886bd", null, "User", "USER" }
                });
        }
    }
}
