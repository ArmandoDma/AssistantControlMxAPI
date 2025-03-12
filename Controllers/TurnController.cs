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
            return _context.Turnos.ToList();
        }

        [HttpPost]
        public ActionResult<Turnos> CrearTurno(Turnos turno)
        {
            _context.Turnos.Add(turno);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetTurnos), new { id = turno.ID_Turno }, turno);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateAsis(int id, Turnos updatedTurno)
        {
            if (id != updatedTurno.ID_Turno)
            {
                return BadRequest("ID de asistencia no coincide.");
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
            return NoContent();
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
            return NoContent();
        }
    }
}
