using Microsoft.AspNetCore.Mvc;
using PROJET.Models;
using System.Diagnostics;

namespace PROJET.Controllers
{
    public class Méthode1Controller : Controller
    {
        private readonly ILogger<Méthode1Controller> _logger;

        public Méthode1Controller(ILogger<Méthode1Controller> logger)
        {
            _logger = logger;
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult SetHyperparameter(int hyperparameter)
        {
            // Traiter la valeur de l'hyperparamètre
            return View();
        }






    }
}