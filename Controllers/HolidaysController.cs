using Microsoft.AspNetCore.Mvc;
using AssistsMx.Data;
using AssistsMx.Models;
using Microsoft.EntityFrameworkCore;

namespace AssistsMx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidaysController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HolidaysController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Vacaciones>> GetVaca()
        {
            return _context.Vacaciones.ToList();
        }

        [HttpPost]
        public ActionResult<Vacaciones> CrearVaca(Vacaciones vac)
        {
            _context.Vacaciones.Add(vac);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetVaca), new { id = vac.ID_Vacaciones }, vac);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateHoli(int id, Vacaciones updatedHoli)
        {
            if (id != updatedHoli.ID_Vacaciones)
            {
                return BadRequest("ID de vacaciones no coincide.");
            }

            _context.Entry(updatedHoli).State = EntityState.Modified;
            
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Vacaciones.Any(a => a.ID_Vacaciones == id))
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
        public IActionResult DeleteHoli(int id)
        {
            var vac = _context.Vacaciones.Find(id);
            if (vac == null)
            {
                return NotFound();
            }

            _context.Vacaciones.Remove(vac);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
