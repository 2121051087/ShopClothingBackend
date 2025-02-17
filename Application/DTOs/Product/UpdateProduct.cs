using Microsoft.AspNetCore.Http;
using ShopClothing.Application.DTOs.Product.ProductAttributes;

namespace ShopClothing.Application.DTOs.Product
{
    public class UpdateProduct : ProductBase
    {
        public Guid ProductID { get; set; }
        public ICollection<UpdateProductAttributes> UpdateProductAttributes { get; set; } = [];
    }
}
