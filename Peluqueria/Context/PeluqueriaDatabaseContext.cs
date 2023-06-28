using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Peluqueria.Models;

namespace Peluqueria.Context
{
    public class PeluqueriaDatabaseContext : DbContext
    {
        public PeluqueriaDatabaseContext(DbContextOptions<PeluqueriaDatabaseContext> Options) : base(Options)
        {

        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Servicio> Servicio { get; set; }
        public DbSet<Turno> Turno { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             modelBuilder.Entity<Turno>()
                .HasOne(t => t.Servicio)
                .WithMany()
                .HasForeignKey(t => t.ServicioId);

            modelBuilder.Entity<Turno>()
               .HasOne(t => t.Cliente)
               .WithMany()
               .HasForeignKey(t => t.ClienteId);

            //modelBuilder.Entity<Turno>()
            //    .HasOne(t => t.Peluquero)
            //    .WithMany()
            //    .HasForeignKey(t => t.PeluqueroId);
        }

    }
}