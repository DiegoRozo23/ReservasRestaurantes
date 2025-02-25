using WebApplication1.Models;
using WebApplication1.Data;
using BCrypt.Net;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApplication1.Services
{
    public class AuthService
    {
        private readonly ApplicationDbContext _context;

        public AuthService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Usuario SignUp(SignUpRequest request)
        {
            var user = new Usuario
            {
                Nombre = request.Nombre,
                CorreoElectronico = request.CorreoElectronico,
                Contrasena = BCrypt.Net.BCrypt.HashPassword(request.Contrasena),
                NumeroTelefono = request.NumeroTelefono // Asegurarse de incluir el número de teléfono
            };
            _context.Usuarios.Add(user);
            _context.SaveChanges();
            return user;
        }

        public Usuario Login(LoginRequest request)
        {
            var user = _context.Usuarios.FirstOrDefault(u => u.CorreoElectronico == request.CorreoElectronico);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Contrasena, user.Contrasena))
            {
                return null;
            }
            return user;
        }

        public string GenerateJwtToken(Usuario user, IConfiguration configuration)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.CorreoElectronico),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, user.Nombre)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
