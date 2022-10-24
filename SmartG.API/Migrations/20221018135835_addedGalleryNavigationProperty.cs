using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartG.API.Migrations
{
    public partial class addedGalleryNavigationProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "GalleryId",
                table: "Services",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GalleryId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GalleryId",
                table: "Portfolios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GalleryId",
                table: "Pages",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Services_GalleryId",
                table: "Services",
                column: "GalleryId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_GalleryId",
                table: "Posts",
                column: "GalleryId");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_GalleryId",
                table: "Portfolios",
                column: "GalleryId");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_GalleryId",
                table: "Pages",
                column: "GalleryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Gallery_GalleryId",
                table: "Pages",
                column: "GalleryId",
                principalTable: "Gallery",
                principalColumn: "GalleryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolios_Gallery_GalleryId",
                table: "Portfolios",
                column: "GalleryId",
                principalTable: "Gallery",
                principalColumn: "GalleryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Gallery_GalleryId",
                table: "Posts",
                column: "GalleryId",
                principalTable: "Gallery",
                principalColumn: "GalleryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Gallery_GalleryId",
                table: "Services",
                column: "GalleryId",
                principalTable: "Gallery",
                principalColumn: "GalleryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Gallery_GalleryId",
                table: "Pages");

            migrationBuilder.DropForeignKey(
                name: "FK_Portfolios_Gallery_GalleryId",
                table: "Portfolios");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Gallery_GalleryId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Gallery_GalleryId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_GalleryId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Posts_GalleryId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Portfolios_GalleryId",
                table: "Portfolios");

            migrationBuilder.DropIndex(
                name: "IX_Pages_GalleryId",
                table: "Pages");

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

            migrationBuilder.DropColumn(
                name: "GalleryId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "GalleryId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "GalleryId",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "GalleryId",
                table: "Pages");

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
        }
    }
}
