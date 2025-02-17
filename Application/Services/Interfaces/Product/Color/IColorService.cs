
using ShopClothing.Application.DTOs.Product.Color;

namespace ShopClothing.Application.Services.Interfaces.Product.Color
{
    public interface IColorService
    {
        Task<IEnumerable<GetColors>> GetAllAsync();
        Task<GetColors> GetByIdAsync(Guid id);
    }
}
