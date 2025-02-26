using AutoMapper;
using ShopClothing.Application.DTOs.Cart;
using ShopClothing.Application.DTOs.Cart.CartItem;
using ShopClothing.Application.DTOs.Category;
using ShopClothing.Application.DTOs.Identity;
using ShopClothing.Application.DTOs.Order;
using ShopClothing.Application.DTOs.Product;
using ShopClothing.Application.DTOs.Product.Color;
using ShopClothing.Application.DTOs.Product.ProductAttributes;
using ShopClothing.Application.DTOs.Product.Size;
using ShopClothing.Domain.Entities.Cart;
using ShopClothing.Domain.Entities.Category;
using ShopClothing.Domain.Entities.Identity;
using ShopClothing.Domain.Entities.Order;
using ShopClothing.Domain.Entities.Product;


namespace ShopClothing.Application.Mapping
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            //  Category
            CreateMap<CreateCategory, Categories>();
            CreateMap<UpdateCategory, Categories>();
            CreateMap<Products, GetProductByCategoryID>();
            CreateMap<Categories, GetCategory>()
                .AfterMap<CategoryMappingAction>();


            //  Authentication 
            CreateMap<RegisterUser, AppUser>();
            CreateMap<LoginUser, AppUser>();


            //  Map config Add Product 
            CreateMap<CreateProduct, Products>()
                .ForMember(dest => dest.ProductID, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow.AddHours(7)))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow.AddHours(7)))
                .ForMember(dest => dest.Product_Attributes, opt => opt.Ignore());

            CreateMap<CreateProductAttribute, Product_Attributes>()
                .ForMember(dest => dest.Product_AttributeID, opt => opt.MapFrom(src => Guid.NewGuid()))
                .AfterMap<CreateProductAttributesMappingAction>();


            // Map config Get Product
            CreateMap<Products, GetProduct>();
            CreateMap<Product_Attributes, GetProductAttributes>();


            // Map config Update Product
            CreateMap<UpdateProduct, Products>()
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow.AddHours(7)));
            CreateMap<UpdateProductAttributes, Product_Attributes>()
                .AfterMap<UpdateProductAttributesMappingAction>();



            // Map config Color and Size

            CreateMap<Colors, GetColors>();
            CreateMap<Sizes, GetSizes>();


            //  Cart 
            CreateMap<CreateCartItem, CartItems>();
            CreateMap<CartItems, GetCartItem>();
            CreateMap<UpdateCartItem, CartItems>();


            CreateMap<Carts, GetCart>();
            CreateMap<UpdateCart, Carts>();
            CreateMap<UpdateCartItem, CartItems>();

            //  Order 
            CreateMap<CreateOrder, Orders>()
            .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => DateTime.UtcNow.AddHours(7)));

            CreateMap<GetCartItem, OrderDetails>()
                .ForMember(dest => dest.OrderID, opt => opt.Ignore()) 
                .ReverseMap();

        }
    }

}
