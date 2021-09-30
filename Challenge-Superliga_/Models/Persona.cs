using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge_Superliga_.Models
{
    public abstract class Persona
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int Edad { get; set; }
        [Required]
        public string Equipo { get; set; }
        [Required]
        public string Estado_Civil { get; set; }
        [Required]
        public string Nivel_Estudio { get; set; }

    }
}
