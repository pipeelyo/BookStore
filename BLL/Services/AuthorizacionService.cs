using BookStore.BLL.Interfaces;
using BookStore.Context;
using BookStore.DAL.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookStore.BLL.Services
{
    public class AuthorizacionService : IAuthorizacionService
    {
        public readonly AppDbContext _context;
        public readonly IConfiguration _configuration;

        public AuthorizacionService(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        private string GenerateToken(string idUser)
        {
            var key = _configuration.GetValue<string>("JwtSettings:key");
            var keyBytes = Encoding.ASCII.GetBytes(key);

            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, idUser));

            var credencialesToken = new SigningCredentials(
                    new SymmetricSecurityKey(keyBytes),
                    SecurityAlgorithms.HmacSha256Signature
                );
            var tokenDescripcion = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(50),
                SigningCredentials = credencialesToken
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescripcion);

            string tokenCreado = tokenHandler.WriteToken(tokenConfig);

            return tokenCreado;
        }

        public async Task<AutorizacionResponse> ReturnToken(AutorizacionRequest authorization)
        {
            if (authorization == null) return await Task.FromResult<AutorizacionResponse>(null);

            var find_user = _context.Users.FirstOrDefault(x =>
                x.password == x.password &&
                x.email == x.email
            );
            if (find_user == null) return await Task.FromResult<AutorizacionResponse>(null);

            string tokenCreado = GenerateToken(find_user.userId.ToString());

            return new AutorizacionResponse() { token = tokenCreado, result = true, message = "Ok" };
        }
    }
}
