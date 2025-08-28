using Test_e.Server.DTOs;
using Test_e.Server.Models;

namespace Test_e.Server.Services.IServices
{
    public interface IProductService
    {
        Task<CreateProductResponseDto> CreateProductAsync(CreateProductRequestDto dto);
        Task<ProductAttribute> AddOrUpdateAttributeWithOptionsAsync(int productId, AddOrUpdateAttributeWithOptionsDto dto);
        //Task GenerateVariantsAsync(int productId);
    }
}
