using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartG.API.Migrations
{
    public partial class AddedCommentsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "833e7b98-d677-44fb-ac33-a91527ce0157");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad6bd18f-8934-4e82-9d2b-b4412f339942");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d69ce346-183f-48b2-9159-880ce821f37c");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Approved = table.Column<bool>(type: "bit", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PortifolioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    AuthorId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Portifolios_PortifolioId",
                        column: x => x.PortifolioId,
                        principalTable: "Portifolios",
                        principalColumn: "PortifolioId");
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "PostId");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4862828c-bea0-4b29-888e-1e243b98ac65", "6e56979f-d1bb-4408-bea7-34dfb21e4375", "Subscriber", "SUBSCRIBER" },
                    { "5a4108f8-ed60-4228-b829-3821e5a592f2", "cb3e46e4-d2db-45bb-bd7c-2f44d96d3d8d", "Editor", "EDITOR" },
                    { "d8075beb-6bb3-4d8f-989c-e271478f4119", "1071db92-a463-4126-b7d2-72848faa8d89", "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 4, 28, 16, 3, 34, 911, DateTimeKind.Local).AddTicks(3170), new DateTime(2022, 4, 28, 16, 3, 34, 911, DateTimeKind.Local).AddTicks(3170) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 4, 28, 16, 3, 34, 911, DateTimeKind.Local).AddTicks(3180), new DateTime(2022, 4, 28, 16, 3, 34, 911, DateTimeKind.Local).AddTicks(3180) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 4, 28, 16, 3, 34, 911, DateTimeKind.Local).AddTicks(3180), new DateTime(2022, 4, 28, 16, 3, 34, 911, DateTimeKind.Local).AddTicks(3180) });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PortifolioId",
                table: "Comments",
                column: "PortifolioId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4862828c-bea0-4b29-888e-1e243b98ac65");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a4108f8-ed60-4228-b829-3821e5a592f2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8075beb-6bb3-4d8f-989c-e271478f4119");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "833e7b98-d677-44fb-ac33-a91527ce0157", "af183b5a-1ea5-40a7-9dd2-4486ab132276", "Subscriber", "SUBSCRIBER" },
                    { "ad6bd18f-8934-4e82-9d2b-b4412f339942", "4f3dd380-6941-422d-8781-7f1046be0fa9", "Admin", "ADMIN" },
                    { "d69ce346-183f-48b2-9159-880ce821f37c", "18ffecf6-c964-42c1-aeff-659f279ad409", "Editor", "EDITOR" }
                });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 4, 28, 13, 59, 32, 775, DateTimeKind.Local).AddTicks(6860), new DateTime(2022, 4, 28, 13, 59, 32, 775, DateTimeKind.Local).AddTicks(6860) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 4, 28, 13, 59, 32, 775, DateTimeKind.Local).AddTicks(6860), new DateTime(2022, 4, 28, 13, 59, 32, 775, DateTimeKind.Local).AddTicks(6860) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 4, 28, 13, 59, 32, 775, DateTimeKind.Local).AddTicks(6870), new DateTime(2022, 4, 28, 13, 59, 32, 775, DateTimeKind.Local).AddTicks(6870) });
        }
    }
}
