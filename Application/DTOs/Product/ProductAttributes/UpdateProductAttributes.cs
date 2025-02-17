using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShopClothing.Application.DTOs.Product.ProductAttributes
{
    public class UpdateProductAttributes : ProductAttributesBase
    {
        public Guid Product_AttributeID { get; set; }

        [FromForm]
        public IFormFile? ImageFile { get; set; }
    }
}
