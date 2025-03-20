using Microsoft.AspNetCore.Mvc;
using AssistsMx.Data;
using AssistsMx.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
            return _context.Asistencias.Include(a => a.Empleados).ToList();
        }

        [HttpPost]
        public ActionResult<Asistencia> CrearAsis(Asistencia Asis)
        {
            if (Asis == null)
            {
                return BadRequest("El objeto asistencia es nulo.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var empleadoExiste = _context.Empleados.Any(e => e.ID_Empleado == Asis.ID_Empleado);
            if (!empleadoExiste)
            {
                return BadRequest("El empleado no existe.");
            }
            
            Asis.Empleados = null;

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
            return Ok("asistencia actualizada de forma correcta.");
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
            return Ok("asistencia eliminada correctamente.");
        }
    }
}
