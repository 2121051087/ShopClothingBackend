
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ShopClothing.Domain.Entities.Product
{
    public class Product_Attributes
    {
        [Key]
        public Guid Product_AttributeID { get; set; }

        public Guid ProductID { get; set; }

        public Guid ColorID { get; set; }

        public Guid SizeID { get; set; }
        
        public int Quantity { get; set; }

        public string? ImageUrl { get; set; }

      

        [JsonIgnore]
        public Products? Products { get; set; }
        [JsonIgnore]
        public Colors? Colors { get; set; }
        [JsonIgnore]
        public Sizes? Sizes { get; set; }

    }
}
