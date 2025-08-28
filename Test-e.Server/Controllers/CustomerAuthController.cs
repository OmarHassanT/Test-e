using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Test_e.Server.Data;
using Test_e.Server.DTOs;
using Test_e.Server.FilterAttributes;
using Test_e.Server.Models;
using Test_e.Server.Services.IServices;

namespace Test_e.Server.Controllers
{
    [ApiController]
    [Route("api/customer/auth")]

    public class CustomerAuthController : ControllerBase
    {
        private readonly ICustomerAuthService _customerAuthService;

        public CustomerAuthController(ICustomerAuthService authService)
        {
            _customerAuthService = authService;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<ApiResponse<string>>> RegisterCustomer(RegisterCustomerDto registerCustomerDto)
        {
            var token = await _customerAuthService.RegisterCustomerAsync(registerCustomerDto);

            return Ok(new ApiResponse<string>
            {
                Success = true,
                Message = "Customer registered successfully",
                Data = token
            });
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<ApiResponse<string>>> LoginCustomer([FromBody] LoginCustomerDto loginCustomerDto)
        {
            var token = await _customerAuthService.LoginCustomerAsync(loginCustomerDto.Phone, loginCustomerDto.Password);

            return Ok(new ApiResponse<string>
            {
                Success = true,
                Message = "Customer loggedin successfully",
                Data = token
            });
        }

    }
}
