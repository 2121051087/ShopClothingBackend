using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopClothing.Domain.Entities.Category;
using ShopClothing.Domain.Entities.Identity;
using ShopClothing.Domain.Entities.Product;

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

        }

    }
}
