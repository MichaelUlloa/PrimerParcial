using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcial.Models
{
    public class Clasificacion_Clientes
    {
        public int Id { get; set; }
        public string Clasificacion { get; set; }

        public List<Clientes> Clientes { get; set; }
    }
}
