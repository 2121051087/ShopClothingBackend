using AutoMapper;
using ShopClothing.Application.DTOs.Category;
using ShopClothing.Application.DTOs.Identity;
using ShopClothing.Domain.Entities.Category;
using ShopClothing.Domain.Entities.Identity;


namespace ShopClothing.Application.Mapping
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Categories, GetCategory>()
                .AfterMap<CategoryMappingAction>();

            CreateMap<CreateCategory, Categories>();
            CreateMap<UpdateCategory, Categories>();


            CreateMap<RegisterUser, AppUser>();
            CreateMap<LoginUser, AppUser>();
        }
    }

}
