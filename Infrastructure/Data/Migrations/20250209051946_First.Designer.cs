﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopClothing.Infrastructure.Data;

#nullable disable

namespace ShopClothing.Infrastructure.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250209051946_First")]
    partial class First
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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
                            Id = "7d4a09de-3fa4-4f2f-a96a-f7672bfe83ca",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "423e7460-f072-4e4c-806a-dbb6317c4965",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

            modelBuilder.Entity("ShopClothing.Domain.Entities.Category.Categories", b =>
                {
                    b.Property<Guid>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories", (string)null);
                });

            modelBuilder.Entity("ShopClothing.Domain.Entities.Identity.AppUser", b =>
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

                    b.Property<string>("FullName")
                        .IsRequired()
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

            modelBuilder.Entity("ShopClothing.Domain.Entities.Product.Colors", b =>
                {
                    b.Property<Guid>("ColorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ColorHexCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ColorName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ColorID");

                    b.ToTable("Colors", (string)null);

                    b.HasData(
                        new
                        {
                            ColorID = new Guid("735610df-47c3-4255-a33a-393a5859e773"),
                            ColorHexCode = "#FF0000",
                            ColorName = "Red"
                        },
                        new
                        {
                            ColorID = new Guid("68f35fdf-6f00-4ffa-bbdb-fb7cc784b278"),
                            ColorHexCode = "#0000FF",
                            ColorName = "Blue"
                        },
                        new
                        {
                            ColorID = new Guid("68459d1a-563f-4a6b-9a45-c55189b0370b"),
                            ColorHexCode = "#FFFFFF",
                            ColorName = "White"
                        },
                        new
                        {
                            ColorID = new Guid("a7b4d363-b39f-476c-8124-d3226d098d0b"),
                            ColorHexCode = "#000000",
                            ColorName = "Black"
                        },
                        new
                        {
                            ColorID = new Guid("ed984d84-31fe-4dce-9e09-82b9ee832655"),
                            ColorHexCode = "#FFFF00",
                            ColorName = "Yellow"
                        },
                        new
                        {
                            ColorID = new Guid("8fc31980-3ac5-45db-bebc-3dfffbfa666b"),
                            ColorHexCode = "#008000",
                            ColorName = "Green"
                        },
                        new
                        {
                            ColorID = new Guid("48e46b6b-da55-45d3-9d0c-bed95bbc5af1"),
                            ColorHexCode = "#800080",
                            ColorName = "Purple"
                        },
                        new
                        {
                            ColorID = new Guid("9c0d1a31-0f07-4bfd-8422-5fb67fa521bf"),
                            ColorHexCode = "#FFC0CB",
                            ColorName = "Pink"
                        },
                        new
                        {
                            ColorID = new Guid("7e0c9b16-f491-42fe-bcb8-7f5e38533ceb"),
                            ColorHexCode = "#FFA500",
                            ColorName = "Orange"
                        },
                        new
                        {
                            ColorID = new Guid("1b49af0a-e6d3-46f7-b818-1c3acbec255a"),
                            ColorHexCode = "#A52A2A",
                            ColorName = "Brown"
                        },
                        new
                        {
                            ColorID = new Guid("529b94b9-a559-44c0-8d7e-caa0a4401ce9"),
                            ColorHexCode = "#808080",
                            ColorName = "Gray"
                        },
                        new
                        {
                            ColorID = new Guid("933c00b5-5142-4f62-b29e-70dd45392e95"),
                            ColorHexCode = "#C0C0C0",
                            ColorName = "Silver"
                        },
                        new
                        {
                            ColorID = new Guid("be646020-e240-45c6-9bf5-f57e182908b1"),
                            ColorHexCode = "#FFD700",
                            ColorName = "Gold"
                        });
                });

            modelBuilder.Entity("ShopClothing.Domain.Entities.Product.Product_Attributes", b =>
                {
                    b.Property<Guid>("Product_AttributeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ColorID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<Guid>("ProductID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("SizeID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Product_AttributeID");

                    b.HasIndex("ColorID");

                    b.HasIndex("ProductID");

                    b.HasIndex("SizeID");

                    b.ToTable("Product_Attributes", (string)null);
                });

            modelBuilder.Entity("ShopClothing.Domain.Entities.Product.Products", b =>
                {
                    b.Property<Guid>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProductDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("ShopClothing.Domain.Entities.Product.Sizes", b =>
                {
                    b.Property<Guid>("SizeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SizeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SizeID");

                    b.ToTable("Sizes", (string)null);

                    b.HasData(
                        new
                        {
                            SizeID = new Guid("855ab87e-df37-42cf-a986-4c0a61f2e363"),
                            SizeName = "XS"
                        },
                        new
                        {
                            SizeID = new Guid("edb7a952-68cc-49a9-8379-769d1a205793"),
                            SizeName = "S"
                        },
                        new
                        {
                            SizeID = new Guid("72013087-3c06-45d6-a07a-407acd13c885"),
                            SizeName = "M"
                        },
                        new
                        {
                            SizeID = new Guid("5d596bfa-dab9-42d4-af9b-aaec14e668b4"),
                            SizeName = "L"
                        },
                        new
                        {
                            SizeID = new Guid("8124b5fe-fcf2-412b-9c19-c678ffcb8310"),
                            SizeName = "XL"
                        },
                        new
                        {
                            SizeID = new Guid("37719386-2a51-4aa5-952b-59e28e6fb0e9"),
                            SizeName = "XXL"
                        },
                        new
                        {
                            SizeID = new Guid("23dd0bda-acd5-4299-883e-66878e598a22"),
                            SizeName = "XXXL"
                        });
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
                    b.HasOne("ShopClothing.Domain.Entities.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ShopClothing.Domain.Entities.Identity.AppUser", null)
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

                    b.HasOne("ShopClothing.Domain.Entities.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ShopClothing.Domain.Entities.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ShopClothing.Domain.Entities.Product.Product_Attributes", b =>
                {
                    b.HasOne("ShopClothing.Domain.Entities.Product.Colors", "Colors")
                        .WithMany("Product_Attributes")
                        .HasForeignKey("ColorID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ShopClothing.Domain.Entities.Product.Products", "Products")
                        .WithMany("Product_Attributes")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopClothing.Domain.Entities.Product.Sizes", "Sizes")
                        .WithMany("Product_Attributes")
                        .HasForeignKey("SizeID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Colors");

                    b.Navigation("Products");

                    b.Navigation("Sizes");
                });

            modelBuilder.Entity("ShopClothing.Domain.Entities.Product.Products", b =>
                {
                    b.HasOne("ShopClothing.Domain.Entities.Category.Categories", "Categories")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categories");
                });

            modelBuilder.Entity("ShopClothing.Domain.Entities.Category.Categories", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ShopClothing.Domain.Entities.Product.Colors", b =>
                {
                    b.Navigation("Product_Attributes");
                });

            modelBuilder.Entity("ShopClothing.Domain.Entities.Product.Products", b =>
                {
                    b.Navigation("Product_Attributes");
                });

            modelBuilder.Entity("ShopClothing.Domain.Entities.Product.Sizes", b =>
                {
                    b.Navigation("Product_Attributes");
                });
#pragma warning restore 612, 618
        }
    }
}
