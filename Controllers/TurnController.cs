using Microsoft.AspNetCore.Mvc;
using AssistsMx.Data;
using AssistsMx.Models;
using Microsoft.EntityFrameworkCore;

namespace AssistsMx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TurnController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Turnos>> GetTurnos()
        {
            var turno = _context.Turnos.Include(t => t.Empleados).ToList();
            return Ok(turno);
        }

        [HttpPost]
        public ActionResult<Turnos> CrearTurno(Turnos turno)
        {
            turno.Empleados = null;

            _context.Turnos.Add(turno);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetTurnos), new { id = turno.ID_Turno }, turno);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateTurno(int id, Turnos updatedTurno)
        {
            if (id != updatedTurno.ID_Turno)
            {
                return BadRequest("ID del turno no coincide.");
            }

            _context.Entry(updatedTurno).State = EntityState.Modified;
            
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Turnos.Any(a => a.ID_Turno == id))

                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok("Actualizado correctamente");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTurno(int id)
        {
            var turno = _context.Turnos.Find(id);
            if (turno == null)
            {
                return NotFound();
            }

            _context.Turnos.Remove(turno);
            _context.SaveChanges();
            return Ok("Turno eliminado correctamente");
        }
    }
}
