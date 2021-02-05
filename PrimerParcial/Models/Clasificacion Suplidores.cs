using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcial.Models
{
    public class Clasificacion_Suplidores
    {
        public int Id { get; set; }
        public string Clasificacion { get; set; }

        public List<Suplidores> Suplidores { get; set; }
    }
}
