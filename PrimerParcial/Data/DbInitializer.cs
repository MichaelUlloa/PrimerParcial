using PrimerParcial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcial.Data
{
    public class DbInitializer
    {
        //WIP
        public static void Initialize(ParcialDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Articulos.Any())
            {
                return;   // DB has been seeded
            }

            var clasificaciones = new Articulos[]
            {
                //new Articulos{"},
                //new Articulos{}
            };
            foreach (Articulos a in clasificaciones)
            {
                context.Articulos.Add(a);
            }
            context.SaveChanges();
        }
    }
}
