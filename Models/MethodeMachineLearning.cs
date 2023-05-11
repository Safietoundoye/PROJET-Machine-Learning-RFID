using System.ComponentModel.DataAnnotations;


namespace PROJET.Models
{
    public class MethodeMachineLearning : Methode
    {
        public new int Id { get; set; }
        [Required]

      
        public string? TypeAlgoritme { get; set; }
       
        public float Hyperparamétres { get; set; }
        public float Résultat { get; set; }
    }
}
