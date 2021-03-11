using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcial.Models
{
    public class Tasas_de_Cambio
    {
        public int Id { get; set; }
        public string ParDeMoneda { get; set; }
        public int Equivalencia { get; set; }

        //Relation with Monedas model
        public int MonedasId { get; set; }
        public Monedas Monedas { get; set; }

    }
}
