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
            if (context.Clasificacion_Suplidores.Any())
            {
                return;   // DB has been seeded
            }

            var clasificaciones = new Clasificacion_Suplidores[]
            {
                new Clasificacion_Suplidores{Clasificacion="Clasificacion A"},
                new Clasificacion_Suplidores{Clasificacion="Clasificacion B"}
            };
            foreach (Clasificacion_Suplidores a in clasificaciones)
            {
                context.Clasificacion_Suplidores.Add(a);
            }
            context.SaveChanges();
        }
    }
}
