using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using ShopClothing.Application.Mapping;
using ShopClothing.Application.Services.Implementations.Authentication;
using ShopClothing.Application.Services.Implementations.Cart;
using ShopClothing.Application.Services.Implementations.Category;
using ShopClothing.Application.Services.Implementations.Order;
using ShopClothing.Application.Services.Implementations.PayPal;
using ShopClothing.Application.Services.Implementations.Product;
using ShopClothing.Application.Services.Interfaces.Authentication;
using ShopClothing.Application.Services.Interfaces.Basket;
using ShopClothing.Application.Services.Interfaces.Cart;
using ShopClothing.Application.Services.Interfaces.Category;
using ShopClothing.Application.Services.Interfaces.Order;
using ShopClothing.Application.Services.Interfaces.PayPal;
using ShopClothing.Application.Services.Interfaces.Product;
using ShopClothing.Application.Services.Interfaces.Product.Color;
using ShopClothing.Application.Services.Interfaces.Product.Size;
using ShopClothing.Application.Validations;
using ShopClothing.Application.Validations.Authentication;


namespace ShopClothing.Application.DependencyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingConfig));
            services.AddScoped<CategoryMappingAction>();
            services.AddScoped<CreateProductAttributesMappingAction>();
            services.AddScoped<UpdateProductAttributesMappingAction>();

            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<RegisterUserValidator>();
            services.AddScoped<IValidationService, ValidationService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IColorService, ColorService>();
            services.AddScoped<ISizeService, SizeService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<ICartItemService, CartItemService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddHttpClient<IPayPalService, PayPalService>();


            return services;
        }
    }




}
