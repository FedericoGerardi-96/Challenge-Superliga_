using Challenge_Superliga_.Servicio;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Data.OleDb;
using System.Configuration;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using Challenge_Superliga_.Models;
using System.Globalization;

namespace Challenge_Superliga_.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
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
