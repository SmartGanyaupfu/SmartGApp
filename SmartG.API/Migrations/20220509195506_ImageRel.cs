using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartG.API.Migrations
{
    public partial class ImageRel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Image_ImageId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ImageId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4862828c-bea0-4b29-888e-1e243b98ac65");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a4108f8-ed60-4228-b829-3821e5a592f2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8075beb-6bb3-4d8f-989c-e271478f4119");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "PageId",
                table: "Image",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PortifolioId",
                table: "Image",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PostId",
                table: "Image",
                type: "uniqueidentifier",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Image_PageId",
                table: "Image",
                column: "PageId",
                unique: true,
                filter: "[PageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Image_PortifolioId",
                table: "Image",
                column: "PortifolioId",
                unique: true,
                filter: "[PortifolioId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Image_PostId",
                table: "Image",
                column: "PostId",
                unique: true,
                filter: "[PostId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Pages_PageId",
                table: "Image",
                column: "PageId",
                principalTable: "Pages",
                principalColumn: "PageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Portifolios_PortifolioId",
                table: "Image",
                column: "PortifolioId",
                principalTable: "Portifolios",
                principalColumn: "PortifolioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Posts_PostId",
                table: "Image",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Pages_PageId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_Portifolios_PortifolioId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_Posts_PostId",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_PageId",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_PortifolioId",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_PostId",
                table: "Image");

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

            migrationBuilder.DropColumn(
                name: "PageId",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "PortifolioId",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Image");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4862828c-bea0-4b29-888e-1e243b98ac65", "6e56979f-d1bb-4408-bea7-34dfb21e4375", "Subscriber", "SUBSCRIBER" },
                    { "5a4108f8-ed60-4228-b829-3821e5a592f2", "cb3e46e4-d2db-45bb-bd7c-2f44d96d3d8d", "Editor", "EDITOR" },
                    { "d8075beb-6bb3-4d8f-989c-e271478f4119", "1071db92-a463-4126-b7d2-72848faa8d89", "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 4, 28, 16, 3, 34, 911, DateTimeKind.Local).AddTicks(3170), new DateTime(2022, 4, 28, 16, 3, 34, 911, DateTimeKind.Local).AddTicks(3170) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 4, 28, 16, 3, 34, 911, DateTimeKind.Local).AddTicks(3180), new DateTime(2022, 4, 28, 16, 3, 34, 911, DateTimeKind.Local).AddTicks(3180) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 4, 28, 16, 3, 34, 911, DateTimeKind.Local).AddTicks(3180), new DateTime(2022, 4, 28, 16, 3, 34, 911, DateTimeKind.Local).AddTicks(3180) });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ImageId",
                table: "AspNetUsers",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Image_ImageId",
                table: "AspNetUsers",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "ImageId");
        }
    }
}
