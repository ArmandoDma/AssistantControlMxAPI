using Microsoft.AspNetCore.Mvc;
using AssistsMx.Data;
using AssistsMx.Models;
using Microsoft.EntityFrameworkCore;

namespace AssistsMx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RolController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Roles>> GetRoles()
        {
            return _context.Roles.ToList();
        }

        [HttpPost]
        public ActionResult<Roles> CrearRol(Roles rol)
        {
            _context.Roles.Add(rol);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetRoles), new { id = rol.ID_Rol }, rol);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateRol(int id, Roles updatedRol)
        {
            if (id != updatedRol.ID_Rol)
            {
                return BadRequest("ID de rol no coincide.");
            }

            _context.Entry(updatedRol).State = EntityState.Modified;
            
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Roles.Any(a => a.ID_Rol == id))
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
        public IActionResult DeleteRol(int id)
        {
            var rol = _context.Roles.Find(id);
            if (rol == null)
            {
                return NotFound();
            }

            _context.Roles.Remove(rol);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
