using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcial.Models
{
    public class Ciudades
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PaisId { get; set; }
        
        public Paises Pais { get; set; }
    }
}
