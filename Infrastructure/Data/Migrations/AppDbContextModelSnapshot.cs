﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopClothing.Infrastructure.Data;

#nullable disable

namespace ShopClothing.Infrastructure.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                            Id = "6e4673e8-a314-4943-a234-1c635864147b",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "8db341a6-d82c-4036-b0a4-9a1a4edd0ffa",
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
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

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
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ShopClothing.Domain.Entities.Cart.CartItems", b =>
                {
                    b.Property<Guid>("CartItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CartID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Product_AttributeID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("QuantityBasket")
                        .HasColumnType("int");

                    b.HasKey("CartItemID");

                    b.HasIndex("CartID");

                    b.HasIndex("ProductID");

                    b.HasIndex("Product_AttributeID");

                    b.ToTable("CartItems", (string)null);
                });

            modelBuilder.Entity("ShopClothing.Domain.Entities.Cart.Carts", b =>
                {
                    b.Property<Guid>("CartID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CartID");

                    b.ToTable("Carts", (string)null);
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

            modelBuilder.Entity("ShopClothing.Domain.Entities.Identity.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("ShopClothing.Domain.Entities.Order.Order", b =>
                {
                    b.Property<Guid>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DeliveryAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeliveryPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PaymentMethodID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("TransactionID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("OrderID");

                    b.HasIndex("PaymentMethodID");

                    b.HasIndex("TransactionID");

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("ShopClothing.Domain.Entities.Order.OrderDetails", b =>
                {
                    b.Property<Guid>("OrderDetailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("ProductID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Product_AttributeID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("QuantityBasket")
                        .HasColumnType("int");

                    b.HasKey("OrderDetailID");

                    b.HasIndex("OrderID");

                    b.HasIndex("ProductID");

                    b.HasIndex("Product_AttributeID");

                    b.ToTable("OrderDetails", (string)null);
                });

            modelBuilder.Entity("ShopClothing.Domain.Entities.Payment.PaymentMethod", b =>
                {
                    b.Property<Guid>("PaymentMethodID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PaymentMethodName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PaymentMethodID");

                    b.ToTable("PaymentMethods", (string)null);

                    b.HasData(
                        new
                        {
                            PaymentMethodID = new Guid("80ae6dcb-bd1f-424a-b8cb-d640dd9fd646"),
                            PaymentMethodName = "Cash On Delivery"
                        },
                        new
                        {
                            PaymentMethodID = new Guid("1549cd45-4fed-4e4b-b166-7c18e62a24d5"),
                            PaymentMethodName = "Credit Card"
                        },
                        new
                        {
                            PaymentMethodID = new Guid("181ebc9b-5a4d-43ee-9e0e-96bb4e25fe21"),
                            PaymentMethodName = "Pay Pal"
                        });
                });

            modelBuilder.Entity("ShopClothing.Domain.Entities.Payment.Transactions", b =>
                {
                    b.Property<Guid>("TransactionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PayerID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PaymentID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PaymentMethodID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PaymentReference")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TransactionID");

                    b.HasIndex("PaymentMethodID");

                    b.ToTable("Transactions", (string)null);
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
                            ColorID = new Guid("8ed0fa29-be99-41ed-9f12-6ec40a949525"),
                            ColorHexCode = "#FF0000",
                            ColorName = "Red"
                        },
                        new
                        {
                            ColorID = new Guid("5d8dae7d-1ad8-4594-89f6-6ab57f784723"),
                            ColorHexCode = "#0000FF",
                            ColorName = "Blue"
                        },
                        new
                        {
                            ColorID = new Guid("9e6d9483-972a-497f-8798-e87468ea1d72"),
                            ColorHexCode = "#FFFFFF",
                            ColorName = "White"
                        },
                        new
                        {
                            ColorID = new Guid("a5a78efc-f0a5-4bf6-8caa-bc1ce9b49ddb"),
                            ColorHexCode = "#000000",
                            ColorName = "Black"
                        },
                        new
                        {
                            ColorID = new Guid("3ea4aca1-ae34-44f1-b9b5-d3f4a006ec09"),
                            ColorHexCode = "#FFFF00",
                            ColorName = "Yellow"
                        },
                        new
                        {
                            ColorID = new Guid("557a665c-064d-4859-b7c3-66309aa225c9"),
                            ColorHexCode = "#008000",
                            ColorName = "Green"
                        },
                        new
                        {
                            ColorID = new Guid("2d478c3d-8f5c-4cf5-9ec1-f69239c9b188"),
                            ColorHexCode = "#800080",
                            ColorName = "Purple"
                        },
                        new
                        {
                            ColorID = new Guid("4be846a8-84cd-4128-956b-8fc7d716eda3"),
                            ColorHexCode = "#FFC0CB",
                            ColorName = "Pink"
                        },
                        new
                        {
                            ColorID = new Guid("62db93b1-e04d-47af-bd8c-3e097974343b"),
                            ColorHexCode = "#FFA500",
                            ColorName = "Orange"
                        },
                        new
                        {
                            ColorID = new Guid("8e3ca5c5-2e2e-4e69-92c8-d716ff540227"),
                            ColorHexCode = "#A52A2A",
                            ColorName = "Brown"
                        },
                        new
                        {
                            ColorID = new Guid("ad9f3768-b625-4f55-bb9f-d8882a213a15"),
                            ColorHexCode = "#808080",
                            ColorName = "Gray"
                        },
                        new
                        {
                            ColorID = new Guid("a84227c2-6885-4823-9417-0d350cc30580"),
                            ColorHexCode = "#C0C0C0",
                            ColorName = "Silver"
                        },
                        new
                        {
                            ColorID = new Guid("4faf3673-5210-435c-b993-20f0076f3e2a"),
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

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("ProductDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

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
                            SizeID = new Guid("d9fe57a3-a42f-46a5-9893-7b6c7a108b64"),
                            SizeName = "XS"
                        },
                        new
                        {
                            SizeID = new Guid("9ac5921b-f6c6-40ce-b431-8c1639bbd9dc"),
                            SizeName = "S"
                        },
                        new
                        {
                            SizeID = new Guid("2c164dc5-8e4b-476d-8c3f-f2756b7da668"),
                            SizeName = "M"
                        },
                        new
                        {
                            SizeID = new Guid("ffe0a99a-8a17-4801-914b-cec5fcdb0857"),
                            SizeName = "L"
                        },
                        new
                        {
                            SizeID = new Guid("4f99b3e7-db25-40fa-a00f-b1f581f78af7"),
                            SizeName = "XL"
                        },
                        new
                        {
                            SizeID = new Guid("493e3711-e98c-4e85-9f05-0b8393e57a18"),
                            SizeName = "XXL"
                        },
                        new
                        {
                            SizeID = new Guid("1ed2a862-4114-450e-894b-ab8f80b53cf4"),
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

            modelBuilder.Entity("ShopClothing.Domain.Entities.Cart.CartItems", b =>
                {
                    b.HasOne("ShopClothing.Domain.Entities.Cart.Carts", "Carts")
                        .WithMany("CartItems")
                        .HasForeignKey("CartID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopClothing.Domain.Entities.Product.Products", "Products")
                        .WithMany("CartItems")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ShopClothing.Domain.Entities.Product.Product_Attributes", "Product_Attributes")
                        .WithMany("CartItems")
                        .HasForeignKey("Product_AttributeID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Carts");

                    b.Navigation("Product_Attributes");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("ShopClothing.Domain.Entities.Order.Order", b =>
                {
                    b.HasOne("ShopClothing.Domain.Entities.Payment.PaymentMethod", "PaymentMethod")
                        .WithMany()
                        .HasForeignKey("PaymentMethodID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopClothing.Domain.Entities.Payment.Transactions", "Transaction")
                        .WithMany()
                        .HasForeignKey("TransactionID");

                    b.Navigation("PaymentMethod");

                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("ShopClothing.Domain.Entities.Order.OrderDetails", b =>
                {
                    b.HasOne("ShopClothing.Domain.Entities.Order.Order", "Order")
                        .WithMany("Details")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopClothing.Domain.Entities.Product.Products", "Products")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ShopClothing.Domain.Entities.Product.Product_Attributes", "Product_Attributes")
                        .WithMany("OrderDetails")
                        .HasForeignKey("Product_AttributeID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product_Attributes");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("ShopClothing.Domain.Entities.Payment.Transactions", b =>
                {
                    b.HasOne("ShopClothing.Domain.Entities.Payment.PaymentMethod", "PaymentMethod")
                        .WithMany()
                        .HasForeignKey("PaymentMethodID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaymentMethod");
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

            modelBuilder.Entity("ShopClothing.Domain.Entities.Cart.Carts", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("ShopClothing.Domain.Entities.Category.Categories", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ShopClothing.Domain.Entities.Order.Order", b =>
                {
                    b.Navigation("Details");
                });

            modelBuilder.Entity("ShopClothing.Domain.Entities.Product.Colors", b =>
                {
                    b.Navigation("Product_Attributes");
                });

            modelBuilder.Entity("ShopClothing.Domain.Entities.Product.Product_Attributes", b =>
                {
                    b.Navigation("CartItems");

                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("ShopClothing.Domain.Entities.Product.Products", b =>
                {
                    b.Navigation("CartItems");

                    b.Navigation("OrderDetails");

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
