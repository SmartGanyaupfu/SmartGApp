using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartG.API.Migrations
{
    public partial class ImageRel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Portifolios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Pages",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2540423e-98e5-43e0-9f28-b077ed9cedea", "9f8ddc95-cdb4-4f1f-afe5-6ac12e6208db", "Admin", "ADMIN" },
                    { "2fd6688d-1b66-42bf-9d81-029a31d74bf7", "9a4c140a-4838-461d-b169-af421550fb12", "Editor", "EDITOR" },
                    { "3d51b9bc-7308-4869-ac35-8002397edd06", "5db8aecb-3242-4074-b1e7-11e58bb22939", "Subscriber", "SUBSCRIBER" }
                });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 5, 9, 16, 25, 12, 651, DateTimeKind.Local).AddTicks(8520), new DateTime(2022, 5, 9, 16, 25, 12, 651, DateTimeKind.Local).AddTicks(8520) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 5, 9, 16, 25, 12, 651, DateTimeKind.Local).AddTicks(8520), new DateTime(2022, 5, 9, 16, 25, 12, 651, DateTimeKind.Local).AddTicks(8520) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 5, 9, 16, 25, 12, 651, DateTimeKind.Local).AddTicks(8530), new DateTime(2022, 5, 9, 16, 25, 12, 651, DateTimeKind.Local).AddTicks(8530) });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ImageId",
                table: "Posts",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Portifolios_ImageId",
                table: "Portifolios",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_ImageId",
                table: "Pages",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Image_ImageId",
                table: "Pages",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Portifolios_Image_ImageId",
                table: "Portifolios",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Image_ImageId",
                table: "Posts",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "ImageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Image_ImageId",
                table: "Pages");

            migrationBuilder.DropForeignKey(
                name: "FK_Portifolios_Image_ImageId",
                table: "Portifolios");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Image_ImageId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_ImageId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Portifolios_ImageId",
                table: "Portifolios");

            migrationBuilder.DropIndex(
                name: "IX_Pages_ImageId",
                table: "Pages");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2540423e-98e5-43e0-9f28-b077ed9cedea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2fd6688d-1b66-42bf-9d81-029a31d74bf7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d51b9bc-7308-4869-ac35-8002397edd06");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Portifolios");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Pages");

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
        }
    }
}
