using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using PROJET.Models;

namespace PROJET.Controllers
{
    public class SaveResultsController : Controller
    {
        [HttpPost]
        //[Route("/SaveResults")]
        public IActionResult SaveResults(SaveResultsModel model)
        {
            DateTime currentTime = DateTime.Now;
            model.Time = currentTime;

            // Create a string representation of the data
            string data = $"IdSauvegarde: {model.IdSauvegarde}\nAccuracy: {model.Accuracy}\nTime: {model.Time}";

            // Save the data to a .txt file
            string filePath = "C:\\Users\\cafes\\Documents\\Visual Studio 2022\\SaveResultsFile.txt"; // Provide the actual file path
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(data);
            }

            // Redirect back to the homepage or any other page
            return RedirectToAction("Index", "Home");
        }
    }
}
