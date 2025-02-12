using ShopClothing.Application.DTOs.Category;
using ShopClothing.Application.DTOs.Product;
using ShopClothing.Application.DTOs;


namespace ShopClothing.Application.Services.Interfaces.Category
{
    public  interface ICategoryService
    {
        Task<IEnumerable<GetCategory>> GetAllAsync();
        Task<GetCategory> GetByIdAsync(Guid id);
        Task<ServiceResponse> AddAsync(CreateCategory category);
        Task<ServiceResponse> UpdateAsync(UpdateCategory category);
        Task<ServiceResponse> DeleteAsync(Guid id);
        Task<IEnumerable<GetProductByCategoryID>> GetProductsByCategory(Guid categoryId);
    }
}
