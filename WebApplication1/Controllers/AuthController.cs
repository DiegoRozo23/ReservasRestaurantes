using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly AuthService _authService;
        private readonly UsuarioService _usuarioService;

        public AuthController(IConfiguration configuration, AuthService authService, UsuarioService usuarioService)
        {
            _configuration = configuration;
            _authService = authService;
            _usuarioService = usuarioService;
        }

        [HttpPost("signup")]
        public IActionResult SignUp([FromForm] SignUpRequest request)
        {
            // Verificar si el correo electrónico ya existe
            var existingUser = _usuarioService.GetUsuarioByEmail(request.CorreoElectronico);
            if (existingUser != null)
            {
                return BadRequest("El correo electrónico ya está registrado");
            }

            var user = _authService.SignUp(request);
            return Ok(new { Message = "Usuario registrado exitosamente", User = user });
        }

        [HttpPost("login")]
        public IActionResult Login([FromForm] LoginRequest request)
        {
            var user = _authService.Login(request);
            if (user == null)
            {
                return Unauthorized(new { Message = "Correo electrónico o contraseña incorrectos" });
            }

            var token = _authService.GenerateJwtToken(user, _configuration);
            return Ok(new AuthResponse
            {
                Token = token,
                Nombre = user.Nombre,
                CorreoElectronico = user.CorreoElectronico
            });
        }
    }
}
