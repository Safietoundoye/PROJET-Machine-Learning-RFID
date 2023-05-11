using System.ComponentModel.DataAnnotations;

namespace PROJET.Models
{
    public class Comparaison
    {
        public int Id { get; set; }
        [Required]
        public string? ModèleGraph { get; set; }
       
        public float ResultParam { get; set; }
        public float Coordonnéesx { get; set; }
        public float Coordonnéesy { get; set; }

    }
}
