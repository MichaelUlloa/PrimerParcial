using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcial.Models
{
    public class Suplidores
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Clasificacion_Suplidores Clasificacion { get; set; }
        public List<Articulos> Articulos { get; set; }
    }
}
