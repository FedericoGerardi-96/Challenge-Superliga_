using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge_Superliga_.Models
{
    public class ResultadoSocio
    {
        public int CantidadSocios { get; set; }
        public float PromedioEdadRacing { get; set; }
        public List<Socio> lstSocios { get; set; }
        public List<NombreComunRiver> lstNombreComunRiver { get; set; }
        public List<DatoEquipo> lstDatoEquipo { get; set; }

    }
}
