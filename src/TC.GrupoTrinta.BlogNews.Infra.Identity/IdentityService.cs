using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using TC.GrupoTrinta.BlogNews.Application.Interfaces;
using MediatR;

namespace TC.GrupoTrinta.BlogNews.Infra.Identity
{
    public class IdentityService : IAuthenticationService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public IdentityService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<bool> ExistsUserAsync(string username)
        {
            return (await _userManager.Users.FirstAsync(u => u.UserName == username)) != null;
        }

        public async Task<string?> AuthenticationAsync(string userName, string password)
        {
            var user = await _signInManager.UserManager.FindByNameAsync(userName);

            var result = await _signInManager.PasswordSignInAsync(userName, password, false, true);

            if (result.Succeeded) return await GetTokenAsync(user!.Id, userName);
            
            return null;
        }

        public async Task<string> GetTokenAsync(long userId, string userName)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"] ?? throw new InvalidOperationException()));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var user = await _userManager.FindByNameAsync(userName);

            if (user == null) throw new Exception(userName);
            
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim> { new Claim(ClaimTypes.NameIdentifier, $"{userId}"), new Claim(ClaimTypes.Name, userName)};

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["JwtSettings:Issuer"],
                Audience = _configuration["JwtSettings:Audience"],
                Subject = new ClaimsIdentity(claims.ToArray()),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(_configuration["JwtSettings:DurationInMinutes"])),
                SigningCredentials = credentials
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
