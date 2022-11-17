using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartG.API.Migrations
{
    public partial class RemovedImageIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Posts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Portfolios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0b1670db-f8e1-4e1d-8d33-93ddadb40966", "e9bf9264-588b-4b17-99be-d90991b2fa92", "Admin", "ADMIN" },
                    { "35e9cafb-0015-44dc-b11b-615936da7452", "5cf34c38-f911-4926-ab7b-c98d570823d6", "Editor", "EDITOR" },
                    { "e24f7d49-c0b0-4212-bc58-84568c38d0a0", "d0e93b53-675b-4677-9f41-5770c3e239b8", "Subscriber", "SUBSCRIBER" }
                });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 15, 22, 32, 46, 110, DateTimeKind.Local).AddTicks(2860), new DateTime(2022, 11, 15, 22, 32, 46, 110, DateTimeKind.Local).AddTicks(2860) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 15, 22, 32, 46, 110, DateTimeKind.Local).AddTicks(2870), new DateTime(2022, 11, 15, 22, 32, 46, 110, DateTimeKind.Local).AddTicks(2870) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 15, 22, 32, 46, 110, DateTimeKind.Local).AddTicks(2870), new DateTime(2022, 11, 15, 22, 32, 46, 110, DateTimeKind.Local).AddTicks(2870) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b1670db-f8e1-4e1d-8d33-93ddadb40966");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35e9cafb-0015-44dc-b11b-615936da7452");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e24f7d49-c0b0-4212-bc58-84568c38d0a0");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Portfolios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
