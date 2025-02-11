using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShopClothing.Application.DTOs.Product.ProductAttributes
{
    public class GetColors
    {
        public Guid ColorID { get; set; }

        public string? ColorName { get; set; }

        public string? ColorHexCode { get; set; }


        [JsonIgnore]
        public ICollection<ProductAttributesBase>? ProductAttributes { get; set; }
    }
}
