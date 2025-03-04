﻿using EntityFramework.Exceptions.SqlServer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ShopClothing.Application.Services.Interfaces.Logging;
using ShopClothing.Domain.Entities.Cart;
using ShopClothing.Domain.Entities.Category;
using ShopClothing.Domain.Entities.Identity;
using ShopClothing.Domain.Entities.Order;
using ShopClothing.Domain.Entities.Payment;
using ShopClothing.Domain.Entities.Product;
using ShopClothing.Domain.Interface;
using ShopClothing.Domain.Interface.Authentication;
using ShopClothing.Domain.Interface.Cart;
using ShopClothing.Domain.Interface.CategorySpecifics;
using ShopClothing.Domain.Interface.Order;
using ShopClothing.Domain.Interface.Transaction;
using ShopClothing.Infrastructure.Data;
using ShopClothing.Infrastructure.Repositories;
using ShopClothing.Infrastructure.Repositories.Authentication;
using ShopClothing.Infrastructure.Repositories.Cart;
using ShopClothing.Infrastructure.Repositories.CategorySpecifics;
using ShopClothing.Infrastructure.Repositories.Order;
using ShopClothing.Infrastructure.Repositories.Transaction;
using ShopClothing.Infrastructure.Services;
using System.Text;


namespace ShopClothing.Infrastructure.DependencyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddInfrastructureServices
            (this IServiceCollection services, IConfiguration config)
        {
            string connectionString = "Default";
            services.AddDbContext<AppDbContext>(option =>

            option.UseSqlServer(config.GetConnectionString(connectionString),
            sqlOption =>
            {
                sqlOption.MigrationsAssembly(typeof(ServiceContainer).Assembly.FullName);
                sqlOption.EnableRetryOnFailure();
            }).UseExceptionProcessor(),
            ServiceLifetime.Scoped );

            services.AddScoped(typeof(IAppLogger<>), typeof(SeriLogLoggerAdapter<>));

            services.AddDefaultIdentity<AppUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider;
                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredUniqueChars = 1;
            }).AddRoles<IdentityRole>()
              .AddEntityFrameworkStores<AppDbContext>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    RequireExpirationTime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = config["Jwt:Issuer"],
                    ValidAudience = config["Jwt:Audience"],
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!))
                };

            });


            services.AddScoped<IGeneric<Categories>, GenericRepository<Categories>>();
            services.AddScoped<IGeneric<Products>, GenericRepository<Products>>();
            services.AddScoped<IGeneric<Product_Attributes>, GenericRepository<Product_Attributes>>();
            services.AddScoped<IGeneric<Sizes>, GenericRepository<Sizes>>();
            services.AddScoped<IGeneric<Colors>, GenericRepository<Colors>>();


            services.AddScoped<ICategorySpecifics, CategorySpecificsRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();



            services.AddScoped<IGeneric<Carts>, GenericRepository<Carts>>();
            services.AddScoped<IGeneric<CartItems>, GenericRepository<CartItems>>();
            services.AddScoped<IGeneric<Orders>, GenericRepository<Orders>>();
            services.AddScoped<IGeneric<OrderDetails>, GenericRepository<OrderDetails>>();
            services.AddScoped<IGeneric<Transactions>, GenericRepository<Transactions>>();

            services.AddScoped<IUserManagement, UserManagementRepository>();
            services.AddScoped<IRoleManagement, RoleManagementRepository>();
            services.AddScoped<ITokenManagement, TokenManagementRepository>();


            return services;
        }

        public static IApplicationBuilder UseInfrastructureService(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
