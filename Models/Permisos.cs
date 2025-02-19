using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AssistsMx.Models
{
    public class Permisos
    {
        [Key]
        public int ID_Permiso { get; set; }

        [Required]
        [ForeignKey("ID_Empleado")]
        public int ID_Empleado { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public string Motivo { get; set; }

        [Required]
        public string Estado { get; set; }

        public virtual Empleados Empleados { get; set; }
    }
}
