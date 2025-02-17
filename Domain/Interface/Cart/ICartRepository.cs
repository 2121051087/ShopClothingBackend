

using ShopClothing.Domain.Entities.Cart;

namespace ShopClothing.Domain.Interface.Cart
{
    public interface ICartRepository
    {
         Task<Carts> GetOrCreateCartAsync(string userId);

        int QuantityProductAttributesStock(Guid ProductAttributeID);
    }
}
