

using Microsoft.EntityFrameworkCore;
using ShopClothing.Domain.Entities.Cart;
using ShopClothing.Domain.Interface.Cart;
using ShopClothing.Infrastructure.Data;

namespace ShopClothing.Infrastructure.Repositories.Cart
{
    public class CartRepository(AppDbContext context) : ICartRepository
    {
        public async Task<Carts> GetOrCreateCartAsync(string userId)
        {
            var existingCart = await context.Carts
                                            .Include(c => c.CartItems)
                                            .ThenInclude(ci => ci.Products)
                                            .FirstOrDefaultAsync(c => c.UserID.ToString() == userId);

            if(existingCart is not null)
                return existingCart;

            var newCart = new Carts
            {
                UserID = userId,
                CartID = Guid.NewGuid()

            };

            await context.Carts.AddAsync(newCart);
            await context.SaveChangesAsync();

            return newCart;
        }

        public int QuantityProductAttributesStock(Guid ProductAttributeID)
        {
            var productAttribute = context.Product_Attributes
                .FirstOrDefault(p => p.Product_AttributeID == ProductAttributeID);
            if(productAttribute is null)
                return 0;

            return productAttribute.Quantity;
        }
    }
}
