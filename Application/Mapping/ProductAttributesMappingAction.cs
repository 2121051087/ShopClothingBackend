using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ShopClothing.Application.DTOs.Product.ProductAttributes;
using ShopClothing.Domain.Entities.Product;

namespace ShopClothing.Application.Mapping
{
    public class ProductAttributesMappingAction : IMappingAction<CreateProductAttribute, Product_Attributes>
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductAttributesMappingAction(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public void Process(CreateProductAttribute source, Product_Attributes destination, ResolutionContext context)
        {
       
            if (source.ImageFile != null)
            {
                destination.ImageUrl = SaveImage(source.ImageFile);
            }
        }

        private string? SaveImage(IFormFile imageFile)
        {
            if (string.IsNullOrEmpty(_webHostEnvironment.WebRootPath))
            {
                throw new Exception("WebRootPath is null. Hãy đảm bảo thư mục wwwroot tồn tại và được cấu hình trong ASP.NET.");
            }

            var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(imageFile.FileName)}";
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                imageFile.CopyTo(fileStream);
            }

            return $"/images/{fileName}";
        }

    }
}
