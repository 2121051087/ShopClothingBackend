using ShopClothing.Application.DTOs.Product.Size;

namespace ShopClothing.Application.Services.Interfaces.Product.Size
{
    public interface ISizeService
    {
        Task<IEnumerable<GetSizes>> GetAllAsync();
        Task<GetSizes> GetByIdAsync(Guid id);
    }
}
