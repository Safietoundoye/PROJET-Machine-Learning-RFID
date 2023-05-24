using Microsoft.AspNetCore.Mvc;
using PROJET.Models;
using PROJET.Data; // Add the namespace for your database context
using System;
using System.IO;

namespace PROJET.Controllers
{
    public class SaveResultsController : Controller
    {
        private readonly PROJETContext _dbContext;

        public SaveResultsController(PROJETContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        //[Route("/SaveResults")]
        public IActionResult SaveResults(SaveResultsModel model)
        {
            DateTime currentTime = DateTime.Now;
            model.Heure = currentTime;

            if (float.TryParse(Request.Form["accuracyR"], out float accuracyR))
            { 
                // Assign the value of accuracyR to accuracy
                model.Accuracy = accuracyR;    
            }

            // Create a string representation of the data
            string data = $"\nIdSauvegarde: {model.IdSauvegarde}\nAccuracy: {model.Accuracy}\nTime: {model.Heure}\n________\n";


            // Create an instance of Sauvegarde entity
            var sauvegarde = new Sauvegarde
            {
                Accuracy = model.Accuracy,
                Heure = currentTime,
                methodeId = model.MethodeId
            };

            // Add the sauvegarde entity to the DbSet of your context
            _dbContext.Sauvegarde.Add(sauvegarde);

            // Save changes to the database
            _dbContext.SaveChanges();

            // Redirect back to the homepage or any other page
            return RedirectToAction("Index", "Home");
        }
    }
}
