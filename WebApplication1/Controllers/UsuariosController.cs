using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuariosController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> GetUsuarios()
        {
            return Ok(_usuarioService.GetUsuarios());
        }

        [HttpGet("{id}")]
        public ActionResult<Usuario> GetUsuario(int id)
        {
            var usuario = _usuarioService.GetUsuario(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        // Se elimina el método POST ya que el registro se realiza mediante el endpoint "signup" en AuthController

        [HttpPut("{id}")]
        public ActionResult UpdateUsuario(int id, [FromForm] CreateUsuarioRequest request)
        {
            var usuario = _usuarioService.GetUsuario(id);
            if (usuario == null)
            {
                return NotFound();
            }
            usuario.Nombre = request.Nombre;
            usuario.CorreoElectronico = request.CorreoElectronico;
            usuario.NumeroTelefono = request.NumeroTelefono;
            _usuarioService.UpdateUsuario(usuario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUsuario(int id)
        {
            var usuario = _usuarioService.GetUsuario(id);
            if (usuario == null)
            {
                return NotFound();
            }
            _usuarioService.DeleteUsuario(id);
            return NoContent();
        }
    }
}
