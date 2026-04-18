using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using EMS.API.Data;
using EMS.API.DTOs;
using EMS.API.Models;

namespace EMS.API.Services
{
    public interface IAuthService
    {
        Task<AuthResponseDto> RegisterAsync(AuthRequestDto request);
        Task<AuthResponseDto> LoginAsync(AuthRequestDto request);
    }
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public AuthService(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<AuthResponseDto> RegisterAsync(AuthRequestDto request)
        {
            // Check for duplicate username
            if (await _context.AppUsers.AnyAsync(u => u.Username.ToLower() == request.Username.ToLower()))
            {
                return new AuthResponseDto { Success = false, Message = "Username already exists." };
            }

            var user = new AppUser
            {
                Username = request.Username,
                // Hash password with 12 rounds of BCrypt as per requirements
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password, 12),
                Role = string.IsNullOrWhiteSpace(request.Role) ? "Admin" : request.Role
            };

            _context.AppUsers.Add(user);
            await _context.SaveChangesAsync();

            return new AuthResponseDto { Success = true, Message = "User registered successfully." };
        }

        public async Task<AuthResponseDto> LoginAsync(AuthRequestDto request)
        {
            var user = await _context.AppUsers.FirstOrDefaultAsync(u => u.Username.ToLower() == request.Username.ToLower());

            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return new AuthResponseDto { Success = false, Message = "Invalid credentials." };
            }

            return new AuthResponseDto
            {
                Success = true,
                Message = "Login successful.",
                Token = GenerateToken(user),
                Username = user.Username,
                Role = user.Role
            };
        }

        private string GenerateToken(AppUser user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.UtcNow.AddHours(double.Parse(_config["Jwt:ExpiryHours"] ?? "8"));

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}