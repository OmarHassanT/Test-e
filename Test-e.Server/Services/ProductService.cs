using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Test_e.Server.Data;
using Test_e.Server.DTOs;
using Test_e.Server.Exceptions;
using Test_e.Server.Models;
using Test_e.Server.Services.IServices;

namespace Test_e.Server.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProductService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateProductResponseDto> CreateProductAsync(CreateProductRequestDto dto)
        {
            var product = _mapper.Map<Product>(dto);

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return _mapper.Map<CreateProductResponseDto>(product);
        }

        public async Task<ProductAttribute> AddOrUpdateAttributeWithOptionsAsync(int productId, AddOrUpdateAttributeWithOptionsDto addOrUpdateAttributeWithOptionsDto)
        {
            if (addOrUpdateAttributeWithOptionsDto.AttributeId == null)
            {
                return await AddAttributeWithOptionsAsync(productId, addOrUpdateAttributeWithOptionsDto);
            }
            else
            {
                return await UpdateAttributeWithOptionsAsync(productId, addOrUpdateAttributeWithOptionsDto);
            }
        }

        private async Task<ProductAttribute> AddAttributeWithOptionsAsync(int productId, AddOrUpdateAttributeWithOptionsDto addOrUpdateAttributeWithOptionsDto)
        {
            var attribute = new ProductAttribute
            {
                ProductId = productId,
                Name = addOrUpdateAttributeWithOptionsDto.Name
            };

            attribute.Options = addOrUpdateAttributeWithOptionsDto.Options
                  .Select(o => new AttributeOption { Value = o.Value, ExplanationNote = o.ExplanationNote })
                  .ToList();

            _context.ProductAttributes.Add(attribute);
            await _context.SaveChangesAsync();

            return attribute;
        }

        private async Task<ProductAttribute> UpdateAttributeWithOptionsAsync(int productId, AddOrUpdateAttributeWithOptionsDto addOrUpdateAttributeWithOptionsDto)
        {
            var attribute = await _context.ProductAttributes
            .Include(a => a.Options)
            .FirstOrDefaultAsync(a => a.Id == addOrUpdateAttributeWithOptionsDto.AttributeId && a.ProductId == productId);

            if (attribute == null)
                throw new NotFoundException($"Attribute with Id {addOrUpdateAttributeWithOptionsDto.AttributeId} not found for product {productId}");

            // Update the attribute name
            attribute.Name = addOrUpdateAttributeWithOptionsDto.Name;

            // Remove old options
            _context.AttributeOptions.RemoveRange(attribute.Options);

            // Add new ones
            attribute.Options = addOrUpdateAttributeWithOptionsDto.Options
                .Select(o => new AttributeOption { Value = o.Value, ExplanationNote = o.ExplanationNote })
                .ToList();

            await _context.SaveChangesAsync();
            return attribute;
        }


        //public async Task GenerateVariantsAsync(int productId)
        //{
        //    var product = await _context.Products
        //        .Include(p => p.Attributes)
        //        .ThenInclude(a => a.Options)
        //        .FirstOrDefaultAsync(p => p.Id == productId);

        //    if (product == null) throw new Exception("Product not found");

        //    var optionGroups = product.Attributes.Select(a => a.Options.ToList()).ToList();
        //    var combinations = CartesianProduct(optionGroups);

        //    foreach (var combo in combinations)
        //    {
        //        var variant = new ProductVariant
        //        {
        //            ProductId = productId,
        //            Sku = Guid.NewGuid().ToString().Substring(0, 8),
        //            Price = product.BasePrice,
        //            Stock = 0
        //        };

        //        _context.ProductVariants.Add(variant);
        //        await _context.SaveChangesAsync();

        //        foreach (var option in combo)
        //        {
        //            _context.ProductVariantOptions.Add(new ProductVariantOption
        //            {
        //                ProductVariantId = variant.Id,
        //                AttributeOptionId = option.Id
        //            });
        //        }
        //    }

        //    await _context.SaveChangesAsync();
        //}

        //private static IEnumerable<List<T>> CartesianProduct<T>(IEnumerable<List<T>> sequences)
        //{
        //    IEnumerable<List<T>> result = new[] { new List<T>() };
        //    foreach (var seq in sequences)
        //    {
        //        result = from r in result
        //                 from item in seq
        //                 select new List<T>(r) { item };
        //    }
        //    return result;
        //}
    
    }
}
