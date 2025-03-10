using Microsoft.AspNetCore.Mvc;
using AssistsMx.Data;
using AssistsMx.Models;
using Microsoft.EntityFrameworkCore;

namespace AssistsMx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RolController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Roles>> GetRoles()
        {
            return _context.Roles.ToList();
        }

        [HttpPost]
        public ActionResult<Empleados> CrearRol(Roles rol)
        {
            _context.Roles.Add(rol);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetRoles), new { id = rol.ID_Rol }, rol);
        }
    }
}
