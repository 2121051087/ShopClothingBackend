using System.Text.Json.Serialization;

namespace ShopClothing.Application.DTOs.Product.ProductAttributes
{
    public class GetSizes
    {
        public Guid SizeID { get; set; }

        public string? SizeName { get; set; }

        [JsonIgnore]
        public ICollection<ProductAttributesBase>? ProductAttributes { get; set; }
    }
}
