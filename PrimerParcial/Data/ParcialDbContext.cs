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
        public DbSet<Articulos> Articulos { get; set; }
        public DbSet<Ciudades> Ciudades { get; set; }
        public DbSet<Clasificacion_Articulos> ClasificacionArticulos{ get; set; }
        public DbSet<Clasificacion_Clientes> ClasificacionClientes { get; set; }
        public DbSet<Clasificacion_Suplidores> ClasificacionSuplidores { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<Empresas> Empresas { get; set; }
        public DbSet<Formas_de_Envio> FormasEnvio { get; set; }
        public DbSet<Formas_de_Pagos> FormasPago { get; set; }
        public DbSet<Marcas> Marcas { get; set; }
        public DbSet<Monedas> Monedas { get; set; }
        public DbSet<Paises> Paises { get; set; }
        public DbSet<Puestos_de_Trabajos> PuestosTrabajo { get; set; }
        public DbSet<Suplidores> Suplidores { get; set; }
         
        public ParcialDbContext(DbContextOptions<ParcialDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articulos>().ToTable("Articulos");

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<PrimerParcial.Models.Tasas_de_Cambio> Tasas_de_Cambio { get; set; }
        public DbSet<PrimerParcial.Models.Tipos_de_Documentos> Tipos_de_Documentos { get; set; }
        public DbSet<PrimerParcial.Models.Ubicaciones> Ubicaciones { get; set; }
        public DbSet<PrimerParcial.Models.Unidades_de_Medida> Unidades_de_Medida { get; set; }
        public DbSet<PrimerParcial.Models.Vendedores> Vendedores { get; set; }
    }
}
