using System.Collections.Generic;
using System.Linq;

namespace PrimerParcial.Models
{
    public class InvoicePrint
    {
        public InvoicePrint(InvoiceMaster master)
        {
            Master = master;
            Detalle = master.InvoiceDetalles;

            Subtotal = Detalle.Sum(x => x.Subtotal);
            ITBIS = Detalle.Sum(x => x.ITBIS);
            Total = Detalle.Sum(x => x.Total);
        }
        public InvoiceMaster Master { get; set; }
        public List<InvoiceDetalle> Detalle { get; set; }
        public decimal Subtotal { get; set; }
        public decimal ITBIS { get; set; }
        public decimal Total { get; set; }
    }
}
