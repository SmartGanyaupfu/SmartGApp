using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartG.API.Migrations
{
    public partial class ContentBlocks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "387e230c-1a7b-45d6-a0ee-0d2522ed9637");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73a5079e-eb2e-4581-923d-747e09b4de0b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d6a877d-e85d-4594-9be4-5232d839d7b7");

            migrationBuilder.CreateTable(
                name: "ContentBlocks",
                columns: table => new
                {
                    ContentBlockId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PortifolioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentBlocks", x => x.ContentBlockId);
                    table.ForeignKey(
                        name: "FK_ContentBlocks_Pages_PageId",
                        column: x => x.PageId,
                        principalTable: "Pages",
                        principalColumn: "PageId");
                    table.ForeignKey(
                        name: "FK_ContentBlocks_Portifolios_PortifolioId",
                        column: x => x.PortifolioId,
                        principalTable: "Portifolios",
                        principalColumn: "PortifolioId");
                    table.ForeignKey(
                        name: "FK_ContentBlocks_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "PostId");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "59757d89-2179-458d-ab06-bb1cc27e9296", "e6681011-5cde-41e4-87a8-f19d136032ba", "Subscriber", "SUBSCRIBER" },
                    { "78958246-99f4-40c1-a897-b4cf95004194", "4b376235-4a7e-43e6-bfc9-edca509df6d0", "Editor", "EDITOR" },
                    { "87ba9201-21af-4c9f-b128-c2380a265125", "ce59e8ab-ba68-40ff-80ee-7216c2881973", "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 5, 10, 22, 4, 16, 153, DateTimeKind.Local).AddTicks(6460), new DateTime(2022, 5, 10, 22, 4, 16, 153, DateTimeKind.Local).AddTicks(6460) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 5, 10, 22, 4, 16, 153, DateTimeKind.Local).AddTicks(6470), new DateTime(2022, 5, 10, 22, 4, 16, 153, DateTimeKind.Local).AddTicks(6470) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 5, 10, 22, 4, 16, 153, DateTimeKind.Local).AddTicks(6470), new DateTime(2022, 5, 10, 22, 4, 16, 153, DateTimeKind.Local).AddTicks(6470) });

            migrationBuilder.CreateIndex(
                name: "IX_ContentBlocks_PageId",
                table: "ContentBlocks",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentBlocks_PortifolioId",
                table: "ContentBlocks",
                column: "PortifolioId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentBlocks_PostId",
                table: "ContentBlocks",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContentBlocks");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59757d89-2179-458d-ab06-bb1cc27e9296");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78958246-99f4-40c1-a897-b4cf95004194");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87ba9201-21af-4c9f-b128-c2380a265125");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "387e230c-1a7b-45d6-a0ee-0d2522ed9637", "29152f6f-e138-4472-8357-8ac1599b7d1f", "Editor", "EDITOR" },
                    { "73a5079e-eb2e-4581-923d-747e09b4de0b", "f537d6d4-05c0-448d-b0df-ca7fa2b939ba", "Admin", "ADMIN" },
                    { "8d6a877d-e85d-4594-9be4-5232d839d7b7", "d2fa602d-c6ab-425e-bafe-7ad6d74fb71a", "Subscriber", "SUBSCRIBER" }
                });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 5, 9, 21, 55, 5, 816, DateTimeKind.Local).AddTicks(180), new DateTime(2022, 5, 9, 21, 55, 5, 816, DateTimeKind.Local).AddTicks(180) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 5, 9, 21, 55, 5, 816, DateTimeKind.Local).AddTicks(190), new DateTime(2022, 5, 9, 21, 55, 5, 816, DateTimeKind.Local).AddTicks(190) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 5, 9, 21, 55, 5, 816, DateTimeKind.Local).AddTicks(190), new DateTime(2022, 5, 9, 21, 55, 5, 816, DateTimeKind.Local).AddTicks(190) });
        }
    }
}
