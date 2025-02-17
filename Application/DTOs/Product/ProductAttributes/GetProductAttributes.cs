namespace ShopClothing.Application.DTOs.Product.ProductAttributes
{
    public class GetProductAttributes : ProductAttributesBase
    {
        public Guid Product_AttributeID { get; set; }

        public string? ImageUrl { get; set; }
    }
}
