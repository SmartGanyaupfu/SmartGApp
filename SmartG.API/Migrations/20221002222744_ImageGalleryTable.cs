using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartG.API.Migrations
{
    public partial class ImageGalleryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "187cd403-26ce-4029-90c4-5f310e3be3a4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c99b02b0-1b2a-4903-b4b3-f4d375290fea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d79a6689-ed06-40e2-9bc7-bc3fe61399b2");

            migrationBuilder.AddColumn<int>(
                name: "GalleryId",
                table: "Image",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Gallery",
                columns: table => new
                {
                    GalleryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gallery", x => x.GalleryId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "00c5866c-e484-445e-b101-86bdb18f2d5a", "ed2fc427-c064-45f7-8faf-89a3379afd39", "Editor", "EDITOR" },
                    { "332a1c46-841f-4463-a21d-3ceb630f873f", "df4fb6e9-8d49-4cf0-a51f-ac167f753cc9", "Admin", "ADMIN" },
                    { "b2d798a1-39a1-4cf0-8eab-e07a33d73d67", "4f2f1a54-92fb-4bff-a99b-c283cdcb2082", "Subscriber", "SUBSCRIBER" }
                });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 10, 3, 0, 27, 43, 511, DateTimeKind.Local).AddTicks(7100), new DateTime(2022, 10, 3, 0, 27, 43, 511, DateTimeKind.Local).AddTicks(7100) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 10, 3, 0, 27, 43, 511, DateTimeKind.Local).AddTicks(7110), new DateTime(2022, 10, 3, 0, 27, 43, 511, DateTimeKind.Local).AddTicks(7110) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 10, 3, 0, 27, 43, 511, DateTimeKind.Local).AddTicks(7110), new DateTime(2022, 10, 3, 0, 27, 43, 511, DateTimeKind.Local).AddTicks(7120) });

            migrationBuilder.CreateIndex(
                name: "IX_Image_GalleryId",
                table: "Image",
                column: "GalleryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Gallery_GalleryId",
                table: "Image",
                column: "GalleryId",
                principalTable: "Gallery",
                principalColumn: "GalleryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Gallery_GalleryId",
                table: "Image");

            migrationBuilder.DropTable(
                name: "Gallery");

            migrationBuilder.DropIndex(
                name: "IX_Image_GalleryId",
                table: "Image");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00c5866c-e484-445e-b101-86bdb18f2d5a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "332a1c46-841f-4463-a21d-3ceb630f873f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2d798a1-39a1-4cf0-8eab-e07a33d73d67");

            migrationBuilder.DropColumn(
                name: "GalleryId",
                table: "Image");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "187cd403-26ce-4029-90c4-5f310e3be3a4", "2a7af754-7765-4727-8f82-0b075e6ccf6a", "Editor", "EDITOR" },
                    { "c99b02b0-1b2a-4903-b4b3-f4d375290fea", "ae3d2290-50f1-497d-a1e9-4370de3caddb", "Subscriber", "SUBSCRIBER" },
                    { "d79a6689-ed06-40e2-9bc7-bc3fe61399b2", "e8cf04cd-daa6-4c3c-a805-cb99c931a773", "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 10, 3, 0, 21, 31, 498, DateTimeKind.Local).AddTicks(1530), new DateTime(2022, 10, 3, 0, 21, 31, 498, DateTimeKind.Local).AddTicks(1530) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 10, 3, 0, 21, 31, 498, DateTimeKind.Local).AddTicks(1540), new DateTime(2022, 10, 3, 0, 21, 31, 498, DateTimeKind.Local).AddTicks(1540) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 10, 3, 0, 21, 31, 498, DateTimeKind.Local).AddTicks(1550), new DateTime(2022, 10, 3, 0, 21, 31, 498, DateTimeKind.Local).AddTicks(1550) });
        }
    }
}
