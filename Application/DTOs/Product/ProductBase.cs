using ShopClothing.Domain.Entities.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothing.Application.DTOs.Product
{
    public class ProductBase
    {
        public string? ProductName { get; set; }

        public string? ProductDescription { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow.AddHours(7);
        public Guid CategoryID { get; set; }   
        public Categories? Categories { get; set; }

        
    }
}
