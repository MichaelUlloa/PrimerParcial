using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcial.Models
{
    public class Invoice
    {
        public Invoice(OrdenCompraMaster master)
        {
            Master = master;
            Detalle = master.OrdenCompraDetalles;

            Subtotal = Detalle.Sum(x => x.Subtotal);
            ITBIS = Detalle.Sum(x => x.ITBIS);
            Total = Detalle.Sum(x => x.Total);
        }
        public OrdenCompraMaster Master { get; set; }
        public List<OrdenCompraDetalle> Detalle { get; set; }
        public decimal Subtotal { get; set; }
        public decimal ITBIS { get; set; }
        public decimal Total { get; set; }
    }
}
