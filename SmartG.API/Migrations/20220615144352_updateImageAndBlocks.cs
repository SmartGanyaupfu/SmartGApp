using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartG.API.Migrations
{
    public partial class updateImageAndBlocks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Pages_PageId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_Portfolios_PortfolioId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_Posts_PostId",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_PageId",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_PortfolioId",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_PostId",
                table: "Image");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6313f061-7871-484a-8bc4-e56a4343b427");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bda2dc84-dc7c-4d3a-9b4c-076d23923a45");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7b7e61b-8b1c-4114-9cb3-7bc48628b430");

            migrationBuilder.DropColumn(
                name: "PageId",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "PortfolioId",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Image");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Portfolios",
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

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ImageId",
                table: "Posts",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_ImageId",
                table: "Portfolios",
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
                name: "FK_Portfolios_Image_ImageId",
                table: "Portfolios",
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
                name: "FK_Portfolios_Image_ImageId",
                table: "Portfolios");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Image_ImageId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_ImageId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Portfolios_ImageId",
                table: "Portfolios");

            migrationBuilder.DropIndex(
                name: "IX_Pages_ImageId",
                table: "Pages");

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

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Pages");

            migrationBuilder.AddColumn<int>(
                name: "PageId",
                table: "Image",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PortfolioId",
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
                    { "6313f061-7871-484a-8bc4-e56a4343b427", "7cf84af2-c07e-4887-af32-3da94bca46be", "Admin", "ADMIN" },
                    { "bda2dc84-dc7c-4d3a-9b4c-076d23923a45", "5332c0ef-1caf-401f-ada2-6e1bc1354409", "Editor", "EDITOR" },
                    { "f7b7e61b-8b1c-4114-9cb3-7bc48628b430", "24deb0c0-ed8b-45e8-9651-d713da8db19c", "Subscriber", "SUBSCRIBER" }
                });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 5, 20, 17, 4, 27, 500, DateTimeKind.Local).AddTicks(6420), new DateTime(2022, 5, 20, 17, 4, 27, 500, DateTimeKind.Local).AddTicks(6420) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 5, 20, 17, 4, 27, 500, DateTimeKind.Local).AddTicks(6420), new DateTime(2022, 5, 20, 17, 4, 27, 500, DateTimeKind.Local).AddTicks(6420) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 5, 20, 17, 4, 27, 500, DateTimeKind.Local).AddTicks(6430), new DateTime(2022, 5, 20, 17, 4, 27, 500, DateTimeKind.Local).AddTicks(6430) });

            migrationBuilder.CreateIndex(
                name: "IX_Image_PageId",
                table: "Image",
                column: "PageId",
                unique: true,
                filter: "[PageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Image_PortfolioId",
                table: "Image",
                column: "PortfolioId",
                unique: true,
                filter: "[PortfolioId] IS NOT NULL");

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
                name: "FK_Image_Portfolios_PortfolioId",
                table: "Image",
                column: "PortfolioId",
                principalTable: "Portfolios",
                principalColumn: "PortfolioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Posts_PostId",
                table: "Image",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId");
        }
    }
}
