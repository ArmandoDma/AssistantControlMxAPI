using Microsoft.AspNetCore.Mvc;
using AssistsMx.Data;
using AssistsMx.Models;
using Microsoft.EntityFrameworkCore;

namespace AssistsMx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsisController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AsisController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Asistencia>> GetAsis()
        {
            return _context.Asistencias.ToList();
        }

        [HttpPost]
        public ActionResult<Asistencia> CrearAsis(Asistencia Asis)
        {
            _context.Asistencias.Add(Asis);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetAsis), new { id = Asis.ID_Asistencia }, Asis);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateAsis(int id, Asistencia updatedAsis)
        {
            if (id != updatedAsis.ID_Asistencia)
            {
                return BadRequest("ID de asistencia no coincide.");
            }

            _context.Entry(updatedAsis).State = EntityState.Modified;
            
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Asistencias.Any(a => a.ID_Asistencia == id))
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
        public IActionResult DeleteAsis(int id)
        {
            var asis = _context.Asistencias.Find(id);
            if (asis == null)
            {
                return NotFound();
            }

            _context.Asistencias.Remove(asis);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
