using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PROJET.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
         {
         }
        //public DbSet<PROJET.Models.Comparaison> Comparaison { get; set; } = default!;
        //public DbSet<PROJET.Models.Methode>? Methode { get; set; }
        //public DbSet<PROJET.Models.MethodeAnalytique>? MethodeAnalytique { get; set; }
       // public DbSet<PROJET.Models.MethodeMachineLearning>? MethodeMachineLearning { get; set; }
        //public DbSet<PROJET.Models.Sauvegarde>? Sauvegarde { get; set; }
        
    }
    
}