using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartG.API.Migrations
{
    public partial class TestProductionDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19a895b0-4c66-4acb-8efb-152251dc0b35");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6cfbed4-dac9-451b-a76f-3323eda0858a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5177d9b-af7f-4426-a4e3-e672ce3b94f8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "12e907ae-907b-45d6-a009-e2856336b829", "c3792885-2ec4-4f9e-84c0-518299887bf2", "Subscriber", "SUBSCRIBER" },
                    { "29b82754-565e-4522-ad91-5b62131f1ad7", "9e4e46a4-c63e-4f9f-9e64-fc2f3ec80ca6", "Editor", "EDITOR" },
                    { "3d477147-ba22-4b0f-a581-7f9deff59c45", "e7f5cb70-c2e8-43a3-aeaa-b8a91e4cf449", "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 10, 25, 19, 9, 16, 676, DateTimeKind.Local).AddTicks(7870), new DateTime(2022, 10, 25, 19, 9, 16, 676, DateTimeKind.Local).AddTicks(7870) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 10, 25, 19, 9, 16, 676, DateTimeKind.Local).AddTicks(7870), new DateTime(2022, 10, 25, 19, 9, 16, 676, DateTimeKind.Local).AddTicks(7870) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 10, 25, 19, 9, 16, 676, DateTimeKind.Local).AddTicks(7880), new DateTime(2022, 10, 25, 19, 9, 16, 676, DateTimeKind.Local).AddTicks(7880) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12e907ae-907b-45d6-a009-e2856336b829");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29b82754-565e-4522-ad91-5b62131f1ad7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d477147-ba22-4b0f-a581-7f9deff59c45");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "19a895b0-4c66-4acb-8efb-152251dc0b35", "00616288-8804-456a-b17f-fbf25201c6c6", "Editor", "EDITOR" },
                    { "a6cfbed4-dac9-451b-a76f-3323eda0858a", "70051e1d-690d-4eaf-97bb-913b22ecdbbf", "Admin", "ADMIN" },
                    { "b5177d9b-af7f-4426-a4e3-e672ce3b94f8", "475823e2-ca6d-4221-8e52-860564f37a2c", "Subscriber", "SUBSCRIBER" }
                });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 10, 18, 15, 58, 35, 93, DateTimeKind.Local).AddTicks(6030), new DateTime(2022, 10, 18, 15, 58, 35, 93, DateTimeKind.Local).AddTicks(6030) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 10, 18, 15, 58, 35, 93, DateTimeKind.Local).AddTicks(6040), new DateTime(2022, 10, 18, 15, 58, 35, 93, DateTimeKind.Local).AddTicks(6040) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 10, 18, 15, 58, 35, 93, DateTimeKind.Local).AddTicks(6050), new DateTime(2022, 10, 18, 15, 58, 35, 93, DateTimeKind.Local).AddTicks(6050) });
        }
    }
}
