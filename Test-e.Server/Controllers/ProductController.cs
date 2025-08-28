using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test_e.Server.DTOs;
using Test_e.Server.Models;
using Test_e.Server.Services.IServices;

namespace Test_e.Server.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost]
        public async Task<ActionResult<ApiResponse<CreateProductResponseDto>>> CreateProduct([FromBody] CreateProductRequestDto dto)
        {
            var product = await _productService.CreateProductAsync(dto);
            return Ok(new ApiResponse<CreateProductResponseDto>
            {
                Success = true,
                Message = "Product created successfully",
                Data = product
            });
        }

        [HttpPost("{productId}/add-update-attribute-with-options")]
        public async Task<ActionResult<ApiResponse<int>>> AddOrUpdateAttributeWithOptions(int productId, AddOrUpdateAttributeWithOptionsDto dto)
        {
            var attribute = await _productService.AddOrUpdateAttributeWithOptionsAsync(productId, dto);
            return Ok(new ApiResponse<int>
            {
                Success = true,
                Message = "Attribute With Options created successfully",
                Data = attribute.Id
            });
        }

        //[HttpPost("{productId}/variants/generate")]
        //public async Task<IActionResult> GenerateVariants(int productId)
        //{
        //    await _productService.GenerateVariantsAsync(productId);
        //    return Ok("Variants generated successfully");
        //}
    }
}
