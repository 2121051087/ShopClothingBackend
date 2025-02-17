using AutoMapper;
using ShopClothing.Application.DTOs;
using ShopClothing.Application.DTOs.Product;
using ShopClothing.Application.DTOs.Product.ProductAttributes;
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

        public async Task<ServiceResponse> DeleteAsync(Guid id)
        {
           int result = await ProductInterface.DeleteAsync(id);

            return result > 0 ? new ServiceResponse(true, "Product Deleted Successfully")
                              : new ServiceResponse(false, "Product Not Deleted");
        }

        public async Task<IEnumerable<GetProduct>> GetAllAsync()
        {
            var Data = await ProductInterface.GetAllAsync();
            if (!Data.Any()) return [];

            var productDto = mapper.Map<IEnumerable<GetProduct>>(Data);
            foreach (var product in productDto)
            {
                var attributes = await Product_AttributesInterfaces.GetAllAsync();
                product.GetProductAttributes = attributes
                    .Where(attr => attr.ProductID == product.ProductID)
                    .Select(attr => mapper.Map<GetProductAttributes>(attr))
                    .ToList();
            }

            return productDto;


        }

        public async Task<GetProduct> GetByIdAsync(Guid id)
        {
            var Data = await ProductInterface.GetByIdAsync(id);
            if (Data == null) return null!;

            var productDto = mapper.Map<GetProduct>(Data);
            var attributes = await Product_AttributesInterfaces.GetAllAsync();
            productDto.GetProductAttributes = attributes
                .Where(attr => attr.ProductID == id)
                .Select(attr => mapper.Map<GetProductAttributes>(attr))
                .ToList();

            return productDto;
        }

        public async Task<ServiceResponse> UpdateAsync(UpdateProduct product)
        {
            var mappedData = mapper.Map<Products>(product);
            int result = await ProductInterface.UpdateAsync(mappedData);

            if(result <= 0) return new ServiceResponse(false, "Product Not Updated");

            var attributesList = product.UpdateProductAttributes?.Select(attr =>
            {
                var mappedAttr = mapper.Map<Product_Attributes>(attr);
                mappedAttr.ProductID = mappedData.ProductID;
                return mappedAttr;
            }).ToList();

            if (attributesList != null && attributesList.Any())
            {
                await Product_AttributesInterfaces.AddRangeAsync(attributesList);
            }

            return new ServiceResponse(true, "Product & Attributes Updated");
        }
    }
}
