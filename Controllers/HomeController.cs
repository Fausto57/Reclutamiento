using Microsoft.AspNetCore.Mvc;
using Reclutamiento.Data;
using Reclutamiento.Models;
using System.Diagnostics;

namespace Reclutamiento.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        Consults _DB = new Consults();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Capturas()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Captura(ProspectosModel prosp)
        {
            var consulta = _DB.Capturas(prosp);
            if (consulta)
                return RedirectToAction("Listado");
            else
                return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Autoriza(string ID)
        {
            bool respuesta = false;

            try
            {
                int idc = Convert.ToInt32(ID);
                var consulta = _DB.Autorizar(idc);
                Console.WriteLine("httmp auroriza");
                if (consulta)
                    respuesta = true;
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return Json(new { respuesta });
        }

        [HttpPost]
        public JsonResult Rechaza(string ID, string Descripcion)
        {
            bool respuesta = false;

            try
            {
                int idc = Convert.ToInt32(ID);
                var consulta = _DB.Rechazar(idc,Descripcion);
                Console.WriteLine("httmp auroriza");
                if (consulta)
                    respuesta = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return Json(new { respuesta });
        }

        public IActionResult Listado()
        {
            var Lista = _DB.Listar();
            return View(Lista);
        }

        public IActionResult Evaluacion()
        {
            var Lista = _DB.Evaluar();
            return View(Lista);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}