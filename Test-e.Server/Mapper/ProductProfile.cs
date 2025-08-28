using AutoMapper;
using Test_e.Server.DTOs;
using Test_e.Server.Models;

namespace Test_e.Server.Mapper
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductRequestDto, Product>();
            CreateMap<Product, CreateProductResponseDto>();
        }
    }
}
