using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcial.Models
{
    public class Unidades_de_Medida
    {
        public int Id { get; set; }
        public string Medida { get; set; }

        //Relation with Articulos model
        public List<Articulos> Articulos { get; set; }
    }
}
