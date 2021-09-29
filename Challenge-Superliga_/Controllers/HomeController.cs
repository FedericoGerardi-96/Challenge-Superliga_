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
using CsvHelper;
using System.Globalization;

namespace Challenge_Superliga_.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
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
