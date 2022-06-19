using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartG.API.Migrations
{
    public partial class ImageIdInPages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a61892c-04b1-4c99-b75b-f8eeceebcdc3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5579b2eb-1c9e-4b66-afaf-638b7e6892ea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8060b6a4-fd44-4f0b-a30a-cf41e3b57ea7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "09379cc0-9faa-49fd-a584-3fa2de3ffd33", "0ac0b081-2290-46c4-9e9a-2ab2a857ce50", "Editor", "EDITOR" },
                    { "21416a93-154b-4b59-b86f-1b4107cb378c", "83694943-f8f9-4242-87a5-41a3be200408", "Admin", "ADMIN" },
                    { "cd70d506-2842-49d6-85c3-6518444e752d", "a7b79f52-9654-4d8c-93af-33e5f4c9688d", "Subscriber", "SUBSCRIBER" }
                });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 6, 18, 13, 59, 59, 388, DateTimeKind.Local).AddTicks(9620), new DateTime(2022, 6, 18, 13, 59, 59, 388, DateTimeKind.Local).AddTicks(9620) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 6, 18, 13, 59, 59, 388, DateTimeKind.Local).AddTicks(9630), new DateTime(2022, 6, 18, 13, 59, 59, 388, DateTimeKind.Local).AddTicks(9630) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 6, 18, 13, 59, 59, 388, DateTimeKind.Local).AddTicks(9630), new DateTime(2022, 6, 18, 13, 59, 59, 388, DateTimeKind.Local).AddTicks(9630) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09379cc0-9faa-49fd-a584-3fa2de3ffd33");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21416a93-154b-4b59-b86f-1b4107cb378c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd70d506-2842-49d6-85c3-6518444e752d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2a61892c-04b1-4c99-b75b-f8eeceebcdc3", "05c4780d-93c5-444b-a909-c76f910b7b03", "Subscriber", "SUBSCRIBER" },
                    { "5579b2eb-1c9e-4b66-afaf-638b7e6892ea", "c941d63e-0563-4851-85a5-9d794360ee4a", "Editor", "EDITOR" },
                    { "8060b6a4-fd44-4f0b-a30a-cf41e3b57ea7", "2ab50423-1ebf-4a73-a8f7-91ebe9ad0dbe", "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 6, 15, 16, 43, 51, 699, DateTimeKind.Local).AddTicks(2570), new DateTime(2022, 6, 15, 16, 43, 51, 699, DateTimeKind.Local).AddTicks(2570) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 6, 15, 16, 43, 51, 699, DateTimeKind.Local).AddTicks(2580), new DateTime(2022, 6, 15, 16, 43, 51, 699, DateTimeKind.Local).AddTicks(2580) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 6, 15, 16, 43, 51, 699, DateTimeKind.Local).AddTicks(2580), new DateTime(2022, 6, 15, 16, 43, 51, 699, DateTimeKind.Local).AddTicks(2580) });
        }
    }
}
