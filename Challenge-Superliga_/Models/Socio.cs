using System.ComponentModel.DataAnnotations;

namespace Challenge_Superliga_.Models
{
    public class Socio
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
