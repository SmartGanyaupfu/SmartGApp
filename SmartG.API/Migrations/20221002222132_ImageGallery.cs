using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartG.API.Migrations
{
    public partial class ImageGallery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d4d461f-f901-43d5-b423-200a95301e69");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a64afd0-840c-4b79-91ff-aa84344357df");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5c02194-9fb2-478b-8dba-8f7149f0b573");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0d4d461f-f901-43d5-b423-200a95301e69", "b1583748-f1c0-4065-9706-7bab903ac13e", "Editor", "EDITOR" },
                    { "6a64afd0-840c-4b79-91ff-aa84344357df", "cb76f9a2-12ca-426b-97cc-baa481c67e0e", "Subscriber", "SUBSCRIBER" },
                    { "d5c02194-9fb2-478b-8dba-8f7149f0b573", "64ac0e49-55b4-44d0-a759-892dfac4e3a4", "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 10, 2, 14, 54, 56, 966, DateTimeKind.Local).AddTicks(5750), new DateTime(2022, 10, 2, 14, 54, 56, 966, DateTimeKind.Local).AddTicks(5750) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 10, 2, 14, 54, 56, 966, DateTimeKind.Local).AddTicks(5760), new DateTime(2022, 10, 2, 14, 54, 56, 966, DateTimeKind.Local).AddTicks(5760) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 10, 2, 14, 54, 56, 966, DateTimeKind.Local).AddTicks(5760), new DateTime(2022, 10, 2, 14, 54, 56, 966, DateTimeKind.Local).AddTicks(5760) });
        }
    }
}
