using Challenge_Superliga_.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections;

namespace Challenge_Superliga_.Servicio
{
    public class ServicioSocios
    {
        public static List<Socio> ObtenerSocios()
        {
            try
            {
                var sLineas = File.ReadLines("C:/Users/HOME/Desktop/socios.csv").ToList();
                var lstSocios = new List<Socio>();
                foreach (var slinea in sLineas)
                {
                    var sDato = slinea.Split(';');
                    var oSocio = new Socio();
                    oSocio = LlenarListaSocio(sDato);
                    lstSocios.Add(oSocio);                    
                }
                return lstSocios;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }


        }

        public static float ObtenerPromedioEdadRacing()
        {
            var fPromedioEdadRacing = ObtenerSocios().Where(x => x.Equipo == "Racing").Average(r => r.Edad);
            return float.Parse(fPromedioEdadRacing.ToString());
        }

        public static List<string> ObtenerNombreMasComunRiver()
        {
            var lstSocios = ObtenerSocios();
            var iNombre = from socio in lstSocios
                          where socio.Equipo == "River"
                          group socio by socio.Nombre into g                          
                         orderby g.Count() descending
                         select new
                         {
                             nombre = g.Key,
                             cantidad = g.Count()
                         };
            var lstNombre = iNombre.ToList();
            var lstPersonasRepetidasRiver = new List<string>();
            var lstPersonas = iNombre.OrderByDescending(x => x.cantidad).Take(5).ToList();
            foreach(var per in lstPersonas)
            {
                lstPersonasRepetidasRiver.Add(per.nombre);
            }
            return lstPersonasRepetidasRiver;
        }

        public static List<DatoEquipo> ObtenerDatosSociosAgrupados()
        {
            var cantEquipo = ObtenerSocios().GroupBy(y => y.Equipo).OrderByDescending(x => x.Count())
                             .Select(x => new {
                                 equipo = x.Key,
                                 cantidad = x.Count(),
                                 promEdad = x.Select(w => w.Edad).Average(),
                                 minEdad = x.Select(w => w.Edad).Min(),
                                 maxEdad = x.Select(w => w.Edad).Max()
                             });

            var lstEquipos = cantEquipo.ToList();
            var lstDtosEquipos = new List<DatoEquipo>();
            foreach (var eq in lstEquipos)
            {
                var oDatoEquipo = new DatoEquipo();
                oDatoEquipo.Equipo = eq.equipo;
                oDatoEquipo.Cantidad = eq.cantidad;
                oDatoEquipo.PromEdad = eq.promEdad;
                oDatoEquipo.MaxEdad = eq.maxEdad;
                oDatoEquipo.MinEdad = eq.minEdad;

                lstDtosEquipos.Add(oDatoEquipo);
            }

            return lstDtosEquipos;
        }

        public static List<Socio> FiltrarSocio()
        {
            var lstSocios = new List<Socio>();
            lstSocios = ObtenerSocios().Where(x => x.Estado_Civil == "Casado" && x.Nivel_Estudio == "Universitario").OrderBy(x => x.Edad).Take(100).ToList();

            return lstSocios;
        }

        private static Socio LlenarListaSocio(string[] Dato)
        {
            var oSocio = new Socio();
            oSocio.Nombre = Dato[0];
            oSocio.Edad = int.Parse(Dato[1]);
            oSocio.Equipo = Dato[2];
            oSocio.Estado_Civil = Dato[3];
            oSocio.Nivel_Estudio = Dato[4];
            return oSocio;
        }
    }
}
