using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartG.API.Migrations
{
    public partial class AddedSgIdsOnPSP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Gallery_GalleryId",
                table: "Pages");

            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Image_ImageId",
                table: "Pages");

            migrationBuilder.DropForeignKey(
                name: "FK_Portfolios_Gallery_GalleryId",
                table: "Portfolios");

            migrationBuilder.DropForeignKey(
                name: "FK_Portfolios_Image_ImageId",
                table: "Portfolios");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Gallery_GalleryId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Image_ImageId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_GalleryId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_ImageId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Portfolios_GalleryId",
                table: "Portfolios");

            migrationBuilder.DropIndex(
                name: "IX_Portfolios_ImageId",
                table: "Portfolios");

            migrationBuilder.DropIndex(
                name: "IX_Pages_GalleryId",
                table: "Pages");

            migrationBuilder.DropIndex(
                name: "IX_Pages_ImageId",
                table: "Pages");

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

            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "Services",
                newName: "SgImageId");

            migrationBuilder.RenameColumn(
                name: "GalleryId",
                table: "Services",
                newName: "SgGalleryId");

            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "Portfolios",
                newName: "SgImageId");

            migrationBuilder.RenameColumn(
                name: "GalleryId",
                table: "Portfolios",
                newName: "SgGalleryId");

            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "Pages",
                newName: "SgImageId");

            migrationBuilder.RenameColumn(
                name: "GalleryId",
                table: "Pages",
                newName: "SgGalleryId");

            migrationBuilder.AddColumn<int>(
                name: "SgCategoryId",
                table: "Portfolios",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2e6112b7-90b4-4458-b639-924b2a58f510", "0707ca4d-755e-4f05-93a9-25f09b63fad4", "Editor", "EDITOR" },
                    { "2f9587b1-f7ca-488d-9727-e3b85fdd9f15", "2a22559f-3130-43d0-aef8-e495fbfb1d70", "Subscriber", "SUBSCRIBER" },
                    { "ec2a18a9-17a4-496e-8383-5970dec5f058", "c6bb2baa-6fe2-47f6-a8cf-ddbe38ce8bc6", "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 16, 21, 40, 32, 132, DateTimeKind.Local).AddTicks(5710), new DateTime(2022, 11, 16, 21, 40, 32, 132, DateTimeKind.Local).AddTicks(5710) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 16, 21, 40, 32, 132, DateTimeKind.Local).AddTicks(5710), new DateTime(2022, 11, 16, 21, 40, 32, 132, DateTimeKind.Local).AddTicks(5720) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 16, 21, 40, 32, 132, DateTimeKind.Local).AddTicks(5720), new DateTime(2022, 11, 16, 21, 40, 32, 132, DateTimeKind.Local).AddTicks(5720) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e6112b7-90b4-4458-b639-924b2a58f510");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f9587b1-f7ca-488d-9727-e3b85fdd9f15");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec2a18a9-17a4-496e-8383-5970dec5f058");

            migrationBuilder.DropColumn(
                name: "SgCategoryId",
                table: "Portfolios");

            migrationBuilder.RenameColumn(
                name: "SgImageId",
                table: "Services",
                newName: "ImageId");

            migrationBuilder.RenameColumn(
                name: "SgGalleryId",
                table: "Services",
                newName: "GalleryId");

            migrationBuilder.RenameColumn(
                name: "SgImageId",
                table: "Portfolios",
                newName: "ImageId");

            migrationBuilder.RenameColumn(
                name: "SgGalleryId",
                table: "Portfolios",
                newName: "GalleryId");

            migrationBuilder.RenameColumn(
                name: "SgImageId",
                table: "Pages",
                newName: "ImageId");

            migrationBuilder.RenameColumn(
                name: "SgGalleryId",
                table: "Pages",
                newName: "GalleryId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Services_GalleryId",
                table: "Services",
                column: "GalleryId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ImageId",
                table: "Services",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_GalleryId",
                table: "Portfolios",
                column: "GalleryId");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_ImageId",
                table: "Portfolios",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_GalleryId",
                table: "Pages",
                column: "GalleryId");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_ImageId",
                table: "Pages",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Gallery_GalleryId",
                table: "Pages",
                column: "GalleryId",
                principalTable: "Gallery",
                principalColumn: "GalleryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Image_ImageId",
                table: "Pages",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolios_Gallery_GalleryId",
                table: "Portfolios",
                column: "GalleryId",
                principalTable: "Gallery",
                principalColumn: "GalleryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolios_Image_ImageId",
                table: "Portfolios",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Gallery_GalleryId",
                table: "Services",
                column: "GalleryId",
                principalTable: "Gallery",
                principalColumn: "GalleryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Image_ImageId",
                table: "Services",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "ImageId");
        }
    }
}
