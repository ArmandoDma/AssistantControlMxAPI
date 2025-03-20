using Microsoft.AspNetCore.Mvc;
using AssistsMx.Data;
using AssistsMx.Models;
using Microsoft.EntityFrameworkCore;

namespace AssistsMx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DptosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DptosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Departamentos>> GetDptos()
        {
            return _context.Departamentos.Include(e => e.Empleados).ToList();
        }

        [HttpPost]
        public ActionResult<Departamentos> CrearDpto(Departamentos dpto)
        {            

            _context.Departamentos.Add(dpto);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetDptos), new { id = dpto.ID_Departamento }, dpto);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateDptos(int id, Departamentos updatedDptos)
        {
            if (id != updatedDptos.ID_Departamento)
            {
                return BadRequest("ID de departamento no coincide.");
            }

            _context.Entry(updatedDptos).State = EntityState.Modified;
            
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Departamentos.Any(a => a.ID_Departamento == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok("departamento actualizado exitosamente.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDptos(int id)
        {
            var dptos = _context.Departamentos.Find(id);
            if (dptos == null)
            {
                return NotFound();
            }

            _context.Departamentos.Remove(dptos);
            _context.SaveChanges();
            return Ok("departamento eliminado exitosamente.");
        }
    }
}
