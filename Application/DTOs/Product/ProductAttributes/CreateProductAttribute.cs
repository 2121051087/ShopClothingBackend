using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShopClothing.Application.DTOs.Product.ProductAttributes
{
    public class CreateProductAttribute : ProductAttributesBase
    {
        [FromForm]
        public IFormFile? ImageFile { get; set; }
    }
}
