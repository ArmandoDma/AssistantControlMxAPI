using System.ComponentModel.DataAnnotations;

namespace AssistsMx.Models
{
    public class Departamentos
    {
        [Key]
        public int ID_Departamento { get; set; }

        [Required, MaxLength(100)]
        public string Nombre_Departamento { get; set; }

        public string Descripcion { get; set; }

        public virtual ICollection<Empleados> Empleados { get; set; }
    }
}
