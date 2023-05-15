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

                var content = new StringContent(JsonConvert.SerializeObject(null), System.Text.Encoding.UTF8, "application/json");
                var response = await client.PostAsync("http://localhost:5000/analytical", content);
                var result = await response.Content.ReadAsStringAsync();

                ViewBag.Result = result;
            }

            return View("Page2");
        }

        [HttpPost]
        public async Task<IActionResult> RFClassifier(string hyperparameter1, string hyperparameter2)
        {
            using (var client = new HttpClient())
            {
                var requestData = new
                {
                   Hyperparameter1 =  hyperparameter1,

                   Hyperparameter2 = hyperparameter2
                };
                
                var content = new StringContent(JsonConvert.SerializeObject(requestData), System.Text.Encoding.UTF8, "application/json");
                var response = await client.PostAsync("http://localhost:5000/RFClassifier", content);
                var result1 = await response.Content.ReadAsStringAsync();

                ViewBag.Result1 = result1;
            }

            return View("Page3");
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



        public IActionResult ResultMethode1()
        {
          return View();

         }

        public IActionResult ResultMethode2()
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
        public IActionResult Hyperparameter(Hyperparamètres model)
        {
            //int hyperparameter1Value = model.Hyperparameter1;
            // int hyperparameter2Value = model.Hyperparameter2;

            string? NomHParam = model.NomHParam;
           // Effectuer les traitements nécessaires en fonction des valeurs des hyperparamètres

           // Rediriger l'utilisateur vers une autre vue ou une autre action
            return RedirectToAction("Resultats");
        }




    }
}