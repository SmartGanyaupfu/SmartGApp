using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartG.API.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "slug",
                table: "Posts",
                newName: "Slug");

            migrationBuilder.RenameColumn(
                name: "slug",
                table: "Pages",
                newName: "Slug");

            migrationBuilder.RenameColumn(
                name: "slug",
                table: "Categories",
                newName: "Slug");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0e81ad09-41cb-4e2b-981f-ac92b448a80b", "bfb8f867-9fa1-439e-9811-d3651e6aa2ad", "Admin", "ADMIN" },
                    { "97441034-da57-4c79-8605-08047676db1c", "4e1b9d12-e943-4073-b67b-252560b8ede8", "Subscriber", "SUBSCRIBER" },
                    { "d926ddf0-25c6-455b-b298-09b0304ad736", "fcb4c394-204c-4d1a-9e2a-23dce3859795", "Editor", "EDITOR" }
                });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "PageId", "AuthorId", "Content", "DateCreated", "DateUpdated", "Deleted", "Excerpt", "MetaDescription", "MetaKeyWords", "Slug", "Title" },
                values: new object[,]
                {
                    { 1, null, "The innner part of the solar cookker is made of mirroes", new DateTime(2022, 4, 18, 17, 10, 10, 622, DateTimeKind.Local).AddTicks(4090), new DateTime(2022, 4, 18, 17, 10, 10, 622, DateTimeKind.Local).AddTicks(4090), false, null, "The inner was the inner", "test,tets,done", "home", "Home" },
                    { 2, null, "The innner part of the solar cookker is made of mirroes", new DateTime(2022, 4, 18, 17, 10, 10, 622, DateTimeKind.Local).AddTicks(4100), new DateTime(2022, 4, 18, 17, 10, 10, 622, DateTimeKind.Local).AddTicks(4100), false, null, "The inner was the inner", "test,tets,done", "about", "About" },
                    { 3, null, "The innner part of the solar cookker is made of mirroes", new DateTime(2022, 4, 18, 17, 10, 10, 622, DateTimeKind.Local).AddTicks(4100), new DateTime(2022, 4, 18, 17, 10, 10, 622, DateTimeKind.Local).AddTicks(4110), false, null, "The inner was the inner", "test,tets,done", "contact", "Contact" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e81ad09-41cb-4e2b-981f-ac92b448a80b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97441034-da57-4c79-8605-08047676db1c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d926ddf0-25c6-455b-b298-09b0304ad736");

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "Slug",
                table: "Posts",
                newName: "slug");

            migrationBuilder.RenameColumn(
                name: "Slug",
                table: "Pages",
                newName: "slug");

            migrationBuilder.RenameColumn(
                name: "Slug",
                table: "Categories",
                newName: "slug");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
