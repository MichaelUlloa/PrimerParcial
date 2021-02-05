using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcial.Models
{
    public class Clasificacion_Articulos
    {
        public int Id { get; set; }
        public string Clasificacion { get; set; }

        public List<Articulos> Articulos { get; set; }
    }
}
