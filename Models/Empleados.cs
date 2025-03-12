using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssistsMx.Models
{
    public class Empleados
    {
        private string apellido = string.Empty;

        [Key]
        public int ID_Empleado { get; set; }

        [Required, MaxLength(5)]
        public string Nombre { get; set; }

        [Required, MaxLength(5)]
        public string Apellido {  get; set; }

        public int? Departamento { get; set; }

        [MaxLength(50)]
        public string Puesto { get; set; }

        public DateTime Fecha_Contratacion { get; set; } = DateTime.Now;

        [Required, EmailAddress, MaxLength(10)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string Telefono { get; set; }

        public int? ID_Turno { get; set; }

        [ForeignKey("ID_Turno")]
        public virtual Turnos? Turno { get; set; }

        [ForeignKey("Departamento")]
        public virtual Departamentos? Departamentos { get; set; }
    }
}
