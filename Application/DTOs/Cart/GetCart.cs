using ShopClothing.Application.DTOs.Cart.CartItem;

namespace ShopClothing.Application.DTOs.Cart
{
    public class GetCart
    {
        public Guid CartID { get; set; }

        public ICollection<GetCartItem> CartItems { get; set; } = new List<GetCartItem>();
    }
}
