using Microsoft.AspNetCore.Http;
using ShopClothing.Application.DTOs.Product.ProductAttributes;

namespace ShopClothing.Application.DTOs.Product
{
    public class CreateProduct : ProductBase
    {
       public ICollection<CreateProductAttribute> CreateProductAttributes { get; set; } = [];
    }
}
