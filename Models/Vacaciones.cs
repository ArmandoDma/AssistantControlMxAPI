using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AssistsMx.Models
{
    public class Vacaciones
    {

        [Key]
        public int ID_Vacaciones { get; set; }

        [Required]
        public int ID_Empleado { get; set; }

        [Required]
        public DateTime Fecha_Inicio { get; set; }

        [Required]
        public DateTime Fecha_Final { get; set; }

        [Required]
        public string Estado { get; set; }

        [ForeignKey("ID_Empleado")]
        public virtual Empleados? Empleados { get; set; }
    }
}
