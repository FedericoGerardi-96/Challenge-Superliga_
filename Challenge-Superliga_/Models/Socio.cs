using System.ComponentModel.DataAnnotations;

namespace Challenge_Superliga_.Models
{
    public class Socio : Persona
    {
        public float PromEdad { get; set; }

        public Socio(string Nombre,int Edad,string Equipo, string Estado_Civil, string Nivel_Estudio)
        {
            this.Nombre = Nombre;
            this.Edad = Edad;
            this.Equipo = Equipo;
            this.Estado_Civil = Estado_Civil;
            this.Nivel_Estudio = Nivel_Estudio;
        }
    }
}
