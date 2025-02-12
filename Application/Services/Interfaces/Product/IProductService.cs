using ShopClothing.Application.DTOs.Category;
using ShopClothing.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopClothing.Application.DTOs.Product;

namespace ShopClothing.Application.Services.Interfaces.Product
{
   public interface IProductService
    {
        Task<IEnumerable<GetProduct>> GetAllAsync();
        Task<GetProduct> GetByIdAsync(Guid id);
        Task<ServiceResponse> AddAsync(CreateProduct product);
        Task<ServiceResponse> UpdateAsync(UpdateProduct product);
        Task<ServiceResponse> DeleteAsync(Guid id);
    }
}
