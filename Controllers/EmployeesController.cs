using Microsoft.AspNetCore.Mvc;
using AssistsMx.Data;
using AssistsMx.Models;
using Microsoft.EntityFrameworkCore;

namespace AssistsMx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Empleados>> GetEmpleados()
        {
            return _context.Empleados.Include(e => e.Turno)      // Incluye la relación con Turno
                            .Include(e => e.Departamentos) // Incluye la relación con Departamento
                            .ToList();
        }

        [HttpPost]
        public ActionResult<Empleados> CrearUsuario(Empleados empleado)
        {
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetEmpleados), new { id = empleado.ID_Empleado }, empleado);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmpleado(int id, Empleados updatedEmpleado)
        {
            if (id != updatedEmpleado.ID_Empleado)
            {
                return BadRequest();
            }

            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }

            // Verificar si el nuevo turno y departamento existen
            var turno = await _context.Turnos.FindAsync(updatedEmpleado.ID_Turno);
            var departamento = await _context.Departamentos.FindAsync(updatedEmpleado.ID_Departamento);

            if (turno == null || departamento == null)
            {
                return BadRequest("Turno o Departamento no válido.");
            }

            // Actualizar los datos del empleado
            empleado.Nombre = updatedEmpleado.Nombre;
            empleado.Apellido = updatedEmpleado.Apellido;
            empleado.ID_Turno = updatedEmpleado.ID_Turno;
            empleado.ID_Departamento = updatedEmpleado.ID_Departamento;
            empleado.Turno = turno;
            empleado.Departamentos = departamento;

            _context.Entry(empleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Empleados.Any(e => e.ID_Empleado == id))
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
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }

            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
