using Microsoft.AspNetCore.Mvc;
using AssistsMx.Data;
using AssistsMx.Models;
using Microsoft.EntityFrameworkCore;

namespace AssistsMx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Usuarios>> GetUsuarios()
        {
            return _context.Usuarios.Include(u => u.Rol)
                           .Include(u => u.Empleados)
                           .ToList();
        }

        [HttpPost]
        public ActionResult<Usuarios> CrearUsuario(Usuarios usuario)
        {           
            
            var rol = _context.Roles.Find(usuario.ID_Rol); 
            var empleado = _context.Empleados.Find(usuario.ID_Empleado); 

            if (rol != null && empleado != null)
            {
                return BadRequest("Rol o Empleado no válido.");
            }

            usuario.Rol = rol;
            usuario.Empleados = empleado;

            usuario.Contraseña = BCrypt.Net.BCrypt.HashPassword(usuario.Contraseña);

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetUsuarios), new { id = usuario.ID_Usuarios }, usuario);
        }
    }
}
