using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShopClothing.Application.DTOs.Product.ProductAttributes
{
    public class ProductAttributesBase
    {
        public Guid ProductID { get; set; }

        public Guid ColorID { get; set; }

        public Guid SizeID { get; set; }

        public int Quantity { get; set; }

        public string? ImageUrl { get; set; }

        public decimal Price { get; set; }


        [JsonIgnore]
        public GetProduct? GetProduct { get; set; }
        [JsonIgnore]
        public GetColors? GetColors { get; set; }
        [JsonIgnore]
        public GetSizes? GetSizes { get; set; }
    }
}
