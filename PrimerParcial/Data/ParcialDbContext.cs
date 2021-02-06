using Microsoft.EntityFrameworkCore;
using PrimerParcial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcial.Data
{
    public class ParcialDbContext : DbContext
    {
        public ParcialDbContext(DbContextOptions<ParcialDbContext> options) : base(options)
        {

        }
        public DbSet<Articulos> Articulos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articulos>().ToTable("Articulos");

            base.OnModelCreating(modelBuilder);
        }
    }
}
