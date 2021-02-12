using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcial.Models
{
    public class Clientes
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        //Relationship with model Clasificacion_Clientes
        public int ClasificacionId { get; set; }
        public Clasificacion_Clientes Clasificacion { get; set; }
    }
}
