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

        public IActionResult Autoriza(int ID)
        {
            var datos = _DB.Obtener(ID);

            Console.WriteLine("autoriza "+datos);
            return View(datos);
        }

        [HttpPost]
        public IActionResult Autoriza(ProspectosModel prosp)
        {
            var consulta = _DB.Autorizar(prosp.id);
            Console.WriteLine("httmp auroriza");
            if (consulta)
                return RedirectToAction("Listado");
            else
                return RedirectToAction("Index");
        }

        public IActionResult Rechaza(int ID)
        {
            var datos = _DB.Obtener(ID);

            Console.WriteLine("rechaza "+datos);
            return View(datos);
        }

        [HttpPost]
        public IActionResult Rechaza(ProspectosModel prosp)
        {
            var consulta = _DB.Rechazar(prosp.id, prosp.Descripcion);
            Console.WriteLine("httmp rechaza");
            if (consulta)
                return RedirectToAction("Listado");
            else
                return RedirectToAction("Index");
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