using AutoMapper;
using ShopClothing.Application.DTOs.Category;
using ShopClothing.Domain.Entities.Category;
using ShopClothing.Domain.Interface.CategorySpecifics;


namespace ShopClothing.Application.Mapping
{
    public class CategoryMappingAction : IMappingAction<Categories, GetCategory>
    {
        private readonly ICategorySpecifics _categoryRepo;

        public CategoryMappingAction(ICategorySpecifics categoryRepo)

        {
            _categoryRepo = categoryRepo;
        }
        public void Process(Categories source, GetCategory destination, ResolutionContext context)
        {
           destination.CountNumberProductByCategory = _categoryRepo.CountNumberProductByCategory(source.CategoryID).GetAwaiter().GetResult();
        }
    }
}
