using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartG.API.Migrations
{
    public partial class UpdateWidgetsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "ContactPage",
                table: "Widgets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FooterCopyrightBlock",
                table: "Widgets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomePage",
                table: "Widgets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomePageSize",
                table: "Widgets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Intro",
                table: "Widgets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LearnToCode",
                table: "Widgets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostPageSize",
                table: "Widgets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                table: "Widgets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Widgets",
                type: "nvarchar(max)",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "ContactPage",
                table: "Widgets");

            migrationBuilder.DropColumn(
                name: "FooterCopyrightBlock",
                table: "Widgets");

            migrationBuilder.DropColumn(
                name: "HomePage",
                table: "Widgets");

            migrationBuilder.DropColumn(
                name: "HomePageSize",
                table: "Widgets");

            migrationBuilder.DropColumn(
                name: "Intro",
                table: "Widgets");

            migrationBuilder.DropColumn(
                name: "LearnToCode",
                table: "Widgets");

            migrationBuilder.DropColumn(
                name: "PostPageSize",
                table: "Widgets");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "Widgets");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Widgets");

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
    }
}
