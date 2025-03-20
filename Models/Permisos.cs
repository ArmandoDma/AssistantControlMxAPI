using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AssistsMx.Models
{
    public class Permisos
    {
        [Key]
        public int ID_Permiso { get; set; }

        [Required]
        public int ID_Empleado { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required, MaxLength(200)]
        public string Motivo { get; set; }

        [Required]
        public string Estado { get; set; }

        [ForeignKey("ID_Empleado")]
        public virtual Empleados? Empleado { get; set; }
    }
}
