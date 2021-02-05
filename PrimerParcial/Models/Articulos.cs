using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcial.Models
{
    public class Articulos
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int SuplidorId { get; set; }
        public int Clasificacion_ArticulosId { get; set; }

        public Clasificacion_Articulos Clasificacion { get; set; }
        public Suplidores Suplidor { get; set; }

    }
}
