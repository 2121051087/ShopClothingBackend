using AutoMapper;
using ShopClothing.Application.DTOs;
using ShopClothing.Application.DTOs.Category;
using ShopClothing.Application.DTOs.Product;
using ShopClothing.Application.Services.Interfaces.Category;
using ShopClothing.Domain.Entities.Category;
using ShopClothing.Domain.Interface;
using ShopClothing.Domain.Interface.CategorySpecifics;


namespace ShopClothing.Application.Services.Implementations.Category
{
    public class CategoryService(IGeneric<Categories> CategoryInterface, IMapper mapper
       ,ICategorySpecifics categorySpecifics ) : ICategoryService

    {
        public async  Task<ServiceResponse> AddAsync(CreateCategory category)
        {
            var mappedData = mapper.Map<Categories>(category);
            int result = await CategoryInterface.AddAsync(mappedData);
            return  result > 0 ? new ServiceResponse(true, "Category Added Successfully")
                               : new ServiceResponse(false, "Category Not Added");
        }

        public async Task<ServiceResponse> DeleteAsync(Guid id)
        {
            int result = await CategoryInterface.DeleteAsync(id);

            return result > 0 ? new ServiceResponse(true, "Category Deleted Successfully")
                              : new ServiceResponse(false, "Category Not Deleted");
        }

        public async Task<IEnumerable<GetCategory>> GetAllAsync()
        {
            var Data = await CategoryInterface.GetAllAsync();

            if (!Data.Any()) return [];

            return mapper.Map<IEnumerable<GetCategory>>(Data);
        }

        public async Task<GetCategory> GetByIdAsync(Guid id)
        {
            var Data = await CategoryInterface.GetByIdAsync(id);
            if(Data == null) return null!;

            return mapper.Map<GetCategory>(Data);
        }
        public async Task<ServiceResponse> UpdateAsync(UpdateCategory category)
        {
           var mappedData = mapper.Map<Categories>(category);
            int result = await CategoryInterface.UpdateAsync(mappedData);
            return result > 0 ? new ServiceResponse(true, "Category Updated Successfully")
                              : new ServiceResponse(false, "Category Not Updated");
        }

        public async Task<IEnumerable<GetProduct>> GetProductsByCategory(Guid categoryId)
        {
           var products = await categorySpecifics.GetProductsByCategory(categoryId);
           
            if(!products.Any()) return [];

            return mapper.Map<IEnumerable<GetProduct>>(products);
        }
    }
}
