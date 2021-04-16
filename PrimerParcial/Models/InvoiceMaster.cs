using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcial.Models
{
    public class InvoiceMaster
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Clientes Cliente { get; set; }
        public List<InvoiceDetalle> InvoiceDetalles { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [DisplayName("Fecha de Factura")]
        public DateTime FechaFactura { get; set; }
    }
}
