using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssistsMx.Models
{
    public class Usuarios
    {
        [Key]
        public int ID_Usuarios { get; set; }

        [Required, MaxLength(50)]
        public string Usuario { get; set; }

        [Required]
        public string Contraseña { get; set; }

        [Required]
        public int ID_Rol { get; set; }

        [Required]
        public int ID_Empleado { get; set; }
        
        [ForeignKey("ID_Rol")]
        public virtual Roles Rol { get; set; }

        [ForeignKey("ID_Empleado")]
        public virtual Empleados? Empleados { get; set; }
    }
}
