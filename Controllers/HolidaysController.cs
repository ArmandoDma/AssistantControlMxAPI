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
    }
}
