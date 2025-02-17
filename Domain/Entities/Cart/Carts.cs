namespace ShopClothing.Domain.Entities.Cart
{
    public class Carts
    {
        public Guid CartID { get; set; }
        public string UserID { get; set; } = null!;
        public ICollection<CartItems> CartItems { get; set; } = new List<CartItems>();

    }
    
}
