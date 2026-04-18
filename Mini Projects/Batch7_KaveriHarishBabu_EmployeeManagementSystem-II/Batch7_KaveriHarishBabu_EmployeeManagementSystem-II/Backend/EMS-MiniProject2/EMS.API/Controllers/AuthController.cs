using Microsoft.AspNetCore.Mvc;
using EMS.API.DTOs;
using EMS.API.Services;

namespace EMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(AuthRequestDto request)
        {
            var result = await _authService.RegisterAsync(request);
            if (!result.Success) return Conflict(new { message = result.Message }); // 409 Conflict
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthRequestDto request)
        {
            var result = await _authService.LoginAsync(request);
            if (!result.Success) return Unauthorized(new { success = false, message = result.Message }); // 401
            return Ok(result);
        }
    }
}