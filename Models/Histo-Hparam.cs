using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROJET.Models
{
    public class Histo_Hparam
    {
        [Key]
        [ForeignKey("Hyperparamètres")] 
        public int IdHParam { get; set; }
        

        public virtual Hyperparamètres?Hyperparams { get; set; }
        [ForeignKey("Sauvegarde")]
        public int IdSauvegarde { get; set; }
        
        public virtual Sauvegarde?Sauvegardes{ get; set; }



    }
}
