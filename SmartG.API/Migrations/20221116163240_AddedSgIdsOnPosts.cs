using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartG.API.Migrations
{
    public partial class AddedSgIdsOnPosts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Gallery_GalleryId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Image_ImageId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_GalleryId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_ImageId",
                table: "Posts");

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

            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "Posts",
                newName: "SgImageId");

            migrationBuilder.RenameColumn(
                name: "GalleryId",
                table: "Posts",
                newName: "SgGalleryId");

            migrationBuilder.AddColumn<int>(
                name: "SgCategoryId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "020cfc65-29a2-4c00-8ec9-310634c626c8", "a821ab04-fa51-4de1-8eae-3ea2063031e3", "Editor", "EDITOR" },
                    { "a648d4ab-f82a-4d5c-a32a-d04cfa49de59", "3e581982-b3ec-4abb-8f6c-3328f87554c2", "Subscriber", "SUBSCRIBER" },
                    { "ff4a4f4d-f04f-4bec-a81f-b94be8adbbbb", "b3a9db3f-1a23-4b83-bf92-63730a5e0a83", "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 16, 18, 32, 40, 643, DateTimeKind.Local).AddTicks(9830), new DateTime(2022, 11, 16, 18, 32, 40, 643, DateTimeKind.Local).AddTicks(9830) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 16, 18, 32, 40, 643, DateTimeKind.Local).AddTicks(9840), new DateTime(2022, 11, 16, 18, 32, 40, 643, DateTimeKind.Local).AddTicks(9840) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 16, 18, 32, 40, 643, DateTimeKind.Local).AddTicks(9840), new DateTime(2022, 11, 16, 18, 32, 40, 643, DateTimeKind.Local).AddTicks(9840) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "020cfc65-29a2-4c00-8ec9-310634c626c8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a648d4ab-f82a-4d5c-a32a-d04cfa49de59");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff4a4f4d-f04f-4bec-a81f-b94be8adbbbb");

            migrationBuilder.DropColumn(
                name: "SgCategoryId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "SgImageId",
                table: "Posts",
                newName: "ImageId");

            migrationBuilder.RenameColumn(
                name: "SgGalleryId",
                table: "Posts",
                newName: "GalleryId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Posts_GalleryId",
                table: "Posts",
                column: "GalleryId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ImageId",
                table: "Posts",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Gallery_GalleryId",
                table: "Posts",
                column: "GalleryId",
                principalTable: "Gallery",
                principalColumn: "GalleryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Image_ImageId",
                table: "Posts",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "ImageId");
        }
    }
}
