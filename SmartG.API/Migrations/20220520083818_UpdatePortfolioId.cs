using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartG.API.Migrations
{
    public partial class UpdatePortfolioId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2911371e-47d8-4b35-b17f-6cbe88551325");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "529e0e96-306b-4db8-8c27-b8e819d2da7e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d34bb5a1-09d2-436c-bac8-67f3056088bd");

            migrationBuilder.DropColumn(
                name: "PortifolioId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "PortifolioId",
                table: "ContentBlocks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2911371e-47d8-4b35-b17f-6cbe88551325", "5a59df57-140d-4e2f-b789-43271a3efd1a", "Editor", "EDITOR" },
                    { "529e0e96-306b-4db8-8c27-b8e819d2da7e", "771d9c2d-f232-4d82-b06d-77109db37306", "Subscriber", "SUBSCRIBER" },
                    { "d34bb5a1-09d2-436c-bac8-67f3056088bd", "a35ca754-1ea7-410b-a040-d61a829f0314", "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 5, 19, 14, 17, 23, 660, DateTimeKind.Local).AddTicks(6590), new DateTime(2022, 5, 19, 14, 17, 23, 660, DateTimeKind.Local).AddTicks(6590) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 5, 19, 14, 17, 23, 660, DateTimeKind.Local).AddTicks(6600), new DateTime(2022, 5, 19, 14, 17, 23, 660, DateTimeKind.Local).AddTicks(6600) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 5, 19, 14, 17, 23, 660, DateTimeKind.Local).AddTicks(6600), new DateTime(2022, 5, 19, 14, 17, 23, 660, DateTimeKind.Local).AddTicks(6600) });
        }
    }
}
