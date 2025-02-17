
using ShopClothing.Application.DTOs.Product;
using ShopClothing.Application.DTOs;
using ShopClothing.Application.DTOs.Product.ProductAttributes;

namespace ShopClothing.Application.Services.Interfaces.Product
{
    public interface IProductAttributeService
    {
        Task<IEnumerable<GetProductAttributes>>? GetAllAsync();
        Task<GetProduct> GetByIdAsync(Guid id);
        Task<ServiceResponse> AddAsync(CreateProductAttribute productAttribute);
        Task<ServiceResponse> UpdateAsync(UpdateProductAttributes productAttribute);
        Task<ServiceResponse> DeleteAsync(Guid id);
    }
}
