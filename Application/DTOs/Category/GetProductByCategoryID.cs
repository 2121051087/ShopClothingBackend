using ShopClothing.Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothing.Application.DTOs.Category
{
    public class GetProductByCategoryID : ProductBase
    {
        public Guid ProductID { get; set; } 
    }
}
