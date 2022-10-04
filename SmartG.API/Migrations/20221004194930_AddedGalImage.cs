using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartG.API.Migrations
{
    public partial class AddedGalImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Gallery_GalleryId",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_GalleryId",
                table: "Image");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3fa1d169-8b89-46fd-966a-3cd685bfee18");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db4864b1-f6f0-4552-b4f1-e3ec5031949b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e00a4df5-001e-4058-b271-3b56ee19bc30");

            migrationBuilder.DropColumn(
                name: "GalleryId",
                table: "Image");

            migrationBuilder.CreateTable(
                name: "GalleryImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AltText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GalleryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GalleryImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GalleryImage_Gallery_GalleryId",
                        column: x => x.GalleryId,
                        principalTable: "Gallery",
                        principalColumn: "GalleryId");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2537c728-1794-49b1-9a7f-437da2fa3c03", "6a6bdcc0-17fe-4bd3-b626-75d06ec270a9", "Subscriber", "SUBSCRIBER" },
                    { "aae01ad4-3bc6-4f28-ba09-514cc4b50df0", "1667bd61-7a0a-4b00-90a1-916ad448e024", "Editor", "EDITOR" },
                    { "c4d9f62c-071d-475b-8883-235cd5d1e557", "42afc1ad-2033-4702-ab8e-40d8504d07be", "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 10, 4, 21, 49, 29, 904, DateTimeKind.Local).AddTicks(840), new DateTime(2022, 10, 4, 21, 49, 29, 904, DateTimeKind.Local).AddTicks(840) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 10, 4, 21, 49, 29, 904, DateTimeKind.Local).AddTicks(850), new DateTime(2022, 10, 4, 21, 49, 29, 904, DateTimeKind.Local).AddTicks(850) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 10, 4, 21, 49, 29, 904, DateTimeKind.Local).AddTicks(850), new DateTime(2022, 10, 4, 21, 49, 29, 904, DateTimeKind.Local).AddTicks(850) });

            migrationBuilder.CreateIndex(
                name: "IX_GalleryImage_GalleryId",
                table: "GalleryImage",
                column: "GalleryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GalleryImage");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2537c728-1794-49b1-9a7f-437da2fa3c03");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aae01ad4-3bc6-4f28-ba09-514cc4b50df0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4d9f62c-071d-475b-8883-235cd5d1e557");

            migrationBuilder.AddColumn<int>(
                name: "GalleryId",
                table: "Image",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3fa1d169-8b89-46fd-966a-3cd685bfee18", "ae83dedd-d410-4cc0-8ae9-7da7b2560161", "Editor", "EDITOR" },
                    { "db4864b1-f6f0-4552-b4f1-e3ec5031949b", "c9641ade-b10e-4d8e-98f3-fc3a283f9fcf", "Subscriber", "SUBSCRIBER" },
                    { "e00a4df5-001e-4058-b271-3b56ee19bc30", "26157a2a-4c20-489f-9d4c-71927a8f02bd", "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 10, 4, 12, 22, 38, 75, DateTimeKind.Local).AddTicks(1170), new DateTime(2022, 10, 4, 12, 22, 38, 75, DateTimeKind.Local).AddTicks(1170) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 10, 4, 12, 22, 38, 75, DateTimeKind.Local).AddTicks(1180), new DateTime(2022, 10, 4, 12, 22, 38, 75, DateTimeKind.Local).AddTicks(1180) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 10, 4, 12, 22, 38, 75, DateTimeKind.Local).AddTicks(1180), new DateTime(2022, 10, 4, 12, 22, 38, 75, DateTimeKind.Local).AddTicks(1190) });

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
    }
}
