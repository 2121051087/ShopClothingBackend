namespace ShopClothing.Application.DTOs.Cart.CartItem
{
    public class GetCartItem : CartItemBase
    {
        public Guid CartItemID { get; set; }

        public Guid CartID { get; set; }


    }
}
