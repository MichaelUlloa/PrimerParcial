using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcial.Models
{
    public class Monedas
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        //Relation with Tasas de Cambio model
        public List<Tasas_de_Cambio> TasasDeCambio { get; set; }
    }
}
