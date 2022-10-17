using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartG.API.Migrations
{
    public partial class GalleryImageCanExistAlone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GalleryImage_Gallery_GalleryId",
                table: "GalleryImage");

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

            migrationBuilder.AlterColumn<int>(
                name: "GalleryId",
                table: "GalleryImage",
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
                    { "3fd135f9-3fca-4a67-8308-0011dd0cea6f", "006c94b6-51ea-4a40-b8c4-d1fc1ff96c20", "Subscriber", "SUBSCRIBER" },
                    { "7e50be85-806a-46f2-adbe-de10ca7699bf", "334b594e-44bf-4058-b57b-a0122db2dc0a", "Editor", "EDITOR" },
                    { "b11f3582-2406-41b9-886e-bdde441e3363", "6f67aec4-4111-48a4-ab47-3b4e4e66fe26", "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 10, 12, 18, 19, 26, 628, DateTimeKind.Local).AddTicks(1580), new DateTime(2022, 10, 12, 18, 19, 26, 628, DateTimeKind.Local).AddTicks(1580) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 10, 12, 18, 19, 26, 628, DateTimeKind.Local).AddTicks(1590), new DateTime(2022, 10, 12, 18, 19, 26, 628, DateTimeKind.Local).AddTicks(1590) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 10, 12, 18, 19, 26, 628, DateTimeKind.Local).AddTicks(1590), new DateTime(2022, 10, 12, 18, 19, 26, 628, DateTimeKind.Local).AddTicks(1590) });

            migrationBuilder.AddForeignKey(
                name: "FK_GalleryImage_Gallery_GalleryId",
                table: "GalleryImage",
                column: "GalleryId",
                principalTable: "Gallery",
                principalColumn: "GalleryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GalleryImage_Gallery_GalleryId",
                table: "GalleryImage");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3fd135f9-3fca-4a67-8308-0011dd0cea6f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e50be85-806a-46f2-adbe-de10ca7699bf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b11f3582-2406-41b9-886e-bdde441e3363");

            migrationBuilder.AlterColumn<int>(
                name: "GalleryId",
                table: "GalleryImage",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AddForeignKey(
                name: "FK_GalleryImage_Gallery_GalleryId",
                table: "GalleryImage",
                column: "GalleryId",
                principalTable: "Gallery",
                principalColumn: "GalleryId");
        }
    }
}
