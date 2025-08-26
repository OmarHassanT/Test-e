using Microsoft.EntityFrameworkCore;
using Test_e.Server.Data;
using Test_e.Server.Models;

namespace Test_e.Server.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            return await _dbSet
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByBrandAsync(int brandId)
        {
            return await _dbSet
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Where(p => p.BrandId == brandId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm)
        {
            return await _dbSet
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Where(p => p.Title.Contains(searchTerm) || p.Description!.Contains(searchTerm))
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsWithVariantsAsync()
        {
            return await _dbSet
                .Include(p => p.ProductVariants)
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .ToListAsync();
        }

        public async Task<Product?> GetProductWithDetailsAsync(int id)
        {
            return await _dbSet
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Include(p => p.ProductVariants)
                .Include(p => p.Reviews)
                .Include(p => p.ProductTags)
                    .ThenInclude(pt => pt.Tag)
                .Include(p => p.ProductBadgeAssignments)
                    .ThenInclude(pba => pba.ProductBadge)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductsByTagAsync(int tagId)
        {
            return await _dbSet
                .Include(p => p.ProductTags)
                    .ThenInclude(pt => pt.Tag)
                .Where(p => p.ProductTags.Any(pt => pt.TagId == tagId))
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsWithBadgesAsync()
        {
            return await _dbSet
                .Include(p => p.ProductBadgeAssignments)
                    .ThenInclude(pba => pba.ProductBadge)
                .Where(p => p.ProductBadgeAssignments.Any(pba => pba.ProductBadge.IsActive))
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsWithDiscountsAsync()
        {
            return await _dbSet.ToListAsync();
        }
    }
}

