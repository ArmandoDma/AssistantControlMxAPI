﻿using Microsoft.AspNetCore.Mvc;
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
            return _context.Empleados.Include(e => e.Turno)
                            .Include(e => e.Departamentos) 
                            .ToList();
        }

        [HttpPost]
        public ActionResult<Empleados> CrearUsuario(Empleados empleado)
        {
            _context.Empleados.Add(empleado);
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

            
            var turno = await _context.Turnos.FindAsync(updatedEmpleado.ID_Turno);
            var departamento = await _context.Departamentos.FindAsync(updatedEmpleado.Departamento);

            if (turno == null || departamento == null)
            {
                return BadRequest("Turno o Departamento no válido.");
            }

            empleado.Nombre = updatedEmpleado.Nombre;
            empleado.Apellido = updatedEmpleado.Apellido;
            empleado.Puesto = updatedEmpleado.Puesto;
            empleado.Email = updatedEmpleado.Email;
            empleado.ID_Turno = updatedEmpleado.ID_Turno;
            empleado.Departamento = updatedEmpleado.Departamento;
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

            
           return Ok("Empleado actualizado correctamente");
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
