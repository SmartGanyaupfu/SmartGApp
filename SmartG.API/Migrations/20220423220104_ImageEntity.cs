using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartG.API.Migrations
{
    public partial class ImageEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Pages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    AuthorId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImageId);
                });

            migrationBuilder.CreateTable(
                name: "Portifolios",
                columns: table => new
                {
                    PortifolioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    table.PrimaryKey("PK_Portifolios", x => x.PortifolioId);
                    table.ForeignKey(
                        name: "FK_Portifolios_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "ImageId");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1dc3f814-dff8-4884-9924-5a0116c7b28f", "550bf9b1-b6bc-4df2-95d6-ca822a1c940c", "Editor", "EDITOR" },
                    { "379289ac-bfab-4714-9f6d-26ca75593dd0", "8e6bdc97-bf0e-4687-955f-15acbf403a7f", "Subscriber", "SUBSCRIBER" },
                    { "873960ca-fcbf-41c4-90b6-3ba1a8878dff", "b2162852-6930-42c4-aad2-716a46db326b", "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 4, 24, 0, 1, 4, 319, DateTimeKind.Local).AddTicks(8670), new DateTime(2022, 4, 24, 0, 1, 4, 319, DateTimeKind.Local).AddTicks(8680) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 4, 24, 0, 1, 4, 319, DateTimeKind.Local).AddTicks(8680), new DateTime(2022, 4, 24, 0, 1, 4, 319, DateTimeKind.Local).AddTicks(8680) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 4, 24, 0, 1, 4, 319, DateTimeKind.Local).AddTicks(8690), new DateTime(2022, 4, 24, 0, 1, 4, 319, DateTimeKind.Local).AddTicks(8690) });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ImageId",
                table: "Posts",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_ImageId",
                table: "Pages",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ImageId",
                table: "AspNetUsers",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Portifolios_ImageId",
                table: "Portifolios",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Images_ImageId",
                table: "AspNetUsers",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Images_ImageId",
                table: "Pages",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Images_ImageId",
                table: "Posts",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "ImageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Images_ImageId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Images_ImageId",
                table: "Pages");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Images_ImageId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "Portifolios");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Posts_ImageId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Pages_ImageId",
                table: "Pages");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ImageId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1dc3f814-dff8-4884-9924-5a0116c7b28f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "379289ac-bfab-4714-9f6d-26ca75593dd0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "873960ca-fcbf-41c4-90b6-3ba1a8878dff");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0e81ad09-41cb-4e2b-981f-ac92b448a80b", "bfb8f867-9fa1-439e-9811-d3651e6aa2ad", "Admin", "ADMIN" },
                    { "97441034-da57-4c79-8605-08047676db1c", "4e1b9d12-e943-4073-b67b-252560b8ede8", "Subscriber", "SUBSCRIBER" },
                    { "d926ddf0-25c6-455b-b298-09b0304ad736", "fcb4c394-204c-4d1a-9e2a-23dce3859795", "Editor", "EDITOR" }
                });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 4, 18, 17, 10, 10, 622, DateTimeKind.Local).AddTicks(4090), new DateTime(2022, 4, 18, 17, 10, 10, 622, DateTimeKind.Local).AddTicks(4090) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 4, 18, 17, 10, 10, 622, DateTimeKind.Local).AddTicks(4100), new DateTime(2022, 4, 18, 17, 10, 10, 622, DateTimeKind.Local).AddTicks(4100) });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 4, 18, 17, 10, 10, 622, DateTimeKind.Local).AddTicks(4100), new DateTime(2022, 4, 18, 17, 10, 10, 622, DateTimeKind.Local).AddTicks(4110) });
        }
    }
}
