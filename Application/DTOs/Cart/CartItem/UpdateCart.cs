namespace ShopClothing.Application.DTOs.Cart.CartItem
{
    public class UpdateCart
    {
        public Guid CartID { get;set; }

        public ICollection<UpdateCartItem> cartItems { get; set; } = new List<UpdateCartItem>();

    }
}
