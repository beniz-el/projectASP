using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using projectASP.Models;

namespace projectASP.Data
{
    public class ASPContext : DbContext
    {
        public ASPContext(DbContextOptions<ASPContext> options)
            : base(options)
        { 
        }
        public DbSet<Etudiant> Etudiants { get; set; }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Professeur> Professeurs { get; set; }

        public DbSet<Absence> Absences { get; set; }
        public DbSet<Cour> Cours { get; set; }

        public DbSet<Projet> Projets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Etudiant>().ToTable("Etudiant");

            modelBuilder.Entity<Note>().ToTable("Note");
            modelBuilder.Entity<Professeur>().ToTable("Professeur");

            modelBuilder.Entity<Absence>().ToTable("Absence");
            modelBuilder.Entity<Cour>().ToTable("Cour");

            modelBuilder.Entity<Projet>().ToTable("Projet");

        }

        public DbSet<projectASP.Models.Professeur> Professeur { get; set; }
    }

       
    
}
