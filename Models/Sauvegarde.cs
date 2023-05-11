using PROJET.Models;
using System.ComponentModel.DataAnnotations;

namespace PROJET.Models
{
    public class Sauvegarde
    {
        public int Id { get; set; }
        [Required]
        public float ResultatTest { get; set; }
      
        public DateTime Heure { get; set; }

        public Sauvegarde(DateTime heure)
        {
            Heure = heure;
        }
        //public ICollection<Comparaison>? Comparaisons { get; set; }
    }
}
