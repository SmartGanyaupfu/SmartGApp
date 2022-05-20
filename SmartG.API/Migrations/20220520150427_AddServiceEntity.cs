using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartG.API.Migrations
{
    public partial class AddServiceEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ca2ef81-c3cf-415d-ba3f-5389be609079");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f563266-148f-470b-aff3-72302e81cb1c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7309c293-1b33-4266-ace2-edabbaaa08fc");

            migrationBuilder.AddColumn<Guid>(
                name: "OfferedServiceId",
                table: "ContentBlocks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    OfferedServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Excerpt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaKeyWords = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    AuthorId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.OfferedServiceId);
                    table.ForeignKey(
                        name: "FK_Services_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "ImageId");
                });

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
                name: "IX_ContentBlocks_OfferedServiceId",
                table: "ContentBlocks",
                column: "OfferedServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ImageId",
                table: "Services",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentBlocks_Services_OfferedServiceId",
                table: "ContentBlocks",
                column: "OfferedServiceId",
                principalTable: "Services",
                principalColumn: "OfferedServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentBlocks_Services_OfferedServiceId",
                table: "ContentBlocks");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropIndex(
                name: "IX_ContentBlocks_OfferedServiceId",
                table: "ContentBlocks");

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
                name: "OfferedServiceId",
                table: "ContentBlocks");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2ca2ef81-c3cf-415d-ba3f-5389be609079", "a7c2474b-c843-48de-a04c-e2eff37cc05e", "Editor", "EDITOR" },
                    { "4f563266-148f-470b-aff3-72302e81cb1c", "b4897efd-be60-4633-8181-854014c6d2c5", "Admin", "ADMIN" },
                    { "7309c293-1b33-4266-ace2-edabbaaa08fc", "e10eef2a-2f3f-4038-99a7-9274f7fd8d96", "Subscriber", "SUBSCRIBER" }
                });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 5, 20, 10, 38, 17, 849, DateTimeKind.Local).AddTicks(5490), new DateTime(2022, 5, 20, 10, 38, 17, 849, DateTimeKind.Local).AddTicks(5490) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 5, 20, 10, 38, 17, 849, DateTimeKind.Local).AddTicks(5500), new DateTime(2022, 5, 20, 10, 38, 17, 849, DateTimeKind.Local).AddTicks(5500) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 5, 20, 10, 38, 17, 849, DateTimeKind.Local).AddTicks(5500), new DateTime(2022, 5, 20, 10, 38, 17, 849, DateTimeKind.Local).AddTicks(5500) });
        }
    }
}
