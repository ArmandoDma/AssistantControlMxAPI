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
    }
}
