using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcial.Models
{
    public class Puestos_de_Trabajos
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Relation with Empleados Model
        public List<Empleados> Empleados { get; set; }

    }
}
