

using AutoMapper;
using ShopClothing.Application.DTOs.Product.Size;
using ShopClothing.Application.Services.Interfaces.Product.Size;
using ShopClothing.Domain.Entities.Product;
using ShopClothing.Domain.Interface;

namespace ShopClothing.Application.Services.Implementations.Product
{
    public class SizeService(IGeneric<Sizes> SizeInterface , IMapper mapper) : ISizeService
    {
        public async Task<IEnumerable<GetSizes>> GetAllAsync()
        {
           var mappedData = await SizeInterface.GetAllAsync();
            if (!mappedData.Any()) return [];

            return mapper.Map<IEnumerable<GetSizes>>(mappedData);
        }

        public async Task<GetSizes> GetByIdAsync(Guid id)
        {
            var mappedData = await SizeInterface.GetByIdAsync(id);
            if (mappedData == null) return null!;

            return mapper.Map<GetSizes>(mappedData);
        }
    }
}
