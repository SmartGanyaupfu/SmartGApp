using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartG.API.Migrations
{
    public partial class addedPortifolioImageGallery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                keyValue: "6cf2b35d-6dbc-4910-9f7e-9f2626b7a9f0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4e65e4b-f68f-4f92-83e1-046157bab3aa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d72e351b-bf7f-4f00-93c7-f0eef74f4e3f");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Portfolios");

            migrationBuilder.AddColumn<bool>(
                name: "IsFeatureImage",
                table: "Image",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "IsFeatureImage",
                table: "Image");

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
                    { "6cf2b35d-6dbc-4910-9f7e-9f2626b7a9f0", "0e5b20f1-d6cc-436b-9a8e-39f79f74c34d", "Subscriber", "SUBSCRIBER" },
                    { "a4e65e4b-f68f-4f92-83e1-046157bab3aa", "593ba097-7053-46b6-a6f8-75cebefd4f58", "Editor", "EDITOR" },
                    { "d72e351b-bf7f-4f00-93c7-f0eef74f4e3f", "35599a91-3b8b-40ea-be49-b87079bfc420", "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 6, 22, 17, 13, 10, 108, DateTimeKind.Local).AddTicks(2260), new DateTime(2022, 6, 22, 17, 13, 10, 108, DateTimeKind.Local).AddTicks(2260) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 6, 22, 17, 13, 10, 108, DateTimeKind.Local).AddTicks(2260), new DateTime(2022, 6, 22, 17, 13, 10, 108, DateTimeKind.Local).AddTicks(2260) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 6, 22, 17, 13, 10, 108, DateTimeKind.Local).AddTicks(2270), new DateTime(2022, 6, 22, 17, 13, 10, 108, DateTimeKind.Local).AddTicks(2270) });

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
    }
}
