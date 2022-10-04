using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartG.API.Migrations
{
    public partial class GalleryIdOnImageModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
