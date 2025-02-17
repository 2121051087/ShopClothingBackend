using AutoMapper;
using ShopClothing.Application.DTOs.Product.Color;
using ShopClothing.Application.Services.Interfaces.Product.Color;
using ShopClothing.Domain.Entities.Product;
using ShopClothing.Domain.Interface;


namespace ShopClothing.Application.Services.Implementations.Product
{
    public class ColorService(IGeneric<Colors> ColorInterface, IMapper mapper) : IColorService

    {
        public async Task<IEnumerable<GetColors>> GetAllAsync()
        {
            var Data = await ColorInterface.GetAllAsync();
            if (!Data.Any()) return [];
            return mapper.Map<IEnumerable<GetColors>>(Data);    
        }

        public async Task<GetColors> GetByIdAsync(Guid id)
        {
            var Data = await ColorInterface.GetByIdAsync(id);
            if(Data == null) return null!;
            return mapper.Map<GetColors>(Data);
        }
    }
}
