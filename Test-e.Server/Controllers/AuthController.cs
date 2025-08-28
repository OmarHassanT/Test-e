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
    [Route("api/auth")]

    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [Permission("RegisterUsers")]
        [HttpPost("register")]
        public async Task<ActionResult<ApiResponse<string>>> Register(RegisterUserDto userDto)
        {
            var token = await _authService.RegisterAsync(userDto);

            return Ok(new ApiResponse<string>
            {
                Success = true,
                Message = "User registered successfully",
                Data = token
            });
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<ApiResponse<string>>> Login([FromBody] LoginDto dto)
        {
            var token = await _authService.LoginAsync(dto.Email, dto.Password);

            return Ok(new ApiResponse<string>
            {
                Success = true,
                Message = "User loggedin successfully",
                Data = token
            });
        }


    }
}
