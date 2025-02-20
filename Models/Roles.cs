using System.ComponentModel.DataAnnotations;

namespace AssistsMx.Models
{
    public class Roles
    {
        [Key]
        public int ID_Rol { get; set; }

        [Required, MaxLength(50)]
        public string Nombre_Rol { get; set; }

        public string Descripcion { get; set; }

        public virtual ICollection<Usuarios> Usuario { get; set; }
    }
}
