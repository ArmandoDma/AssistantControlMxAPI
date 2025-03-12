using Microsoft.AspNetCore.Mvc;
using AssistsMx.Data;
using AssistsMx.Models;
using Microsoft.EntityFrameworkCore;

namespace AssistsMx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PermissionsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Permisos>> GetPer()
        {
            return _context.Permisos.ToList();
        }

        [HttpPost]
        public ActionResult<Permisos> CrearPermiso(Permisos per)
        {
            _context.Permisos.Add(per);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetPer), new { id = per.ID_Permiso }, per);
        }
        [HttpPut("{id}")]
        public IActionResult UpdatePer(int id, Permisos updatedPer)
        {
            if (id != updatedPer.ID_Permiso)
            {
                return BadRequest("ID de permiso no coincide.");
            }

            _context.Entry(updatedPer).State = EntityState.Modified;
            
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Permisos.Any(a => a.ID_Permiso == id))
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
        public IActionResult DeletePer(int id)
        {
            var per = _context.Permisos.Find(id);
            if (per == null)
            {
                return NotFound();
            }

            _context.Permisos.Remove(per);
            _context.SaveChanges();
            return NoContent();
        }
    }
}