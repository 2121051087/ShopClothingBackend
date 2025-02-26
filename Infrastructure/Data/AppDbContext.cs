using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopClothing.Domain.Entities.Cart;
using ShopClothing.Domain.Entities.Category;
using ShopClothing.Domain.Entities.Identity;
using ShopClothing.Domain.Entities.Order;
using ShopClothing.Domain.Entities.Payment;
using ShopClothing.Domain.Entities.Product;
using System.Reflection.Emit;

namespace ShopClothing.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Products> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Product_Attributes> Product_Attributes { get; set; }
        public DbSet<Sizes> Sizes { get; set; }
        public DbSet<Colors> Colors { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }


        public DbSet<Carts> Carts { get; set; }
        public DbSet<CartItems> CartItems { get; set; }


        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Transactions> Transactions { get; set; }

        public DbSet<Orders> Orders { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }




        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            
            builder.Entity<IdentityRole>()
               .HasData(
               new IdentityRole
               {
                   Id = Guid.NewGuid().ToString(),
                   Name = "Admin",
                   NormalizedName = "ADMIN"
               },
               new IdentityRole
               {
                   Id = Guid.NewGuid().ToString(),
                   Name = "User",
                   NormalizedName = "USER"
               }

             );

            // Colors Table
                   #region Seed Color Data
            var colorData = new (Guid ColorID,string ColorName, string ColorHexCode)[]
            {
                (Guid.NewGuid(), "Red", "#FF0000"),
                (Guid.NewGuid(), "Blue", "#0000FF"),
                (Guid.NewGuid(), "White", "#FFFFFF"),
                (Guid.NewGuid(), "Black", "#000000"),
                (Guid.NewGuid(), "Yellow", "#FFFF00"),
                (Guid.NewGuid(), "Green", "#008000"),
                (Guid.NewGuid(), "Purple", "#800080"),
                (Guid.NewGuid(), "Pink", "#FFC0CB"),
                (Guid.NewGuid(), "Orange", "#FFA500"),
                (Guid.NewGuid(), "Brown", "#A52A2A"),
                (Guid.NewGuid(), "Gray", "#808080"),
                (Guid.NewGuid(), "Silver", "#C0C0C0"),
                (Guid.NewGuid(), "Gold", "#FFD700")

            };

            var defaultColors = new List<Colors>();
            foreach (var item in colorData)
            {
                defaultColors.Add(new Colors
                {
                    ColorID = item.ColorID,
                    ColorName = item.ColorName,
                    ColorHexCode = item.ColorHexCode

                });
            }

            #endregion

            builder.Entity<Colors>().HasData(defaultColors);

            builder.Entity<Colors>(entity =>
            {
                entity.ToTable("Colors")
                      .HasKey(c => c.ColorID);

            });

            // Sizes Table
            #region Seed Size Data
            var sizeData = new (Guid SizeID, string SizeName)[]
            {
                (Guid.NewGuid(), "XS"),
                (Guid.NewGuid(), "S"),
                (Guid.NewGuid(), "M"),
                (Guid.NewGuid(), "L"),
                (Guid.NewGuid(), "XL"),
                (Guid.NewGuid(), "XXL"),
                (Guid.NewGuid(), "XXXL"),
               
            };
            var defaultSizes = new List<Sizes>();
            foreach (var item in sizeData)
            {
                defaultSizes.Add(new Sizes
                {
                    SizeID = item.SizeID,
                    SizeName = item.SizeName

                });
            }
            #endregion

            builder.Entity<Sizes>().HasData(defaultSizes);
            builder.Entity<Sizes>(entity =>
            {
                entity.ToTable("Sizes")
                      .HasKey(s => s.SizeID);
            });


            // Categories  Table
            builder.Entity<Categories>(
                entity =>
                {
                    entity.ToTable("Categories")
                    .HasKey(c => c.CategoryID);
                });



            // Products Table
            builder.Entity<Products>(entity =>
            {
                entity.ToTable("Products")
                .HasKey(p => p.ProductID);

                entity.HasOne( c => c.Categories)
                      .WithMany(p => p.Products)
                      .HasForeignKey(p => p.CategoryID)
                      .OnDelete(DeleteBehavior.Cascade);


            });


            // Product_Attributes Table
            builder.Entity<Product_Attributes>(entity =>
            {
                entity.ToTable("Product_Attributes")
                      .HasKey(pa => pa.Product_AttributeID);
            });

            //-- product && product_attributes
            builder.Entity<Product_Attributes>()
                .HasOne(p => p.Products)
                .WithMany(pa => pa.Product_Attributes)
                .HasForeignKey(pa => pa.ProductID)
                .OnDelete(DeleteBehavior.Cascade);
              
            //-- color && product_attributes
            builder.Entity<Product_Attributes>()
                .HasOne(c => c.Colors)
                .WithMany(pa => pa.Product_Attributes)
                .HasForeignKey(pa => pa.ColorID)
                .OnDelete(DeleteBehavior.Restrict);

            //-- size && product_attributes
            builder.Entity<Product_Attributes>()
                .HasOne(s => s.Sizes)
                .WithMany(pa => pa.Product_Attributes)
                .HasForeignKey(pa => pa.SizeID)
                .OnDelete(DeleteBehavior.Restrict);



            // Carts Table

            builder.Entity<Carts>(entity =>
            {
                entity.ToTable("Carts")
                      .HasKey(c => c.CartID);
            });


            builder.Entity<CartItems>(entity =>
            {
                entity.ToTable("CartItems")
                      .HasKey(ci => ci.CartItemID);
                entity.HasOne(c => c.Carts)
                      .WithMany(ci => ci.CartItems)
                      .HasForeignKey(ci => ci.CartID)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(p => p.Products)
                      .WithMany(ci => ci.CartItems)
                      .HasForeignKey(ci => ci.ProductID)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(pa => pa.Product_Attributes)
                      .WithMany(ci => ci.CartItems)
                      .HasForeignKey(ci => ci.Product_AttributeID)
                      .OnDelete(DeleteBehavior.Restrict);
            });


            // payment method table
            builder.Entity<PaymentMethod>(entity =>
            {
                entity.ToTable("PaymentMethods")
                      .HasKey(pm => pm.PaymentMethodID);
            });

            builder.Entity<PaymentMethod>()
                .HasData(
                new PaymentMethod
                {
                    PaymentMethodID = Guid.NewGuid(),
                    PaymentMethodName = "Cash On Delivery"
                },
                new PaymentMethod
                {
                    PaymentMethodID = Guid.NewGuid(),
                    PaymentMethodName = "Credit Card"
                },
                new PaymentMethod
                {
                    PaymentMethodID = Guid.NewGuid(),
                    PaymentMethodName = "Pay Pal"
                }
                );

            // transactions table

            builder.Entity<Transactions>(entity =>
            {
                entity.ToTable("Transactions")
                      .HasKey(t => t.TransactionID);

            });


            // order 

            builder.Entity<Orders>(entity =>
            {
                entity.ToTable("Orders")
                      .HasKey(o => o.OrderID);
                entity.HasOne(entity => entity.Transaction);
            });

            // orderDetail
            builder.Entity<OrderDetails>(entity =>
            {
                entity.ToTable("OrderDetails")
                      .HasKey(od => od.OrderDetailID);
                entity.HasOne(o => o.Order)
                      .WithMany(od => od.Details)
                      .HasForeignKey(od => od.OrderID)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(p => p.Products)
                      .WithMany(od => od.OrderDetails)
                      .HasForeignKey(od => od.ProductID)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(pa => pa.Product_Attributes)
                      .WithMany(od => od.OrderDetails)
                      .HasForeignKey(od => od.Product_AttributeID)
                      .OnDelete(DeleteBehavior.Restrict);
            });


            builder.Entity<Transactions>()
                   .Property(t => t.Amount)
                   .HasPrecision(18, 4); // 18 chữ số, 4 số sau dấu phẩy
        }

    }
}
