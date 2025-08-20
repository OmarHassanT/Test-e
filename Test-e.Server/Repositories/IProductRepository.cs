using Test_e.Server.Models;

namespace Test_e.Server.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId);
        Task<IEnumerable<Product>> GetProductsByBrandAsync(int brandId);
        Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm);
        Task<IEnumerable<Product>> GetProductsWithVariantsAsync();
        Task<Product?> GetProductWithDetailsAsync(int id);
        Task<IEnumerable<Product>> GetProductsByTagAsync(int tagId);
        Task<IEnumerable<Product>> GetProductsWithBadgesAsync();
        Task<IEnumerable<Product>> GetProductsWithDiscountsAsync();
    }
}
