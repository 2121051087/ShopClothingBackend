using Microsoft.EntityFrameworkCore;
using ShopClothing.Domain.Entities.Product;
using ShopClothing.Domain.Interface.CategorySpecifics;
using ShopClothing.Infrastructure.Data;

namespace ShopClothing.Infrastructure.Repositories.CategorySpecifics
{
    public class CategorySpecificsRepository(AppDbContext context) : ICategorySpecifics
    {
        public async Task<int> CountNumberProductByCategory(Guid categoryId)
        {
            var result = await context.Products.Where(p => p.CategoryID == categoryId)
                .CountAsync();
            return result;
        }

        public async Task<IEnumerable<Products>> GetProductsByCategory(Guid categoryId)
        {
            var products = await context
                .Products
                .Include(p => p.Categories)
                .Where(p => p.CategoryID == categoryId)
                .AsNoTracking()
                .ToListAsync();
            return products.Count > 0 ? products : [];

        }
    }
}
