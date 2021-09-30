using Challenge_Superliga_.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections;

namespace Challenge_Superliga_.Servicio
{
    public  class ServicioSocios
    {
        public static List<Socio> ObtenerSocios()
        {
            try
            {
                List<string> sLineas = File.ReadLines("C:/Users/HOME/Desktop/socios.csv").ToList();
                List<Socio> lstSocios = new List<Socio>();
               
                foreach (var slinea in sLineas)
                {
                    string[] sDato = slinea.Split(';');                    
                    lstSocios.Add(LlenarListaSocio(sDato));                    
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
            double fPromedioEdadRacing = ObtenerSocios().Where(x => x.Equipo == "Racing").Average(r => r.Edad);
            return float.Parse(fPromedioEdadRacing.ToString());
        }

         public static List<NombreComunRiver> ObtenerNombreMasComunRiver()
        {
            ResultadoSocio oResultadoSocio = new ResultadoSocio();
            var lstSocios = ObtenerSocios().Where(x => x.Equipo == "River").GroupBy(y => y.Nombre).OrderByDescending(t => t.Count()).Select(q => new
            {
                Nombre = q.Select(r => r.Nombre),
                Cantidad = q.Count()
            }).Take(5).ToList();

            oResultadoSocio.lstNombreComunRiver = new List<NombreComunRiver>();
            foreach (var per in lstSocios)
            {
                NombreComunRiver oNombreComunRiver = new NombreComunRiver();
                foreach (var item in per.Nombre)
                {
                    oNombreComunRiver.Nombre = item;
                    break;
                }
                oNombreComunRiver.Cantidad = per.Cantidad;
                oResultadoSocio.lstNombreComunRiver.Add(oNombreComunRiver);
            }

            return oResultadoSocio.lstNombreComunRiver;
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
            List<DatoEquipo> lstDtosEquipos = new List<DatoEquipo>();
            foreach (var eq in lstEquipos)
            {
                DatoEquipo oDatoEquipo = new DatoEquipo();
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
            List<Socio> lstSocios = new List<Socio>();
            lstSocios = ObtenerSocios().Where(x => x.Estado_Civil == "Casado" && x.Nivel_Estudio == "Universitario").OrderBy(x => x.Edad).Take(100).ToList();

            return lstSocios;
        }


        private static Socio LlenarListaSocio(string[] Dato)
        {
            Socio oSocio = new Socio(Dato[0], int.Parse(Dato[1]), Dato[2], Dato[3], Dato[4]);

            return oSocio;
        }
    }
}
