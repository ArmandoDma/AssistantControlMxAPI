using Microsoft.AspNetCore.Mvc;
using AssistsMx.Data;
using AssistsMx.Models;
using Microsoft.EntityFrameworkCore;

namespace AssistsMx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PermissionsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Permisos>> GetPer()
        {
            return _context.Permisos.ToList();
        }

        [HttpPost]
        public ActionResult<Permisos> CrearPermiso(Permisos per)
        {
            _context.Permisos.Add(per);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetPer), new { id = per.ID_Permiso }, per);
        }
    }
}