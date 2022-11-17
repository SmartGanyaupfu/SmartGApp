﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartG.Repository;

#nullable disable

namespace SmartG.API.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "ec2a18a9-17a4-496e-8383-5970dec5f058",
                            ConcurrencyStamp = "c6bb2baa-6fe2-47f6-a8cf-ddbe38ce8bc6",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "2f9587b1-f7ca-488d-9727-e3b85fdd9f15",
                            ConcurrencyStamp = "2a22559f-3130-43d0-aef8-e495fbfb1d70",
                            Name = "Subscriber",
                            NormalizedName = "SUBSCRIBER"
                        },
                        new
                        {
                            Id = "2e6112b7-90b4-4458-b639-924b2a58f510",
                            ConcurrencyStamp = "0707ca4d-755e-4f05-93a9-25f09b63fad4",
                            Name = "Editor",
                            NormalizedName = "EDITOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("SmartG.Entities.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("AuthorId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slug")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("SmartG.Entities.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"), 1L, 1);

                    b.Property<bool>("Approved")
                        .HasColumnType("bit");

                    b.Property<string>("AuthorId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("Deleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("PortfolioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CommentId");

                    b.HasIndex("PortfolioId");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("SmartG.Entities.Models.ContentBlock", b =>
                {
                    b.Property<Guid>("ContentBlockId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("OfferedServiceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("PageId")
                        .HasColumnType("int");

                    b.Property<Guid?>("PortfolioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContentBlockId");

                    b.HasIndex("OfferedServiceId");

                    b.HasIndex("PageId");

                    b.HasIndex("PortfolioId");

                    b.HasIndex("PostId");

                    b.ToTable("ContentBlocks");
                });

            modelBuilder.Entity("SmartG.Entities.Models.Gallery", b =>
                {
                    b.Property<int>("GalleryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GalleryId"), 1L, 1);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GalleryId");

                    b.ToTable("Gallery");
                });

            modelBuilder.Entity("SmartG.Entities.Models.GalleryImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AltText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Caption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GalleryId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GalleryId");

                    b.ToTable("GalleryImage");
                });

            modelBuilder.Entity("SmartG.Entities.Models.Image", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ImageId"), 1L, 1);

                    b.Property<string>("AltText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AuthorId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Caption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsFeatureImage")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublicId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ImageId");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("SmartG.Entities.Models.OfferedService", b =>
                {
                    b.Property<Guid>("OfferedServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AuthorId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Excerpt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetaDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetaKeyWords")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SgGalleryId")
                        .HasColumnType("int");

                    b.Property<int?>("SgImageId")
                        .HasColumnType("int");

                    b.Property<string>("Slug")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OfferedServiceId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("SmartG.Entities.Models.Page", b =>
                {
                    b.Property<int>("PageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PageId"), 1L, 1);

                    b.Property<string>("AuthorId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Excerpt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetaDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetaKeyWords")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SgGalleryId")
                        .HasColumnType("int");

                    b.Property<int?>("SgImageId")
                        .HasColumnType("int");

                    b.Property<string>("Slug")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PageId");

                    b.ToTable("Pages");

                    b.HasData(
                        new
                        {
                            PageId = 1,
                            Content = "The innner part of the solar cookker is made of mirroes",
                            DateCreated = new DateTime(2022, 11, 16, 21, 40, 32, 132, DateTimeKind.Local).AddTicks(5710),
                            DateUpdated = new DateTime(2022, 11, 16, 21, 40, 32, 132, DateTimeKind.Local).AddTicks(5710),
                            Deleted = false,
                            MetaDescription = "The inner was the inner",
                            MetaKeyWords = "test,tets,done",
                            Slug = "home",
                            Title = "Home"
                        },
                        new
                        {
                            PageId = 2,
                            Content = "The innner part of the solar cookker is made of mirroes",
                            DateCreated = new DateTime(2022, 11, 16, 21, 40, 32, 132, DateTimeKind.Local).AddTicks(5710),
                            DateUpdated = new DateTime(2022, 11, 16, 21, 40, 32, 132, DateTimeKind.Local).AddTicks(5720),
                            Deleted = false,
                            MetaDescription = "The inner was the inner",
                            MetaKeyWords = "test,tets,done",
                            Slug = "about",
                            Title = "About"
                        },
                        new
                        {
                            PageId = 3,
                            Content = "The innner part of the solar cookker is made of mirroes",
                            DateCreated = new DateTime(2022, 11, 16, 21, 40, 32, 132, DateTimeKind.Local).AddTicks(5720),
                            DateUpdated = new DateTime(2022, 11, 16, 21, 40, 32, 132, DateTimeKind.Local).AddTicks(5720),
                            Deleted = false,
                            MetaDescription = "The inner was the inner",
                            MetaKeyWords = "test,tets,done",
                            Slug = "contact",
                            Title = "Contact"
                        });
                });

            modelBuilder.Entity("SmartG.Entities.Models.Portfolio", b =>
                {
                    b.Property<Guid>("PortfolioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AuthorId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Excerpt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetaDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetaKeyWords")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SgCategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("SgGalleryId")
                        .HasColumnType("int");

                    b.Property<int?>("SgImageId")
                        .HasColumnType("int");

                    b.Property<string>("Slug")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PortfolioId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Portfolios");
                });

            modelBuilder.Entity("SmartG.Entities.Models.Post", b =>
                {
                    b.Property<Guid>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AuthorId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Excerpt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetaDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetaKeyWords")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SgCategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("SgGalleryId")
                        .HasColumnType("int");

                    b.Property<int?>("SgImageId")
                        .HasColumnType("int");

                    b.Property<string>("Slug")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PostId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("SmartG.Entities.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("SmartG.Entities.Models.Widget", b =>
                {
                    b.Property<int>("WidgetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WidgetId"), 1L, 1);

                    b.Property<string>("ContactPage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CvUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EducationBlock")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FbUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FooterCopyrightBlock")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FooterOne")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FooterThree")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FooterTwo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GitHubUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HireMeBlock")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HomePage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HomePageSize")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstagramUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InterestBlock")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Intro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LearnToCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkedInUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LogoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostPageSize")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SkillBlock")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TwitterUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkBlock")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YouTubeUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WidgetId");

                    b.ToTable("Widgets");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SmartG.Entities.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SmartG.Entities.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartG.Entities.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SmartG.Entities.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SmartG.Entities.Models.Comment", b =>
                {
                    b.HasOne("SmartG.Entities.Models.Portfolio", "Portfolio")
                        .WithMany("Comments")
                        .HasForeignKey("PortfolioId");

                    b.HasOne("SmartG.Entities.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId");

                    b.Navigation("Portfolio");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("SmartG.Entities.Models.ContentBlock", b =>
                {
                    b.HasOne("SmartG.Entities.Models.OfferedService", null)
                        .WithMany("ContentBlocks")
                        .HasForeignKey("OfferedServiceId");

                    b.HasOne("SmartG.Entities.Models.Page", null)
                        .WithMany("ContentBlocks")
                        .HasForeignKey("PageId");

                    b.HasOne("SmartG.Entities.Models.Portfolio", null)
                        .WithMany("ContentBlocks")
                        .HasForeignKey("PortfolioId");

                    b.HasOne("SmartG.Entities.Models.Post", null)
                        .WithMany("ContentBlocks")
                        .HasForeignKey("PostId");
                });

            modelBuilder.Entity("SmartG.Entities.Models.GalleryImage", b =>
                {
                    b.HasOne("SmartG.Entities.Models.Gallery", null)
                        .WithMany("Images")
                        .HasForeignKey("GalleryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SmartG.Entities.Models.Portfolio", b =>
                {
                    b.HasOne("SmartG.Entities.Models.Category", null)
                        .WithMany("Portfolios")
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("SmartG.Entities.Models.Post", b =>
                {
                    b.HasOne("SmartG.Entities.Models.Category", null)
                        .WithMany("Posts")
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("SmartG.Entities.Models.Category", b =>
                {
                    b.Navigation("Portfolios");

                    b.Navigation("Posts");
                });

            modelBuilder.Entity("SmartG.Entities.Models.Gallery", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("SmartG.Entities.Models.OfferedService", b =>
                {
                    b.Navigation("ContentBlocks");
                });

            modelBuilder.Entity("SmartG.Entities.Models.Page", b =>
                {
                    b.Navigation("ContentBlocks");
                });

            modelBuilder.Entity("SmartG.Entities.Models.Portfolio", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("ContentBlocks");
                });

            modelBuilder.Entity("SmartG.Entities.Models.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("ContentBlocks");
                });
#pragma warning restore 612, 618
        }
    }
}
