using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var lstSocios = ServicioSocios.FiltrarSocio();
            ViewBag.TotalSocios = ServicioSocios.ObtenerSocios().Count();
            ViewBag.PromedioEdadRacing = ServicioSocios.ObtenerPromedioEdadRacing();
            ViewBag.NombreComunRiver = ServicioSocios.ObtenerNombreMasComunRiver();
            ViewBag.DatosEquipo = ServicioSocios.ObtenerDatosSociosAgrupados();
            return View(lstSocios);
        }
    }
}