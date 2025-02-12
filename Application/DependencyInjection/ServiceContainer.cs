﻿using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using ShopClothing.Application.Mapping;
using ShopClothing.Application.Services.Implementations.Authentication;
using ShopClothing.Application.Services.Implementations.Category;
using ShopClothing.Application.Services.Implementations.Product;
using ShopClothing.Application.Services.Interfaces.Authentication;
using ShopClothing.Application.Services.Interfaces.Category;
using ShopClothing.Application.Services.Interfaces.Product;
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
            services.AddScoped<ProductAttributesMappingAction>();

            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<RegisterUserValidator>();
            services.AddScoped<IValidationService, ValidationService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();


            return services;
        }
    }




}
