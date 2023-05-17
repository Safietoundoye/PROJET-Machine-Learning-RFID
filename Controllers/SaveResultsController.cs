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

            if (float.TryParse(Request.Form["accuracyR"], out float accuracyR))
            {
                if (model.Accuracy < accuracyR)
                {
                    // Assign the value of accuracyR to accuracy
                    model.Accuracy = accuracyR;
                }
            }

            // Create a string representation of the data
            string data = $"\nIdSauvegarde: {model.IdSauvegarde}\nAccuracy: {model.Accuracy}\nTime: {model.Time}\n________\n";

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
