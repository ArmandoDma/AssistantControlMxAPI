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
            _context.Empleados.Add(empleado);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetEmpleados), new { id = empleado.ID_Empleado }, empleado);
        }
    }
}
