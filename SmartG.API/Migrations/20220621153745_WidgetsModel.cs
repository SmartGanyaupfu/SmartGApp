using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartG.API.Migrations
{
    public partial class WidgetsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09379cc0-9faa-49fd-a584-3fa2de3ffd33");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21416a93-154b-4b59-b86f-1b4107cb378c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd70d506-2842-49d6-85c3-6518444e752d");

            migrationBuilder.AddColumn<string>(
                name: "AltText",
                table: "Image",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Caption",
                table: "Image",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Image",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Widgets",
                columns: table => new
                {
                    WidgetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillBlock = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EducationBlock = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkBlock = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InterestBlock = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CvUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HireMeBlock = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FbUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GitHubUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwitterUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YouTubeUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstagramUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkedInUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FooterOne = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FooterTwo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FooterThree = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Widgets", x => x.WidgetId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "18464831-cfc3-4926-aa19-39ffe754c944", "d10b32ef-2c71-4d7e-9318-3a3248f452e8", "Admin", "ADMIN" },
                    { "8eaf9c21-69e4-4fad-98fa-5ea4a67daefe", "736ec674-0d6f-4890-9048-1eea23436c3b", "Editor", "EDITOR" },
                    { "ddab4b29-dcdc-45c6-a7e0-18187abf8298", "d2c86797-a172-47f1-83dd-4e53ef9cf5d9", "Subscriber", "SUBSCRIBER" }
                });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 6, 21, 17, 37, 45, 342, DateTimeKind.Local).AddTicks(8670), new DateTime(2022, 6, 21, 17, 37, 45, 342, DateTimeKind.Local).AddTicks(8670) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 6, 21, 17, 37, 45, 342, DateTimeKind.Local).AddTicks(8680), new DateTime(2022, 6, 21, 17, 37, 45, 342, DateTimeKind.Local).AddTicks(8680) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 6, 21, 17, 37, 45, 342, DateTimeKind.Local).AddTicks(8680), new DateTime(2022, 6, 21, 17, 37, 45, 342, DateTimeKind.Local).AddTicks(8680) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Widgets");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18464831-cfc3-4926-aa19-39ffe754c944");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8eaf9c21-69e4-4fad-98fa-5ea4a67daefe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ddab4b29-dcdc-45c6-a7e0-18187abf8298");

            migrationBuilder.DropColumn(
                name: "AltText",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "Caption",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Image");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "09379cc0-9faa-49fd-a584-3fa2de3ffd33", "0ac0b081-2290-46c4-9e9a-2ab2a857ce50", "Editor", "EDITOR" },
                    { "21416a93-154b-4b59-b86f-1b4107cb378c", "83694943-f8f9-4242-87a5-41a3be200408", "Admin", "ADMIN" },
                    { "cd70d506-2842-49d6-85c3-6518444e752d", "a7b79f52-9654-4d8c-93af-33e5f4c9688d", "Subscriber", "SUBSCRIBER" }
                });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 6, 18, 13, 59, 59, 388, DateTimeKind.Local).AddTicks(9620), new DateTime(2022, 6, 18, 13, 59, 59, 388, DateTimeKind.Local).AddTicks(9620) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 6, 18, 13, 59, 59, 388, DateTimeKind.Local).AddTicks(9630), new DateTime(2022, 6, 18, 13, 59, 59, 388, DateTimeKind.Local).AddTicks(9630) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 6, 18, 13, 59, 59, 388, DateTimeKind.Local).AddTicks(9630), new DateTime(2022, 6, 18, 13, 59, 59, 388, DateTimeKind.Local).AddTicks(9630) });
        }
    }
}
