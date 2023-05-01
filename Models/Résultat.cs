using System.ComponentModel.DataAnnotations;

namespace PROJET.Models
{
    public class Résultat
    {
        public int Id { get; set; }
        [Required]
        public float PourcentageReussite { get; set; }
        
        public DateTime Heure { get; set; }

        public Résultat (DateTime heure)
        {
            Heure = heure;
        }
    }
}
