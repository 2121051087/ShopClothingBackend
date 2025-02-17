using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ShopClothing.Application.DTOs.Product.ProductAttributes;
using ShopClothing.Domain.Entities.Product;

namespace ShopClothing.Application.Mapping
{
    public class UpdateProductAttributesMappingAction : IMappingAction<UpdateProductAttributes, Product_Attributes>
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UpdateProductAttributesMappingAction(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public void Process(UpdateProductAttributes source, Product_Attributes destination, ResolutionContext context)
        {
            // Nếu có ảnh mới được upload
            if (source.ImageFile != null)
            {
                // Xóa ảnh cũ nếu có
                if (!string.IsNullOrEmpty(destination.ImageUrl))
                {
                    DeleteOldImage(destination.ImageUrl);
                }

                // Lưu ảnh mới
                destination.ImageUrl = SaveImage(source.ImageFile);
            }
        }

        private string SaveImage(IFormFile imageFile)
        {
            if (string.IsNullOrEmpty(_webHostEnvironment.WebRootPath))
            {
                throw new Exception("WebRootPath is null. Hãy đảm bảo thư mục wwwroot tồn tại.");
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

        private void DeleteOldImage(string imageUrl)
        {
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, imageUrl.TrimStart('/'));
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
