using AssistsMx.Data;
using AssistsMx.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Crypto.Generators;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AssistsMx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UsuarioLogin usuariologin)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Usuario == usuariologin.Usuario);

            if(usuario == null || !BCrypt.Net.BCrypt.Verify(usuariologin.Contraseña, usuario.Contraseña))
            {
                return Unauthorized("Credenciales incorrectas");
            }

            var token = GenerarToken(usuario);
            return Ok(new { token });
        }

        private string GenerarToken(Usuarios usuario)
        {
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.Usuario),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public class UsuarioLogin
        {
            public string Usuario { get; set; }
            public string Contraseña { get; set; }
        }
    }
}
