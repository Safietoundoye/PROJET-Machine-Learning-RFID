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
        public DbSet<PROJET.Models.Résultat> Resultats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration de la base de données ici
        }

    }

}