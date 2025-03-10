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
            return _context.Departamentos.ToList();
        }

        [HttpPost]
        public ActionResult<Turnos> CrearDpto(Departamentos dpto)
        {
            _context.Departamentos.Add(dpto);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetDptos), new { id = dpto.ID_Departamento }, dpto);
        }
    }
}
