using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AssistsMx.Models
{
    public class Asistencia
    {
        [Key]
        public int ID_Asistencia { get; set; }
      
        [ForeignKey("ID_Empleado")]
        public int ID_Empleado { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public TimeSpan Hora_Entrada { get; set; }

        public TimeSpan? Hora_Salida { get; set; }

        [Required]
        public string Estado { get; set; }

        public virtual Empleados Empleados { get; set; }
    }
}
