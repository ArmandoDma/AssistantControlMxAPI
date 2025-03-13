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
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(int id, Usuarios updatedUsuario)
        {
            if (id != updatedUsuario.ID_Usuarios)
            {
                return BadRequest();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            // Verificar si el nuevo rol y empleado existen
            var rol = await _context.Roles.FindAsync(updatedUsuario.ID_Rol);
            var empleado = await _context.Empleados.FindAsync(updatedUsuario.ID_Empleado);

            if (rol == null || empleado == null)
            {
                return BadRequest("Rol o Empleado no válido.");
            }

            // Actualizar los datos del usuario
            usuario.Usuario = updatedUsuario.Usuario;
            usuario.ID_Rol = updatedUsuario.ID_Rol;
            usuario.ID_Empleado = updatedUsuario.ID_Empleado;
            usuario.Rol = rol;
            usuario.Empleados = empleado;

            if (!string.IsNullOrEmpty(updatedUsuario.Contraseña))
            {
                usuario.Contraseña = BCrypt.Net.BCrypt.HashPassword(updatedUsuario.Contraseña);
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Usuarios.Any(e => e.ID_Usuarios == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
