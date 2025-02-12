
using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;

namespace ShopClothing.Application.DTOs.Product.ProductAttributes
{
    public class ProductAttributesBase
    {
        public Guid? ProductID { get; set; }

        public Guid ColorID { get; set; }

        public Guid SizeID { get; set; }

        public int Quantity { get; set; }

        

        //   public string? ImageUrl { get; set; }
        [JsonIgnore]
        public GetProduct? GetProduct { get; set; }
        [JsonIgnore]
        public GetColors? GetColors { get; set; }
        [JsonIgnore]
        public GetSizes? GetSizes { get; set; }
    }
}
