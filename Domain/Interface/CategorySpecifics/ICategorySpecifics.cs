using ShopClothing.Domain.Entities.Product;


namespace ShopClothing.Domain.Interface.CategorySpecifics
{
    public interface ICategorySpecifics
    {
        Task<IEnumerable<Products>> GetProductsByCategory(Guid categoryId);

         Task<int> CountNumberProductByCategory(Guid categoryId);
    }
}
