using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcial.Models
{
    public class Empresas
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Empleados> Empleados { get; set; }
    }
}
