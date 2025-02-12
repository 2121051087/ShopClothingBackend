using Microsoft.AspNetCore.Http;

namespace ShopClothing.Application.DTOs.Product
{
    public class UpdateProduct : ProductBase
    {
        public Guid Id { get; set; }

        public IFormFile? Image { get; set; }
    }
}
