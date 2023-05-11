using Microsoft.AspNetCore.Mvc;
using PROJET.Models;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Scripting.Hosting;


namespace PROJET.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Analytical()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("http://localhost:5000/analytical");
                var result = await response.Content.ReadAsStringAsync();

                ViewBag.Result = result;
            }

            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AnalyticalWithParams()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("http://localhost:5000/analyticalWithParams");
                var result = await response.Content.ReadAsStringAsync();

                ViewBag.Result = result;
            }

            return View("Index");
        }
        public IActionResult Index()
        {
             return View();
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Page2()
         {
            return View();
        }

        public IActionResult Page3()
        {
            return View();
        }
        public IActionResult Page4()
        {
            return View();
        }

        public IActionResult Page5()
        {
            return View();
        }

        //[HttpPost]
        // public IActionResult SetHyperparameter(int hyperparameter)
        // {
        // Traiter la valeur de l'hyperparamètre
        // return View();
        //  }
        [HttpPost]
        public IActionResult Hyperparameter(MethodeMachineLearning model)
        {
            //int hyperparameter1Value = model.Hyperparameter1;
           // int hyperparameter2Value = model.Hyperparameter2;

            float Hyperparamétres = model.Hyperparamétres;
           // Effectuer les traitements nécessaires en fonction des valeurs des hyperparamètres

           // Rediriger l'utilisateur vers une autre vue ou une autre action
            return RedirectToAction("Resultats");
        }




    }
}