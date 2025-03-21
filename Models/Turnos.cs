﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AssistsMx.Models
{
    public class Turnos
    {
        [Key]
        public int ID_Turno { get; set; }

        [Required, MaxLength(50)]
        public string Nombre_Turno { get; set; }

        [Required]
        public string Hora_Inicio { get; set; }

        [Required]
        public string Hora_Fin { get; set; }

        public string Descripcion { get; set; }

        [JsonIgnore]
        public virtual ICollection<Empleados> Empleados { get; set; } = new List<Empleados>();

    }
}
