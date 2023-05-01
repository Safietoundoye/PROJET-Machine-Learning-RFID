using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PROJET.Models;

namespace PROJET.Data
{
    public class PROJETContext : DbContext
    {
        public PROJETContext (DbContextOptions<PROJETContext> options)
            : base(options)
        {
        }

        public DbSet<PROJET.Models.Résultat> Résultat { get; set; } = default!;

        public DbSet<PROJET.Models.Sauvegarde> Sauvegarde { get; set; } = default!;
    }
}
