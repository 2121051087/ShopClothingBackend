
using ShopClothing.Application.DTOs.Product;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace ShopClothing.Application.DTOs.Category
{
    public class CategoryBase
    {
        [Required(ErrorMessage = "Category name is required")]
        public string? CategoryName { get; set; }

        [JsonIgnore]
        public ICollection<GetProduct> Products { get; set; } = [];
    }
}
