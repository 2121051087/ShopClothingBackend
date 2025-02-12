using AutoMapper;
using ShopClothing.Application.DTOs;
using ShopClothing.Application.DTOs.Product;
using ShopClothing.Application.Services.Interfaces.Product;
using ShopClothing.Domain.Entities.Product;
using ShopClothing.Domain.Interface;

namespace ShopClothing.Application.Services.Implementations.Product
{
    public class ProductService(IGeneric<Products> ProductInterface, IMapper mapper
        ,IGeneric<Product_Attributes> Product_AttributesInterfaces) : IProductService
    {
        public async Task<ServiceResponse> AddAsync(CreateProduct product)
        {
            var mappedData = mapper.Map<Products>(product);
            int result = await ProductInterface.AddAsync(mappedData);
            
            if(result <= 0) return new ServiceResponse(false, "Product Not Added");

            var attributesList = product.CreateProductAttributes?.Select(attr =>
            {
                var mappedAttr = mapper.Map<Product_Attributes>(attr);
                mappedAttr.ProductID = mappedData.ProductID; 
                return mappedAttr;
            }).ToList();



            if (attributesList != null && attributesList.Any())
            {
                await Product_AttributesInterfaces.AddRangeAsync(attributesList);
            }
            return new ServiceResponse(true, "Product & Attributes Added");

        }

        public Task<ServiceResponse> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetProduct>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetProduct> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse> UpdateAsync(UpdateProduct product)
        {
            throw new NotImplementedException();
        }
    }
}
