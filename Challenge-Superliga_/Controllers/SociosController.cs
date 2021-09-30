using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Challenge_Superliga_.Models;
using Challenge_Superliga_.Servicio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Challenge_Superliga_.Controllers
{
    public class SociosController : Controller
    {
        [HttpGet]
        public ActionResult Socios()
        {
            ResultadoSocio oResultadoSocio = new ResultadoSocio();
            oResultadoSocio.lstSocios = ServicioSocios.FiltrarSocio();
            oResultadoSocio.CantidadSocios = ServicioSocios.ObtenerSocios().Count();
            oResultadoSocio.PromedioEdadRacing = ServicioSocios.ObtenerPromedioEdadRacing();
            oResultadoSocio.lstNombreComunRiver = ServicioSocios.ObtenerNombreMasComunRiver();
            oResultadoSocio.lstDatoEquipo = ServicioSocios.ObtenerDatosSociosAgrupados();
            return View(oResultadoSocio);
        }
    }
}