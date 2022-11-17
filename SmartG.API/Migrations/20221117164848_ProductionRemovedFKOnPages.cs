using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartG.API.Migrations
{
    public partial class ProductionRemovedFKOnPages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "171e04cc-4b77-4843-af77-72aafbc5c4e9", "c1896ba4-dd11-43bf-a235-1a93821ad38a", "Subscriber", "SUBSCRIBER" },
                    { "371a58df-07d9-436e-b66c-b3673c3083c5", "9e83669c-0fa1-4e6f-ba1f-722b743e02c2", "Admin", "ADMIN" },
                    { "9c541b75-878f-41f6-ac70-530b0190a447", "6d8c5d52-1630-47e2-aed4-fee09469b5e6", "Editor", "EDITOR" }
                });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 17, 18, 48, 48, 196, DateTimeKind.Local).AddTicks(1490), new DateTime(2022, 11, 17, 18, 48, 48, 196, DateTimeKind.Local).AddTicks(1490) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 17, 18, 48, 48, 196, DateTimeKind.Local).AddTicks(1500), new DateTime(2022, 11, 17, 18, 48, 48, 196, DateTimeKind.Local).AddTicks(1500) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 17, 18, 48, 48, 196, DateTimeKind.Local).AddTicks(1500), new DateTime(2022, 11, 17, 18, 48, 48, 196, DateTimeKind.Local).AddTicks(1500) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "171e04cc-4b77-4843-af77-72aafbc5c4e9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "371a58df-07d9-436e-b66c-b3673c3083c5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c541b75-878f-41f6-ac70-530b0190a447");

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
    }
}
