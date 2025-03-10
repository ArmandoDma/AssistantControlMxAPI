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
            _context.Tunros.Add(turno);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetTurnos), new { id = turno.ID_Turno }, turno);
        }
    }
}
