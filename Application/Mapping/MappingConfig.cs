using AutoMapper;
using ShopClothing.Application.DTOs.Category;
using ShopClothing.Application.DTOs.Identity;
using ShopClothing.Application.DTOs.Product;
using ShopClothing.Application.DTOs.Product.ProductAttributes;
using ShopClothing.Domain.Entities.Category;
using ShopClothing.Domain.Entities.Identity;
using ShopClothing.Domain.Entities.Product;


namespace ShopClothing.Application.Mapping
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            // Category
            CreateMap<CreateCategory, Categories>();
            CreateMap<UpdateCategory, Categories>();
            CreateMap<Products, GetProductByCategoryID>();
            CreateMap<Categories, GetCategory>()
                .AfterMap<CategoryMappingAction>();


            //Authentication 
            CreateMap<RegisterUser, AppUser>();
            CreateMap<LoginUser, AppUser>();


            // Product
            CreateMap<CreateProductAttribute, Product_Attributes>()
                .ForMember(dest => dest.Product_AttributeID, opt => opt.MapFrom(src => Guid.NewGuid()))
                .AfterMap<ProductAttributesMappingAction>();

            CreateMap<CreateProduct, Products>()
                .ForMember(dest => dest.ProductID, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow.AddHours(7)))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow.AddHours(7)))
                .ForMember(dest => dest.Product_Attributes, opt => opt.Ignore());






        }
    }

}
