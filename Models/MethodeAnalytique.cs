using System.ComponentModel.DataAnnotations;

namespace PROJET.Models
{
    public class MethodeAnalytique : Methode
    {
        public new int Id { get; set; }
        [Required]
        public float Résultat {get ; set;}

    }
}
