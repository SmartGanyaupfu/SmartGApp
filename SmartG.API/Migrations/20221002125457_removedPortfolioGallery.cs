using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartG.API.Migrations
{
    public partial class removedPortfolioGallery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Portfolios_PortfolioId",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_PortfolioId",
                table: "Image");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2528e678-c53f-4cfe-8844-c2f61a11565c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "34162804-6cb8-4b20-826f-4ff1c5ec4168");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dda8ecaf-413e-4eb3-baf2-2b21dfee2942");

            migrationBuilder.DropColumn(
                name: "PortfolioId",
                table: "Image");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Portfolios",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0d4d461f-f901-43d5-b423-200a95301e69", "b1583748-f1c0-4065-9706-7bab903ac13e", "Editor", "EDITOR" },
                    { "6a64afd0-840c-4b79-91ff-aa84344357df", "cb76f9a2-12ca-426b-97cc-baa481c67e0e", "Subscriber", "SUBSCRIBER" },
                    { "d5c02194-9fb2-478b-8dba-8f7149f0b573", "64ac0e49-55b4-44d0-a759-892dfac4e3a4", "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 10, 2, 14, 54, 56, 966, DateTimeKind.Local).AddTicks(5750), new DateTime(2022, 10, 2, 14, 54, 56, 966, DateTimeKind.Local).AddTicks(5750) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 10, 2, 14, 54, 56, 966, DateTimeKind.Local).AddTicks(5760), new DateTime(2022, 10, 2, 14, 54, 56, 966, DateTimeKind.Local).AddTicks(5760) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 10, 2, 14, 54, 56, 966, DateTimeKind.Local).AddTicks(5760), new DateTime(2022, 10, 2, 14, 54, 56, 966, DateTimeKind.Local).AddTicks(5760) });

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_ImageId",
                table: "Portfolios",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolios_Image_ImageId",
                table: "Portfolios",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "ImageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Portfolios_Image_ImageId",
                table: "Portfolios");

            migrationBuilder.DropIndex(
                name: "IX_Portfolios_ImageId",
                table: "Portfolios");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d4d461f-f901-43d5-b423-200a95301e69");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a64afd0-840c-4b79-91ff-aa84344357df");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5c02194-9fb2-478b-8dba-8f7149f0b573");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Portfolios");

            migrationBuilder.AddColumn<Guid>(
                name: "PortfolioId",
                table: "Image",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2528e678-c53f-4cfe-8844-c2f61a11565c", "6c464068-0edc-4c77-8a50-650637f54b6b", "Editor", "EDITOR" },
                    { "34162804-6cb8-4b20-826f-4ff1c5ec4168", "68cc1e94-745d-4b8c-ade4-ff5194c214d3", "Admin", "ADMIN" },
                    { "dda8ecaf-413e-4eb3-baf2-2b21dfee2942", "d1c72bad-0d37-4d95-ba51-d5f686a14aea", "Subscriber", "SUBSCRIBER" }
                });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 9, 30, 22, 15, 2, 51, DateTimeKind.Local).AddTicks(8480), new DateTime(2022, 9, 30, 22, 15, 2, 51, DateTimeKind.Local).AddTicks(8480) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 9, 30, 22, 15, 2, 51, DateTimeKind.Local).AddTicks(8490), new DateTime(2022, 9, 30, 22, 15, 2, 51, DateTimeKind.Local).AddTicks(8490) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 9, 30, 22, 15, 2, 51, DateTimeKind.Local).AddTicks(8500), new DateTime(2022, 9, 30, 22, 15, 2, 51, DateTimeKind.Local).AddTicks(8500) });

            migrationBuilder.CreateIndex(
                name: "IX_Image_PortfolioId",
                table: "Image",
                column: "PortfolioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Portfolios_PortfolioId",
                table: "Image",
                column: "PortfolioId",
                principalTable: "Portfolios",
                principalColumn: "PortfolioId");
        }
    }
}
