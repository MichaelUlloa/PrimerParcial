using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcial.Models
{
    public class Paises
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Relation with Ciudades model
        public List<Ciudades> Ciudades { get; set; }
    }   
}
